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
    public partial class LoadCoorForm : Form
    {
        private DataTable _coorsTable = null;

        public LoadCoorForm(DataTable coorsTable)
        {
            InitializeComponent();

            _coorsTable = coorsTable;
            dataGridViewCoor.DataSource = _coorsTable;
        }
        /// <summary>
        /// 
        /// </summary>
        private void textBoxCoor_Enter(object sender, EventArgs e)
        {
            if (textBoxCoor.Text.Contains("24.3063861947961")) {
                textBoxCoor.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
                textBoxCoor.Text = "";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void textBoxCoor_Leave(object sender, EventArgs e)
        {
            if (textBoxCoor.Text.Trim() == "") {
                textBoxCoor.Text = "0	24.3063861947961	109.383596690577	01#1	24.3081341427567	109.384046109353	02#2	24.3095188151852	109.386628347037	03#3	24.3109181738095	109.386237440079	04".Replace("#", "\r\n");
                textBoxCoor.ForeColor = Color.FromKnownColor(KnownColor.InactiveCaption);
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {


            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        /// <summary>
        /// 取消
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        private void textBoxCoor_Validated(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 导入坐标
        /// </summary>
        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (textBoxCoor.Text.Contains("24.3063861947961") ||
                textBoxCoor.Text.Trim() == "") return;

            UpdateTable(textBoxCoor.Text);
        }
        /// <summary>
        /// 更新坐标到对应的图片中
        /// </summary>
        /// <param name="text"></param>
        private void UpdateTable(string text)
        {
            text = text.Replace("\r", "");
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++) {
                // 解析每一行
                string line = lines[i];
                string[] vars = line.Split('\t');
                double lat = 0;
                double lng = 0;

                foreach (string v in vars) {
                    double d = 0;
                    if (double.TryParse(v, out d) == false) continue;
                    // 用简单的方式判断经纬度
                    if (0 <= d && d <= 90) lat = d;                 // 纬度
                    else if (100 <= d && d <= 180) lng = d;         // 经度
                }

                if (lat == 0 || lng == 0) continue;
                if (_coorsTable.Rows.Count <= i) continue;
                _coorsTable.Rows[i]["lat"] = lat;
                _coorsTable.Rows[i]["lng"] = lng;
            }

            dataGridViewCoor.Update();
        }
    }
}
