using Dapper;
using KCYPano.Common;
using KCYPano.Models;
using KCYPano.PanoTools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace KCYPano.Controllers
{
    public class PanoController : Controller
    {
        private static string _connstr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static string PANO_TEMP_PATH = "~/_files/";                             // 上传临时目录
        private static string PANO_DATA_PATH = "~/_data/";                              // 存放数据目录
        private static string PANO_SAVE_PATH = "~/_save/";                              // 全景保存目录
        private static string PANO_TILE_PATH = "~/_tiles/";                             // 全景保存目录
        private static string PANO_OLD_DATA = "~/_olddata/";                            // 旧的全景目录
        private static string PANO_TOOL_EXE = "~/_tools/krpano/krpanotools64.exe";      // 制作全景工具

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注册全景工具
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult Register()
        {
            string toolfile = Server.MapPath(PANO_TOOL_EXE);
            PanoMaker maker = new PanoMaker();
            bool success = maker.Register(toolfile);
            if (success) return Json(new { code = 0, message = "注册成功." }, JsonRequestBehavior.AllowGet);
            else return Json(new { code = 101, message = "注册失败." }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查看全景
        /// </summary>
        /// <param name="uid">全景ID</param>
        /// <returns></returns>
        public ActionResult Look(string uid)
        {
            // 传不过去
            //return View(new { uid = uid });
            // 方法1
            //string jsonstr = JsonConvert.SerializeObject(new { uid = uid });
            //dynamic json = JsonConvert.DeserializeObject(jsonstr);
            //return View(json);
            ////@Model.uid

            #region 新增对旧数据的支持
            string oldhtml = string.Format("{0}\\{1}.html", Server.MapPath(PANO_OLD_DATA), uid);
            string oldurl = string.Format("{0}/{1}.html", PANO_OLD_DATA, uid);
            if (System.IO.File.Exists(oldhtml)) return Redirect(oldurl);
            #endregion


            ViewData["uid"] = uid;
            //@ViewData["uid"]
            return View();
        }
        /// <summary>
        /// 上传全景图片
        /// </summary>
        /// <param name="filedata"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Add(HttpPostedFileBase filedata)
        {
            try {
                // 保存图片到临时目录
                string uid = Guid.NewGuid().ToString("N");
                string file = string.Format("{0}\\{1}.JPG", Server.MapPath(PANO_TEMP_PATH), uid);
                // 在VS里调试的时候回出现内存不足 但是在IIS里不会
                //Bitmap bitmap = new Bitmap(filedata.InputStream);
                //if (bitmap.Width != bitmap.Height * 2) throw new Exception("图片比例不是2:1");
                //bitmap.Save(file);
                //bitmap.Dispose();
                filedata.SaveAs(file);
                //
                return Json(new { code = 0, success = true, uid = uid, message = "" });
            }
            catch (Exception ex) {
                return Json(new { code = 101, success = false, uid = "", message = ex.Message });
            }
        }
        /// <summary>
        /// 生成全景
        /// </summary>
        /// <param name="uid">全景图ID</param>
        /// <param name="name">全景名称</param>
        /// <param name="category">全景分类</param>
        /// <param name="date">全景日期(时间戳 秒)</param>
        /// <param name="heading">朝向</param>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <param name="author">作者</param>
        /// <param name="remark">描述</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Build(string uid, string name, string category, long date, int heading, double lat, double lng, string author, string remark)
        {
            try {
                // 
                string imagefile = string.Format("{0}\\{1}.JPG", Server.MapPath(PANO_TEMP_PATH), uid);
                if (System.IO.File.Exists(imagefile) == false) throw new Exception("无效的UID: " + uid);
                string toolfile = Server.MapPath(PANO_TOOL_EXE);
                // 切图
                string message = "";
                string scenexml = "";
                string root = "";
                string[] tiles = new string[0];
                PanoMaker maker = new PanoMaker();
                bool success = maker.MakeNormal(toolfile, imagefile, 100, out message, out scenexml, out tiles, out root);
                if (success == false) throw new Exception(message);
                // 时间戳转换
                DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                DateTime time = start.Add(new TimeSpan(date * 10000000));
                // epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000
                
                // 入库
                PanoItem panoItem = new PanoItem() {
                    uid = uid,
                    name = name,
                    category = category,
                    shottime = time,
                    heading = heading,
                    lat = lat,
                    lng = lng,
                    author = author,
                    remark = remark,
                    maketime = DateTime.Now
                };
                SceneItem sceneItem = new SceneItem() {
                    uid = uid,
                    scene = scenexml
                };

                string sql1 = "insert into PANOS(uid, name, category, shottime, heading, lat, lng, author, remark, maketime) " +
                              "values(@uid, @name, @category, @shottime, @heading, @lat, @lng, @author, @remark, @maketime)";
                string sql2 = "insert into PANOSSCENE(uid, scene) " +
                              "values(@uid, @scene)";
                SQLiteConnection conn = new SQLiteConnection(_connstr);
                conn.Open();
                int result1 = conn.Execute(sql1, panoItem);             // 插入
                int result2 = conn.Execute(sql2, sceneItem);            // 插入
                conn.Close();

                // 存储瓦片数据 碎片直接放磁盘上 放数据库访问起来会有点慢
                foreach (string tile in tiles) {
                    string tileroot = Server.MapPath(PANO_TILE_PATH);
                    string tilename = System.IO.Path.GetFileName(tile);
                    string tilepath = System.IO.Path.GetDirectoryName(tile).ToLower().Replace(root.ToLower(), "");
                    string tilesave = tileroot + "//" + tilepath;
                    string tilefile = tilesave + "//" + tilename;
                    if (System.IO.Directory.Exists(tilesave) == false)
                        System.IO.Directory.CreateDirectory(tilesave);
                    System.IO.File.Move(tile, tilefile);
                }
                
                // 保存图片 和 基本信息
                string imagesave = string.Format("{0}\\{1}.JPG", Server.MapPath(PANO_SAVE_PATH), uid);
                System.IO.File.Move(imagefile, imagesave);
                StreamWriter writer = new StreamWriter(string.Format("{0}\\{1}.TXT", Server.MapPath(PANO_SAVE_PATH), uid));
                writer.WriteLine("uid:" + panoItem.uid.Replace("\r\n", "\\r\\n"));
                writer.WriteLine("name:" + panoItem.name.Replace("\r\n", "\\r\\n"));
                writer.WriteLine("category:" + panoItem.category.Replace("\r\n", "\\r\\n"));
                writer.WriteLine("shottime:" + panoItem.shottime.ToString("yyyy/MM/dd HH:mm:ss"));
                writer.WriteLine("heading:" + panoItem.heading.ToString());
                writer.WriteLine("lat:" + panoItem.lat.ToString());
                writer.WriteLine("lng:" + panoItem.lng);
                writer.WriteLine("author:" + panoItem.author.Replace("\r\n", "\\r\\n"));
                writer.WriteLine("remark:" + panoItem.remark.Replace("\r\n", "\\r\\n"));
                writer.WriteLine("maketime:" + panoItem.maketime.ToString("yyyy/MM/dd HH:mm:ss"));
                writer.Flush();
                writer.Close();
                
                // 删除成图临时目录
                string outputdir = string.Format("{0}\\{1}", Server.MapPath(PANO_TEMP_PATH), uid);
                System.IO.Directory.Delete(outputdir, true);

                return Json(new { code = 0, success = true, uid = uid, message = "" });
            }
            catch (Exception ex) {
                return Json(new { code = 101, success = false, uid = "", message = ex.Message });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">全景UID</param>
        /// <param name="view">全景页面样式</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult PanoXml(string uid, string view)
        {
            //PanoItem item;
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            string sql1 = "select * from panosscene where uid=@uid";
            string sql2 = "select * from panos where uid=@uid";
            //
            ViewData["scene"] = "";
            try {
                SceneItem sceneItem = conn.QueryFirst<SceneItem>(sql1, new { uid = uid });
                PanoItem panoItem = conn.QueryFirst<PanoItem>(sql2, new { uid = uid });

                //<layer name="map" keep="true"
                //       url="bingmaps.swf" alturl="../panorama/plugins/leafletmaps.js"
                //       align="rightbottom" x="0" y="0" width="270" height="300"
                //       lat="24.30522" lng="109.429847" zoom="15">

                //    <spot name="stpeterssquare" active="true"
                //          lat="24.30522" lng="109.429847" heading="64.5"
                //          onclick="" />

                //    <radar visible="true" zoomwithmap="true" size="50" />
                //</layer>

                if (sceneItem != null && panoItem != null) {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(sceneItem.scene);
                    doc.SelectSingleNode("/scene").Attributes["name"].Value = "_" + uid;                        // 全景名称
                    doc.SelectSingleNode("/scene").Attributes["title"].Value = panoItem.name;                   // 全景标题
                    string thumburl = doc.SelectSingleNode("/scene").Attributes["thumburl"].Value;
                    thumburl = "../_tiles/" + thumburl.Substring(5);
                    doc.SelectSingleNode("/scene").Attributes["thumburl"].Value = thumburl;                     // 全景预览图
                    doc.SelectSingleNode("/scene").Attributes["lat"].Value = panoItem.lat.ToString();           // 纬度
                    doc.SelectSingleNode("/scene").Attributes["lng"].Value = panoItem.lng.ToString();           // 经度
                    doc.SelectSingleNode("/scene").Attributes["heading"].Value = panoItem.heading.ToString();   // 朝向
                    string text = doc.SelectSingleNode("/scene").InnerXml;
                    text = text.Replace("\"panos/", "\"../_tiles/");
                    doc.SelectSingleNode("/scene").InnerXml = text;


                    string radar = @"
<layer name=`map` keep=`true`
       url=`bingmaps.swf` alturl=`../panorama/plugins/leafletmaps.js`
       align=`rightbottom` x=`0` y=`0` width=`270` height=`300`
       lat=`{0}` lng=`{1}` zoom=`14`>
    <spot name=`stpeterssquare` active=`true`
          lat=`{0}` lng=`{1}` heading=`{2}`
          onclick=`` />
    <radar visible=`true` zoomwithmap=`true` size=`40` />
</layer>";
                    radar = radar.Replace("`", "\"");
                    radar = string.Format(radar, panoItem.lat, panoItem.lng, panoItem.heading);


                    ViewData["scene"] = doc.OuterXml + radar;
                }
            }
            catch (Exception ex) {
                throw;
            }


            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult PanoInfo(string uid)
        {
            return Json(new { code = 100, success = false, uid = 1, message = "" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修正全景角度
        /// </summary>
        /// <param name="uid">全景ID</param>
        /// <param name="lookat">修正角度</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult North(string uid, int lookat)
        {
            lookat = lookat % 360;
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            int result = conn.Execute("update PANOS set HEADING=@lookat WHERE UID=@uid", new { uid = uid, lookat = lookat });
            conn.Close();
            return Json(new { code = 100, success = result > 0, uid = uid, message = "" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取全景点列表
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult PanoList()
        {
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            string sql = "select * from panos where FLAG is Null or FLAG not in('DEL')";
            var list = conn.Query<PanoItem>(sql);
            //return Json(list, JsonRequestBehavior.AllowGet);
            List<object> result = new List<object>();
            foreach (var item in list) {
                var point = new {
                    type = "Feature",
                    geometry = new {
                        type = "Point",
                        coordinates = new[] { item.lng, item.lat }
                    },
                    properties = new {
                        uid = item.uid,
                        type = item.category,
                        name = item.name,
                        shottime = (item.shottime.Ticks - 621355968000000000) / 10000,
                        maketime = (item.maketime.Ticks - 621355968000000000) / 10000,
                        remark  = item.remark
                    }
                };
                result.Add(point);
            }
            return Json(result, JsonRequestBehavior.AllowGet);

            //return Json(new { code = 100, success = false, uid = 1, message = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取全景点列表80 西安80坐标
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult PanoList80()
        {
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            string sql = "select * from panos where FLAG is Null or FLAG not in('DEL')";
            var list = conn.Query<PanoItem>(sql);
            //return Json(list, JsonRequestBehavior.AllowGet);
            List<object> result = new List<object>();
            foreach (var item in list) {

                double lng = item.lng;
                double lat = item.lat;
                double[] coors = SHPCoord.WGS84XA80.Instance.WGS84_XA80(lat, lng, 0);

                var point = new {
                    type = "Feature",
                    geometry = new {
                        type = "Point",
                        coordinates = new[] { coors[0], coors[1] }
                    },
                    properties = new {
                        uid = item.uid,
                        type = item.category,
                        name = item.name,
                        shottime = (item.shottime.Ticks - 621355968000000000) / 10000,
                        maketime = (item.maketime.Ticks - 621355968000000000) / 10000,
                        remark  = item.remark
                    }
                };
                result.Add(point);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除指定全景图 彻底删除
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PanoDel(string uid)
        {
            if (uid.Contains(".")) return Json(new { code = 101, success = false, uid = uid, message = "非法的UID" }, JsonRequestBehavior.AllowGet);
            // 删数据库
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            conn.Execute("delete from panos where uid=@uid", new { uid = uid });
            conn.Execute("delete from panosscene where uid=@uid", new { uid = uid });
            conn.Close();
            // 删瓦片
            string tileroot = Server.MapPath(PANO_TILE_PATH);
            string tilepath = System.IO.Path.GetFullPath(tileroot + "/" + uid + ".tiles");
            if (System.IO.Directory.Exists(tilepath)) System.IO.Directory.Delete(tilepath, true);
            // 返回
            return Json(new { code = 100, success = true, uid = uid, message = "已删除全景:" + uid }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 全景标记为删除 不是真正的删除
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PanoRemove(string uid)
        {
            if (uid.Contains(".")) return Json(new { code = 101, success = false, uid = uid, message = "非法的UID" }, JsonRequestBehavior.AllowGet);
            // 标记删除
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            conn.Execute("update panos set FLAG='DEL' where uid=@uid", new { uid = uid });
            conn.Close();

            return Json(new { code = 100, success = true, uid = uid, message = "标记删除全景:" + uid }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 标记为删除的全景还原
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult PanoRestore(string uid)
        {
            if (uid.Contains(".")) return Json(new { code = 101, success = false, uid = uid, message = "非法的UID" }, JsonRequestBehavior.AllowGet);
            // 标记删除
            SQLiteConnection conn = new SQLiteConnection(_connstr);
            conn.Open();
            conn.Execute("update panos set FLAG='' where uid=@uid", new { uid = uid });
            conn.Close();

            return Json(new { code = 100, success = true, uid = uid, message = "已还原全景:" + uid }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 全景导出离线数据
        /// </summary>
        /// <param name="uids"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public FileResult PanoGetOffline(string uids)
        {
            return File(new FileStream(@"F:\DoDo\勘测院全景系统\KCYPano\data\topband.jpg", FileMode.Open, FileAccess.Read, FileShare.Read), "image/jpeg");
        }

        [HttpGet]
        public FileResult PanoTile(string uid, string file)
        {
            //FileStreamResult
            //FileResult



            return File(new FileStream(@"F:\DoDo\勘测院全景系统\KCYPano\data\topband.jpg", FileMode.Open, FileAccess.Read, FileShare.Read), "image/jpeg");

        }

        
    }
}
