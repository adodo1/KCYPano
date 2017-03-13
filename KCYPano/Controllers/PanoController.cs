using Dapper;
using KCYPano.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KCYPano.Controllers
{
    public class PanoController : Controller
    {
        private static string PANO_TEMP_PATH = AppDomain.CurrentDomain.BaseDirectory + "TEMP";
        private static string PANO_DB_FILE = @"E:\DoDo\C#\全景上传\_db\panos.db";
        private static string PANO_SHP_FILE = @"E:\DoDo\C#\全景上传\_db\panos.shp";
        private static string PANO_TOOL_EXE = @"E:\DoDo\C#\全景上传\_tools\krpano\krpanotools64.exe";

        //
        // GET: /Pano/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 上传全景图片
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Add(HttpPostedFileBase filedata, string name)
        {
            try
            {
                string filePath = Server.MapPath("~/data/");
                if (!Directory.Exists(filePath)) {
                    Directory.CreateDirectory(filePath);
                }

                string fileName = Path.GetFileName(filedata.FileName);              // 原始文件名称
                string fileExtension = Path.GetExtension(fileName);             // 文件扩展名
                string saveName = Guid.NewGuid().ToString() + fileExtension;    // 保存文件名称
                filedata.SaveAs(filePath + saveName);

                return Json(new { code = 100, success = false, uid = 1, message = "" });
            }
            catch (Exception ex)
            {
                return Json(new { code = 100, success = false, uid = -1, message = ex.Message });
            }
        }
        /// <summary>
        /// 生成全景
        /// </summary>
        /// <param name="uid">全景图ID</param>
        /// <param name="name">全景名称</param>
        /// <param name="category">全景分类</param>
        /// <param name="date">全景日期(时间戳)</param>
        /// <param name="heading">朝向</param>
        /// <param name="lat">纬度</param>
        /// <param name="lng">经度</param>
        /// <param name="remark">描述</param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Build(string uid, string name, string category, int date, int heading, double lat, double lng, string remark)
        {
            return Json(new { code = 100, success = false, uid = 1, message = "" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get)]
        public string PanoXml(string uid)
        {
            //PanoItem item;

            SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();
            sb.DataSource = @"D:\TEMP\panos.db";
            SQLiteConnection conn = new SQLiteConnection(sb.ToString());
            conn.Open();
            string sql = "select * from panos";

            foreach (var item in conn.Query<PanoItem>(sql))
            {

            }

            sql = "select * from tiles";

            foreach (var item in conn.Query<TileItem>(sql))
            {

            }

            return "xml:" + uid;
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult PanoInfo(string uid)
        {
            return Json(new { code = 100, success = false, uid = 1, message = "" });
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult PanoList()
        {
            return Json(new { code = 100, success = false, uid = 1, message = "" });
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
