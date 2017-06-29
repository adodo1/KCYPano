using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PanoClient
{
    public partial class SelectPanosForm : Form
    {
        private List<string> _uids = new List<string>();
        /// <summary>
        /// 
        /// </summary>
        public List<string> UIDS
        {
            get { return _uids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public SelectPanosForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxPans.Text.Contains("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa") ||
                textBoxPans.Text.Trim() == "") return;

            string text = textBoxPans.Text;
            string[] lines = text.Replace("\r", "").Split('\n');
            _uids.Clear();
            foreach (string line in lines) {
                string uid = line.Trim();
                if (uid.Length != 32) continue;
                _uids.Add(uid);
            }
            if (_uids.Count == 0) return;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        /// <summary>
        /// 
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        /// <summary>
        /// 
        /// </summary>
        private void textBoxPans_Enter(object sender, EventArgs e)
        {
            if (textBoxPans.Text.Contains("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")) {
                textBoxPans.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                textBoxPans.Text = "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void textBoxPans_Leave(object sender, EventArgs e)
        {
            if (textBoxPans.Text.Trim() == "") {
                textBoxPans.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa#bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb#cccccccccccccccccccccccccccccccc".Replace("#", "\r\n");
                textBoxPans.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaption);
            }
        }
    }
}
