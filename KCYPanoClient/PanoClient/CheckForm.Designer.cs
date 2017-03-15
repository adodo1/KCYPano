namespace PanoClient
{
    partial class CheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.dataGridViewPano = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHeading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPano)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonSubmit);
            this.groupBox.Controls.Add(this.buttonCancel);
            this.groupBox.Controls.Add(this.textBoxUrl);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox.Location = new System.Drawing.Point(0, 292);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(934, 53);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
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
            this.dataGridViewPano.Size = new System.Drawing.Size(934, 292);
            this.dataGridViewPano.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "地址：";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUrl.Location = new System.Drawing.Point(53, 20);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(755, 21);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.Text = "http://localhost/pano/service.svc";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(871, 18);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(51, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubmit.Location = new System.Drawing.Point(814, 19);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(51, 23);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.FillWeight = 20F;
            this.ColumnName.HeaderText = "全景名称";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnCategory
            // 
            this.ColumnCategory.DataPropertyName = "category";
            this.ColumnCategory.FillWeight = 8F;
            this.ColumnCategory.HeaderText = "分类";
            this.ColumnCategory.Name = "ColumnCategory";
            // 
            // ColumnLat
            // 
            this.ColumnLat.DataPropertyName = "lat";
            this.ColumnLat.FillWeight = 15F;
            this.ColumnLat.HeaderText = "纬度";
            this.ColumnLat.Name = "ColumnLat";
            // 
            // ColumnLng
            // 
            this.ColumnLng.DataPropertyName = "lng";
            this.ColumnLng.FillWeight = 15F;
            this.ColumnLng.HeaderText = "经度";
            this.ColumnLng.Name = "ColumnLng";
            // 
            // ColumnDate
            // 
            this.ColumnDate.DataPropertyName = "date";
            this.ColumnDate.FillWeight = 10F;
            this.ColumnDate.HeaderText = "日期";
            this.ColumnDate.Name = "ColumnDate";
            // 
            // ColumnHeading
            // 
            this.ColumnHeading.DataPropertyName = "heading";
            this.ColumnHeading.FillWeight = 7F;
            this.ColumnHeading.HeaderText = "角度";
            this.ColumnHeading.Name = "ColumnHeading";
            // 
            // ColumnDes
            // 
            this.ColumnDes.DataPropertyName = "describe";
            this.ColumnDes.FillWeight = 15F;
            this.ColumnDes.HeaderText = "描述";
            this.ColumnDes.Name = "ColumnDes";
            // 
            // ColumnInfo
            // 
            this.ColumnInfo.DataPropertyName = "info";
            this.ColumnInfo.FillWeight = 20F;
            this.ColumnInfo.HeaderText = "信息";
            this.ColumnInfo.Name = "ColumnInfo";
            // 
            // ColumnFile
            // 
            this.ColumnFile.DataPropertyName = "file";
            this.ColumnFile.HeaderText = "文件";
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.Visible = false;
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 345);
            this.Controls.Add(this.dataGridViewPano);
            this.Controls.Add(this.groupBox);
            this.Name = "CheckForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提交全景";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPano)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dataGridViewPano;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label label1;
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