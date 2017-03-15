namespace PanoClient
{
    partial class LoadCoorForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxCoor = new System.Windows.Forms.TextBox();
            this.dataGridViewCoor = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSet = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewCoor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSet);
            this.groupBox2.Controls.Add(this.buttonOK);
            this.groupBox2.Controls.Add(this.buttonCancel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(338, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(549, 20);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(468, 21);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxCoor
            // 
            this.textBoxCoor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCoor.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxCoor.Location = new System.Drawing.Point(338, 0);
            this.textBoxCoor.Multiline = true;
            this.textBoxCoor.Name = "textBoxCoor";
            this.textBoxCoor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCoor.Size = new System.Drawing.Size(630, 233);
            this.textBoxCoor.TabIndex = 2;
            this.textBoxCoor.Text = "0\t24.3063861947961\t109.383596690577\t01\r\n1\t24.3081341427567\t109.384046109353\t02\r\n2" +
    "\t24.3095188151852\t109.386628347037\t03\r\n3\t24.3109181738095\t109.386237440079\t04";
            this.textBoxCoor.Enter += new System.EventHandler(this.textBoxCoor_Enter);
            this.textBoxCoor.Leave += new System.EventHandler(this.textBoxCoor_Leave);
            this.textBoxCoor.Validated += new System.EventHandler(this.textBoxCoor_Validated);
            // 
            // dataGridViewCoor
            // 
            this.dataGridViewCoor.AllowUserToAddRows = false;
            this.dataGridViewCoor.AllowUserToDeleteRows = false;
            this.dataGridViewCoor.AllowUserToOrderColumns = true;
            this.dataGridViewCoor.AllowUserToResizeRows = false;
            this.dataGridViewCoor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCoor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewCoor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnLat,
            this.ColumnLng,
            this.ColumnFile});
            this.dataGridViewCoor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCoor.Location = new System.Drawing.Point(3, 17);
            this.dataGridViewCoor.Name = "dataGridViewCoor";
            this.dataGridViewCoor.RowHeadersVisible = false;
            this.dataGridViewCoor.RowTemplate.Height = 23;
            this.dataGridViewCoor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCoor.Size = new System.Drawing.Size(332, 270);
            this.dataGridViewCoor.TabIndex = 0;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "name";
            this.ColumnName.HeaderText = "图片名称";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnLat
            // 
            this.ColumnLat.DataPropertyName = "lat";
            this.ColumnLat.HeaderText = "纬度";
            this.ColumnLat.Name = "ColumnLat";
            // 
            // ColumnLng
            // 
            this.ColumnLng.DataPropertyName = "lng";
            this.ColumnLng.HeaderText = "经度";
            this.ColumnLng.Name = "ColumnLng";
            // 
            // ColumnFile
            // 
            this.ColumnFile.DataPropertyName = "file";
            this.ColumnFile.HeaderText = "文件";
            this.ColumnFile.Name = "ColumnFile";
            this.ColumnFile.Visible = false;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(6, 20);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 0;
            this.buttonSet.Text = "<< 导入";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // LoadCoorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 290);
            this.Controls.Add(this.textBoxCoor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LoadCoorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "坐标导入";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCoor;
        private System.Windows.Forms.DataGridView dataGridViewCoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLng;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFile;
        private System.Windows.Forms.Button buttonSet;
    }
}