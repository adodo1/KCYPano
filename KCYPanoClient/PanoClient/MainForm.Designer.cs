namespace PanoClient
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadIMG = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadCoor = new System.Windows.Forms.ToolStripMenuItem();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSubmit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewPano = new System.Windows.Forms.DataGridView();
            this.imageListView = new PanoClient.ImageListView.ImageListView();
            this.MainMap = new PanoClient.Map();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPano)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.工具TToolStripMenuItem,
            this.toolStripMenuItemAbout});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1157, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoadIMG,
            this.toolStripMenuItemLoadCoor});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemFile.Text = "文件(&F)";
            // 
            // toolStripMenuItemLoadIMG
            // 
            this.toolStripMenuItemLoadIMG.Name = "toolStripMenuItemLoadIMG";
            this.toolStripMenuItemLoadIMG.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItemLoadIMG.Text = "加载全景图";
            this.toolStripMenuItemLoadIMG.Click += new System.EventHandler(this.toolStripMenuItemLoadIMG_Click);
            // 
            // toolStripMenuItemLoadCoor
            // 
            this.toolStripMenuItemLoadCoor.Name = "toolStripMenuItemLoadCoor";
            this.toolStripMenuItemLoadCoor.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItemLoadCoor.Text = "批量导入坐标";
            this.toolStripMenuItemLoadCoor.Click += new System.EventHandler(this.toolStripMenuItemLoadCoor_Click);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSubmit});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // toolStripMenuItemSubmit
            // 
            this.toolStripMenuItemSubmit.Name = "toolStripMenuItemSubmit";
            this.toolStripMenuItemSubmit.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItemSubmit.Text = "提交";
            this.toolStripMenuItemSubmit.Click += new System.EventHandler(this.toolStripMenuItemSubmit_Click);
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemAbout.Text = "关于(&A)";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelInfo,
            this.toolStripStatusLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 637);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1157, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            this.toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            this.toolStripStatusLabelInfo.Size = new System.Drawing.Size(29, 17);
            this.toolStripStatusLabelInfo.Text = "就绪";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1113, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "『=DoDo=』";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "属性";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "地图";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imageListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1157, 613);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.MainMap);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridViewPano);
            this.splitContainer2.Size = new System.Drawing.Size(915, 613);
            this.splitContainer2.SplitterDistance = 429;
            this.splitContainer2.TabIndex = 3;
            // 
            // dataGridViewPano
            // 
            this.dataGridViewPano.AllowUserToAddRows = false;
            this.dataGridViewPano.AllowUserToDeleteRows = false;
            this.dataGridViewPano.AllowUserToOrderColumns = true;
            this.dataGridViewPano.AllowUserToResizeRows = false;
            this.dataGridViewPano.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPano.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewPano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnCategory,
            this.ColumnLat,
            this.ColumnLng,
            this.ColumnDate,
            this.ColumnHeading,
            this.ColumnDes,
            this.ColumnInfo,
            this.ColumnFile});
            this.dataGridViewPano.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPano.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPano.Name = "dataGridViewPano";
            this.dataGridViewPano.ReadOnly = true;
            this.dataGridViewPano.RowHeadersVisible = false;
            this.dataGridViewPano.RowTemplate.Height = 23;
            this.dataGridViewPano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPano.Size = new System.Drawing.Size(915, 180);
            this.dataGridViewPano.TabIndex = 2;
            // 
            // imageListView
            // 
            this.imageListView.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.imageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView.GroupHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.imageListView.Location = new System.Drawing.Point(0, 0);
            this.imageListView.Name = "imageListView";
            this.imageListView.PersistentCacheDirectory = "";
            this.imageListView.PersistentCacheSize = ((long)(100));
            this.imageListView.Size = new System.Drawing.Size(238, 613);
            this.imageListView.TabIndex = 1;
            this.imageListView.SelectionChanged += new System.EventHandler(this.imageListView_SelectionChanged);
            this.imageListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageListView_KeyDown);
            // 
            // MainMap
            // 
            this.MainMap.Bearing = 0F;
            this.MainMap.CanDragMap = true;
            this.MainMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMap.GrayScaleMode = false;
            this.MainMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMap.LevelsKeepInMemmory = 5;
            this.MainMap.Location = new System.Drawing.Point(0, 0);
            this.MainMap.MarkersEnabled = true;
            this.MainMap.MaxZoom = 2;
            this.MainMap.MinZoom = 2;
            this.MainMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMap.Name = "MainMap";
            this.MainMap.NegativeMode = false;
            this.MainMap.PolygonsEnabled = true;
            this.MainMap.RetryLoadTile = 0;
            this.MainMap.RoutesEnabled = true;
            this.MainMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMap.ShowTileGridLines = false;
            this.MainMap.Size = new System.Drawing.Size(915, 429);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 0D;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "PanoName";
            this.ColumnName.FillWeight = 20F;
            this.ColumnName.HeaderText = "全景名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.DataPropertyName = "category";
            this.ColumnCategory.FillWeight = 8F;
            this.ColumnCategory.HeaderText = "分类";
            this.ColumnCategory.Name = "ColumnCategory";
            this.ColumnCategory.ReadOnly = true;
            // 
            // ColumnLat
            // 
            this.ColumnLat.DataPropertyName = "PanoLat";
            this.ColumnLat.FillWeight = 15F;
            this.ColumnLat.HeaderText = "纬度";
            this.ColumnLat.Name = "ColumnLat";
            this.ColumnLat.ReadOnly = true;
            // 
            // ColumnLng
            // 
            this.ColumnLng.DataPropertyName = "lng";
            this.ColumnLng.FillWeight = 15F;
            this.ColumnLng.HeaderText = "经度";
            this.ColumnLng.Name = "ColumnLng";
            this.ColumnLng.ReadOnly = true;
            // 
            // ColumnDate
            // 
            this.ColumnDate.DataPropertyName = "date";
            this.ColumnDate.FillWeight = 10F;
            this.ColumnDate.HeaderText = "日期";
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.ReadOnly = true;
            // 
            // ColumnHeading
            // 
            this.ColumnHeading.DataPropertyName = "heading";
            this.ColumnHeading.FillWeight = 7F;
            this.ColumnHeading.HeaderText = "角度";
            this.ColumnHeading.Name = "ColumnHeading";
            this.ColumnHeading.ReadOnly = true;
            // 
            // ColumnDes
            // 
            this.ColumnDes.DataPropertyName = "describe";
            this.ColumnDes.FillWeight = 15F;
            this.ColumnDes.HeaderText = "描述";
            this.ColumnDes.Name = "ColumnDes";
            this.ColumnDes.ReadOnly = true;
            // 
            // ColumnInfo
            // 
            this.ColumnInfo.DataPropertyName = "info";
            this.ColumnInfo.FillWeight = 20F;
            this.ColumnInfo.HeaderText = "信息";
            this.ColumnInfo.Name = "ColumnInfo";
            this.ColumnInfo.ReadOnly = true;
            // 
            // ColumnFile
            // 
            this.ColumnFile.DataPropertyName = "file";
            this.ColumnFile.HeaderText = "文件";
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.ReadOnly = true;
            this.ColumnFile.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 659);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全景客户端";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPano)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadIMG;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadCoor;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSubmit;
        private Map MainMap;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PanoClient.ImageListView.ImageListView imageListView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewPano;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLng;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHeading;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
    }
}

