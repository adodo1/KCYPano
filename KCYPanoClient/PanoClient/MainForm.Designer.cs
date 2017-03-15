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
            this.components = new System.ComponentModel.Container();
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
            this.imageListView = new PanoClient.ImageListView.ImageListView();
            this.propertyGridEx = new PanoClient.PropertyGridEx();
            this.MainMap = new PanoClient.Map();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(1058, 24);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 640);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1058, 22);
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1014, 17);
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
            this.splitContainer1.Panel1.Controls.Add(this.propertyGridEx);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MainMap);
            this.splitContainer1.Size = new System.Drawing.Size(1058, 616);
            this.splitContainer1.SplitterDistance = 238;
            this.splitContainer1.TabIndex = 2;
            // 
            // imageListView
            // 
            this.imageListView.ColumnHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.imageListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageListView.GroupHeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.imageListView.Location = new System.Drawing.Point(0, 284);
            this.imageListView.Name = "imageListView";
            this.imageListView.PersistentCacheDirectory = "";
            this.imageListView.PersistentCacheSize = ((long)(100));
            this.imageListView.Size = new System.Drawing.Size(238, 332);
            this.imageListView.TabIndex = 1;
            this.imageListView.SelectionChanged += new System.EventHandler(this.imageListView_SelectionChanged);
            this.imageListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imageListView_KeyDown);
            // 
            // propertyGridEx
            // 
            // 
            // 
            // 
            this.propertyGridEx.DocCommentDescription.AutoEllipsis = true;
            this.propertyGridEx.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridEx.DocCommentDescription.Location = new System.Drawing.Point(3, 19);
            this.propertyGridEx.DocCommentDescription.Name = "";
            this.propertyGridEx.DocCommentDescription.Size = new System.Drawing.Size(0, 52);
            this.propertyGridEx.DocCommentDescription.TabIndex = 1;
            this.propertyGridEx.DocCommentImage = null;
            // 
            // 
            // 
            this.propertyGridEx.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.propertyGridEx.DocCommentTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.propertyGridEx.DocCommentTitle.Location = new System.Drawing.Point(3, 3);
            this.propertyGridEx.DocCommentTitle.Name = "";
            this.propertyGridEx.DocCommentTitle.Size = new System.Drawing.Size(0, 0);
            this.propertyGridEx.DocCommentTitle.TabIndex = 0;
            this.propertyGridEx.DocCommentTitle.UseMnemonic = false;
            this.propertyGridEx.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridEx.HelpVisible = false;
            this.propertyGridEx.Location = new System.Drawing.Point(0, 0);
            this.propertyGridEx.Name = "propertyGridEx";
            this.propertyGridEx.Size = new System.Drawing.Size(238, 284);
            this.propertyGridEx.TabIndex = 0;
            this.propertyGridEx.ToolbarVisible = false;
            // 
            // 
            // 
            this.propertyGridEx.ToolStrip.AccessibleName = "工具栏";
            this.propertyGridEx.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.propertyGridEx.ToolStrip.AllowMerge = false;
            this.propertyGridEx.ToolStrip.AutoSize = false;
            this.propertyGridEx.ToolStrip.CanOverflow = false;
            this.propertyGridEx.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.propertyGridEx.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.propertyGridEx.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this.propertyGridEx.ToolStrip.Name = "";
            this.propertyGridEx.ToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.propertyGridEx.ToolStrip.Size = new System.Drawing.Size(215, 25);
            this.propertyGridEx.ToolStrip.TabIndex = 1;
            this.propertyGridEx.ToolStrip.TabStop = true;
            this.propertyGridEx.ToolStrip.Text = "PropertyGridToolBar";
            this.propertyGridEx.ToolStrip.Visible = false;
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
            this.MainMap.Size = new System.Drawing.Size(816, 616);
            this.MainMap.TabIndex = 0;
            this.MainMap.Zoom = 0D;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 662);
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
        private PropertyGridEx propertyGridEx;
        private PanoClient.ImageListView.ImageListView imageListView;
    }
}

