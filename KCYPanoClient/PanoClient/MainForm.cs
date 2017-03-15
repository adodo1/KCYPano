using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PanoClient.ImageListView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PanoClient
{
    public partial class MainForm : Form
    {
        private GMapMarker _curentMarker = null;
        public readonly GMapOverlay _markers = new GMapOverlay("markers");  // 单张照片

        public MainForm()
        {
            InitializeComponent();

            InitMAP();
            InitImageListView();
        }
        /// <summary>
        /// 
        /// </summary>
        private void InitProGridEx()
        {
            //propertyGridEx.ShowCustomProperties = true;

            //List<CustomProperty> lstCustomProperty = new List<CustomProperty>();

            //lstCustomProperty.Add(new CustomProperty("TNSNAME", "TNS连接", "aa", false, "设置", "TNS连接名\r\n例如：orcl", true, 70));
            //lstCustomProperty.Add(new CustomProperty("GISNAME", "GIS用户", "bb", false, "设置", "GIS用户名\r\n例如：jygis", true, 50));
            //lstCustomProperty.Add(new CustomProperty("GISPASS", "GIS密码", "cc", false, "设置", "GIS密码", true) { IsPassword = true });
            //lstCustomProperty.Add(new CustomProperty("GISDATANAME", "GISDATA用户", "ee", false, "设置", "GISDATA用户名\r\n例如：jygisdata", true));
            //lstCustomProperty.Add(new CustomProperty("GISDATAPASS", "GISDATA密码", "ff", false, "设置", "GISDATA密码", true) { IsPassword = true });
            //lstCustomProperty.Add(new CustomProperty("SERVICE", "服务器", "gg", false, "设置", "服务器的计算机名或者IP地址", true, 40));

            //lstCustomProperty.Sort(ComparerCustomProperty);
            //foreach (CustomProperty item in lstCustomProperty) propertyGridEx.Item.Add(item);

            //propertyGridEx.Refresh();
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparerCustomProperty(CustomProperty x, CustomProperty y)
        {
            return x.Order.CompareTo(y.Order);
        }
        /// <summary>
        /// 初始化图片浏览控件
        /// </summary>
        private void InitImageListView()
        {
            //imageListView.View = PanoClient.ImageListView.View.Gallery;
            //ImageListView.ImageListViewRenderer renderer = new PanoClient.ImageListView.ImageListViewRenderers.NoirRenderer();
            //imageListView.SetRenderer(renderer);

            imageListView.ThumbnailSize = new Size(200, 150);
        }
        /// <summary>
        /// 初始化地图
        /// </summary>
        private void InitMAP()
        {
            if (!GMapControl.IsDesignerHosted) {
                //GMapProviders.GoogleMap.TryCorrectVersion = false;
                //GMapProviders.GoogleSatelliteMap.TryCorrectVersion = false;
                //GMapProviders.GoogleChinaMap.TryCorrectVersion = false;
                //GMapProviders.GoogleChinaSatelliteMap.TryCorrectVersion = false;
                //MainMap.MapProvider = GMapProviders.GoogleSatelliteMap;             // 默认地图

                MainMap.MapProvider = CustomProvider.Instance;                      // 默认地图
                MainMap.Position = new PointLatLng(24.305555555555557, 109.43);     // 地图中心点(北京)GPS坐标
                MainMap.MinZoom = GMapProviders.GoogleSatelliteMap.MinZoom;         // 地图最小比例
                MainMap.MaxZoom = GMapProviders.GoogleSatelliteMap.MaxZoom ?? 24;   // 地图最大比例
                MainMap.Zoom = 18;                                                  // 当前缩放等级
                MainMap.DragButton = MouseButtons.Left;                             // 鼠标平移键

                // 鼠标
                MainMap.MouseDown += MainMap_MouseDown;
                MainMap.MouseMove += MainMap_MouseMove;
                MainMap.MouseUp += MainMap_MouseUp;
                MainMap.OnMapZoomChanged += MainMap_OnMapZoomChanged;

                MainMap.OnMarkerLeave += MainMap_OnMarkerLeave;
                MainMap.OnMarkerEnter += MainMap_OnMarkerEnter;

                MainMap.Overlays.Add(_markers);
            }
        }
        /// <summary>
        /// 鼠标移到图标上
        /// </summary>
        /// <param name="item"></param>
        void MainMap_OnMarkerEnter(GMapMarker item)
        {
            if (!_isMouseDown) {
                _curentMarker = item;
            }
        }
        /// <summary>
        /// 鼠标从图标上离开
        /// </summary>
        /// <param name="item"></param>
        private void MainMap_OnMarkerLeave(GMapMarker item)
        {
            if (!_isMouseDown) {
                _curentMarker = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void MainMap_OnMapZoomChanged()
        {
            UpdateCoordinateInfo(null, null, MainMap.Zoom);
        }
        private double _lastlat = 0;        // 上次维度
        private double _lastlng = 0;        // 上次经度
        private double _lastzoom = 0;          // 上次等级
        /// <summary>
        /// 刷新经纬度坐标
        /// </summary>
        /// <param name="e"></param>
        private void UpdateCoordinateInfo(double? lat, double? lng, double? zoom)
        {
            if (lat != null) _lastlat = (double)lat;
            if (lng != null) _lastlng = (double)lng;
            if (zoom != null) _lastzoom = (int)zoom;
            toolStripStatusLabelInfo.Text = string.Format("经度:{0:0.000000} 纬度:{1:0.000000} 级别:{2}", _lastlng, _lastlat, _lastzoom);
        }


        #region 鼠标控制
        private bool _isMouseDraging = false;       // 鼠标是否正在拖动
        private bool _isMouseDown = false;          // 鼠标是否按下
        private int _lastX = 0;                     // 由于莫名其妙的鼠标偏移 所以加上一个小偏移的判断
        private int _lastY = 0;                     // 由于莫名其妙的鼠标偏移 所以加上一个小偏移的判断

        /// <summary>
        /// 鼠标按下
        /// </summary>
        private void MainMap_MouseDown(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
            if (e.Button == MouseButtons.Left && ModifierKeys != Keys.Alt && ModifierKeys != Keys.Control) {
                _isMouseDown = true;
                _isMouseDraging = false;
                _lastX = e.X;
                _lastY = e.Y;
            }
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        private void MainMap_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);
            UpdateCoordinateInfo(point.Lat, point.Lng, MainMap.Zoom);
            
            //if (e.Button == MouseButtons.Left && _isMouseDown &&
            //    (Math.Abs(e.X  - _lastX) >1 || Math.Abs(e.Y - _lastY) > 1)) {
            //    // 正在拖动地图
            //    _isMouseDraging = true;

            //    // 正在移动标记点
            //    GMarkerGoogle curentMarker = _curentMarker as GMarkerGoogle;
            //    if (curentMarker != null) {
            //        try {
            //            // check if this is a grid point
            //            if (curentMarker.Tag.ToString().Contains("grid")) {
            //                // 移动多边形
            //                drawnpolygon.Points[
            //                    int.Parse(curentMarker.Tag.ToString().Replace("grid", "")) - 1] =
            //                    new PointLatLng(point.Lat, point.Lng);
            //                MainMap.UpdatePolygonLocalPosition(drawnpolygon);   
            //                // 移动标记点
            //                curentMarker.Position = point;
            //                MainMap.Invalidate();
            //            }
            //        }
            //        catch { }
            //    }
            //}

        }
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        private void MainMap_MouseUp(object sender, MouseEventArgs e)
        {
            PointLatLng point = MainMap.FromLocalToLatLng(e.X, e.Y);

            //if (e.Button == MouseButtons.Left && _isMouseDown) {
            //    _isMouseDown = false;
            //    _curentMarker = null;
            //    if (_isMouseDraging == false) {
            //        if (_polygongridmode == false) return;  // 如果没有在绘制多边形的模式 返回
            //        AddPolygonPoint(point.Lat, point.Lng);
                    
            //    }
            //}
        }
        #endregion

        /// <summary>
        /// 加载图片
        /// </summary>
        private void toolStripMenuItemLoadIMG_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "全景图片|*.jpg;*.png;*.bmp|所有文件|*.*";
            dialog.Multiselect = true;
            if (DialogResult.OK != dialog.ShowDialog(this)) return;
            foreach (string file in dialog.FileNames) {
                imageListView.Items.Add(file);
            }
        }
        /// <summary>
        /// 导入坐标
        /// </summary>
        private void toolStripMenuItemLoadCoor_Click(object sender, EventArgs e)
        {
            // 创建表格
            DataTable table = new DataTable("coors");
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("lat", typeof(double));
            table.Columns.Add("lng", typeof(double));
            table.Columns.Add("file", typeof(string));
            // 填数据
            foreach (ImageListViewItem item in imageListView.Items) {
                DataRow row = table.NewRow();
                row["name"] = item.PanoName;
                row["lat"] = item.PanoLat;
                row["lng"] = item.PanoLng;
                row["file"] = item.FileName;
                table.Rows.Add(row);
            }
            // 导入坐标
            LoadCoorForm form = new LoadCoorForm(table);
            if (DialogResult.OK != form.ShowDialog(this)) return;
            // 更新表格
            foreach (ImageListViewItem item in imageListView.Items) {
                string file = item.FileName;
                foreach (DataRow row in table.Rows) {
                    string fname = Convert.ToString(row["file"]);
                    double lat = Convert.ToDouble(row["lat"]);
                    double lng = Convert.ToDouble(row["lng"]);
                    string name = Convert.ToString(row["name"]);
                    if (fname == file) {
                        item.PanoName = name;
                        item.PanoLat = lat;
                        item.PanoLng = lng;
                    }
                }
            }

        }
        /// <summary>
        /// 提交
        /// </summary>
        private void toolStripMenuItemSubmit_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("category", typeof(string));      // 分类
            table.Columns.Add("lat", typeof(double));           // 纬度
            table.Columns.Add("lng", typeof(double));           // 经度
            table.Columns.Add("date", typeof(DateTime));        // 日期
            table.Columns.Add("heading", typeof(double));       // 角度
            table.Columns.Add("describe", typeof(string));      // 描述
            table.Columns.Add("info", typeof(string));          // 信息
            table.Columns.Add("file", typeof(string));          // 文件

            // 填数据
            foreach (ImageListViewItem item in imageListView.Items) {
                DataRow row = table.NewRow();
                row["name"] = item.PanoName.Trim();
                row["category"] = item.PanoCategory.Trim();
                row["lat"] = item.PanoLat;
                row["lng"] = item.PanoLng;
                row["date"] = item.PanoDate;
                row["heading"] = item.PanoHeading;
                row["describe"] = item.PanoDes;
                row["file"] = item.FileName;
                // 检查
                int width = item.Dimensions.Width;
                int height = item.Dimensions.Height;
                string isok = "";
                if (Convert.ToString(row["name"]) == "") isok = "未填写全景名称";
                else if (Convert.ToString(row["category"]) == "") isok = "未设置全景分类";
                else if (Convert.ToDouble(row["lat"]) == 0) isok = "纬度没有填写";
                else if (Convert.ToDouble(row["lng"]) == 0) isok = "经度没有填写";
                else if (width / height != 2.0) isok = "图片宽高比不为2:1";
                if (isok == "") row["info"] = "通过";
                else row["info"] = isok;
                // 
                table.Rows.Add(row);
            }

            CheckForm form = new CheckForm(table);
            form.ShowDialog(this);
        }
        /// <summary>
        /// 关于
        /// </summary>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            WCFClient client = new WCFClient();
            client.test();

            MessageBox.Show("柳州市勘测院 -- DoDo", "(∩_∩)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        private void imageListView_SelectionChanged(object sender, EventArgs e)
        {
            ImageListViewItem sel = null;
            if (imageListView.SelectedItems.Count > 0) sel = imageListView.SelectedItems[0];
            propertyGridEx.SelectedObject = sel;

            // 地图上定位坐标
            _markers.Markers.Clear();
            if (sel != null && sel.PanoLat != 0 && sel.PanoLng != 0) {
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(sel.PanoLat, sel.PanoLng), GMarkerGoogleType.pink);
                marker.ToolTipMode = MarkerTooltipMode.Always;
                marker.ToolTipText = sel.PanoName;
                _markers.Markers.Add(marker);
                MainMap.Position = new PointLatLng(sel.PanoLat, sel.PanoLng);   // 定位
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void imageListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                // 删除选中
                if (imageListView.SelectedItems.Count > 0) {
                    for (int i = imageListView.SelectedItems.Count - 1; i >= 0; i--) {
                        imageListView.Items.Remove(imageListView.SelectedItems[i]);
                    }
                }
            }
        }


    }
}
