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
        private BackgroundWorker _worker;

        public MainForm()
        {
            InitializeComponent();

            InitMAP();
            InitImageListView();

            //设置自动换行
            dataGridViewPano.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //设置自动调整高度
            dataGridViewPano.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewPano.Cursor = new Cursor(GetType(), "Resources.mouse.cur");
            _worker = new BackgroundWorker();
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
            dataGridViewPano.DataSource = null;
            dataGridViewPano.DataSource = imageListView.Items;
            //((DataGridViewComboBoxColumn)dataGridViewPano.Columns["PanoCategory"]).DataSource = new string[] { "11", "22", "33" };
            dataGridViewPano.Refresh();
        }
        /// <summary>
        /// 导入坐标
        /// </summary>
        private void toolStripMenuItemLoadCoor_Click(object sender, EventArgs e)
        {
            // 导入坐标
            LoadCoorForm form = new LoadCoorForm();
            if (DialogResult.OK != form.ShowDialog(this)) return;
            List<double[]> coors = form.Coors;
            // 更新坐标
            for (int i = 0; i < imageListView.Items.Count; i++) {
                ImageListViewItem item = imageListView.Items[i];
                if (i < coors.Count) {
                    item.PanoLat = coors[i][0];
                    item.PanoLng = coors[i][1];
                }
            }
            dataGridViewPano.Refresh();
        }
        /// <summary>
        /// 提交
        /// </summary>
        private void toolStripMenuItemSubmit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("是否确定提交数据？", "全景提交", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) return;
            tabControl.SelectedIndex = 1;
            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = true;
            _worker.ProgressChanged += new ProgressChangedEventHandler(RefreshPano);
            _worker.DoWork += new DoWorkEventHandler(SubmmitPano);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(FinishPano);
            _worker.RunWorkerAsync(imageListView.Items.ToArray());
        }
        /// <summary>
        /// 刷新进度
        /// </summary>
        private void RefreshPano(object sender, ProgressChangedEventArgs e)
        {
            string message = e.UserState as string;
            if (message.Contains("失败") || message.Contains("错误")) ShowMessage(message, Color.Red);
            else ShowMessage(message, Color.Blue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        private void ShowMessage(string message, Color color)
        {
            int len = richTextBox.Text.Length;
            if (len > 0) richTextBox.SelectionStart = len;
            richTextBox.SelectionColor = color;
            richTextBox.ScrollToCaret();
            richTextBox.AppendText(message + Environment.NewLine);
        }
        /// <summary>
        /// 全景提交完成
        /// </summary>
        private void FinishPano(object sender, RunWorkerCompletedEventArgs e)
        {
            richTextBox.AppendText("完成!\r\n");
            MessageBox.Show("完成.", "全景提交", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 处理线程
        /// </summary>
        private void SubmmitPano(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker.CancellationPending) {
                e.Cancel = true;
                return;
            }
            try {
                WCFClient client = new WCFClient();
                ImageListViewItem[] items = (ImageListViewItem[])e.Argument;
                int index = 0;
                List<string> uids = new List<string>();
                foreach (ImageListViewItem item in items) {
                    if (worker.CancellationPending) {
                        e.Cancel = true;
                        return;
                    }
                    string file = item.FileName;
                    string name = item.PanoName;
                    string category = item.PanoCategory;
                    long date = (item.PanoDate.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
                    int heading = item.PanoHeading;
                    double lat = item.PanoLat;
                    double lng = item.PanoLng;
                    string author = item.PanoAuthor;
                    string remark = item.PanoRemark;

                    worker.ReportProgress(index, string.Format("{0} {1}/{2}: 开始上传图片: {3}.", DateTime.Now.ToString("HH:mm:ss"), ++index, items.Length, name));
                    if (item.Dimensions.Width != item.Dimensions.Height * 2) {
                        worker.ReportProgress(index, string.Format("{0} {1}/{2}: 图片比例不是 2:1 无法提交.", DateTime.Now.ToString("HH:mm:ss"), index, items.Length));
                        continue;
                    }
                    // 上传文件
                    string result1 = client.Add(item.FileName);
                    object json1 = Json.JsonDeserialize<object>(result1);
                    bool success1 = Convert.ToBoolean(((Dictionary<string, object>)json1)["success"]);
                    string message1 = Convert.ToString(((Dictionary<string, object>)json1)["message"]);
                    string uid = Convert.ToString(((Dictionary<string, object>)json1)["uid"]);
                    if (success1 == true) worker.ReportProgress(index, string.Format("{0} {1}/{2}: 上传成功.", DateTime.Now.ToString("HH:mm:ss"), index, items.Length));
                    else worker.ReportProgress(index, string.Format("{0} {1}/{2}: 上传失败: {3}", DateTime.Now.ToString("HH:mm:ss"), index, items.Length, message1));

                    // 创建全景
                    if (success1 == false) continue;
                    worker.ReportProgress(index, string.Format("{0} {1}/{2}: 正在生成全景: {3}", DateTime.Now.ToString("HH:mm:ss"), index, items.Length, name));
                    string result2 = client.Build(uid, name, category, date, heading, lat, lng, author, remark);
                    object json2 = Json.JsonDeserialize<object>(result2);
                    bool success2 = Convert.ToBoolean(((Dictionary<string, object>)json2)["success"]);
                    string message2 = Convert.ToString(((Dictionary<string, object>)json2)["message"]);
                    if (success2) uids.Add(uid);
                    if (success2 == true) worker.ReportProgress(index, string.Format("{0} {1}/{2}: 全景生成成功: {3}.", DateTime.Now.ToString("HH:mm:ss"), index, items.Length, uid));
                    else worker.ReportProgress(index, string.Format("{0} {1}/{2}: 全景生成失败: {3}", DateTime.Now.ToString("HH:mm:ss"), index, items.Length, message2));
                }
                // 全景制作完成
                worker.ReportProgress(++index, string.Format("{0} ----------------------\r\n{1}", DateTime.Now.ToString("HH:mm:ss"), string.Join("\r\n", uids.ToArray())));
            }
            catch (Exception ex) {
                MessageBox.Show(string.Format("提交全景失败！\r\n{0}\r\n{1}", ex.Message, ex.StackTrace), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 关于
        /// </summary>
        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("柳州市勘测院 -- DoDo", "(∩_∩)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        private void imageListView_SelectionChanged(object sender, EventArgs e)
        {
            // 列表联动
            dataGridViewPano.ClearSelection();
            foreach (ImageListViewItem item in imageListView.SelectedItems) {
                foreach (DataGridViewRow row in dataGridViewPano.Rows) {
                    if (row.DataBoundItem == item) { row.Selected = true; break; }
                }
            }

            ImageListViewItem sel = null;
            if (imageListView.SelectedItems.Count > 0) sel = imageListView.SelectedItems[0];
            //propertyGridEx.SelectedObject = sel;

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
        /// 删除
        /// </summary>
        private void imageListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                // 删除选中
                if (imageListView.SelectedItems.Count > 0) {
                    dataGridViewPano.DataSource = null;
                    for (int i = imageListView.SelectedItems.Count - 1; i >= 0; i--) {
                        imageListView.Items.Remove(imageListView.SelectedItems[i]);
                    }
                    dataGridViewPano.DataSource = imageListView.Items;
                }
            }
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_worker != null &&
                _worker.IsBusy &&
                _worker.WorkerSupportsCancellation &&
                !_worker.CancellationPending) {
                if (DialogResult.Yes == MessageBox.Show("是否终止处理？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                    _worker.CancelAsync();
                    return;
                }
                else { e.Cancel = true; return; }
            }
        }


    }
}
