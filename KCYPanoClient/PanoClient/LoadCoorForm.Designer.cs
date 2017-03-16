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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCoor = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSet);
            this.groupBox2.Controls.Add(this.buttonCancel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(351, 21);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 0;
            this.buttonSet.Text = "导入";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(432, 20);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCoor
            // 
            this.textBoxCoor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCoor.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxCoor.Location = new System.Drawing.Point(0, 0);
            this.textBoxCoor.Multiline = true;
            this.textBoxCoor.Name = "textBoxCoor";
            this.textBoxCoor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCoor.Size = new System.Drawing.Size(513, 233);
            this.textBoxCoor.TabIndex = 2;
            this.textBoxCoor.Text = "0\t24.3063861947961\t109.383596690577\t01\r\n1\t24.3081341427567\t109.384046109353\t02\r\n2" +
    "\t24.3095188151852\t109.386628347037\t03\r\n3\t24.3109181738095\t109.386237440079\t04";
            this.textBoxCoor.Enter += new System.EventHandler(this.textBoxCoor_Enter);
            this.textBoxCoor.Leave += new System.EventHandler(this.textBoxCoor_Leave);
            // 
            // LoadCoorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 290);
            this.Controls.Add(this.textBoxCoor);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadCoorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "坐标导入";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCoor;
        private System.Windows.Forms.Button buttonSet;
    }
}