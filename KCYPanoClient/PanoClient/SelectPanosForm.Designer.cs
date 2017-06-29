namespace PanoClient
{
    partial class SelectPanosForm
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
            this.groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxPans = new System.Windows.Forms.TextBox();
            this.groupBoxBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBottom
            // 
            this.groupBoxBottom.Controls.Add(this.buttonCancel);
            this.groupBoxBottom.Controls.Add(this.buttonOK);
            this.groupBoxBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxBottom.Location = new System.Drawing.Point(0, 328);
            this.groupBoxBottom.Name = "groupBoxBottom";
            this.groupBoxBottom.Size = new System.Drawing.Size(293, 52);
            this.groupBoxBottom.TabIndex = 0;
            this.groupBoxBottom.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(216, 18);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(135, 18);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(65, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxPans
            // 
            this.textBoxPans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPans.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBoxPans.Location = new System.Drawing.Point(0, 0);
            this.textBoxPans.Multiline = true;
            this.textBoxPans.Name = "textBoxPans";
            this.textBoxPans.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPans.Size = new System.Drawing.Size(293, 328);
            this.textBoxPans.TabIndex = 1;
            this.textBoxPans.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\nbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb\r\nccccccccccccc" +
    "ccccccccccccccccccc";
            this.textBoxPans.Enter += new System.EventHandler(this.textBoxPans_Enter);
            this.textBoxPans.Leave += new System.EventHandler(this.textBoxPans_Leave);
            // 
            // SelectPanosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 380);
            this.Controls.Add(this.textBoxPans);
            this.Controls.Add(this.groupBoxBottom);
            this.MaximizeBox = false;
            this.Name = "SelectPanosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全景列表";
            this.groupBoxBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBottom;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxPans;
    }
}