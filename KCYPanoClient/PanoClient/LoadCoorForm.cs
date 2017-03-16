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
        public List<double[]> Coors = new List<double[]>();
        public LoadCoorForm()
        {
            InitializeComponent();
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
        /// 取消
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        /// <summary>
        /// 导入坐标
        /// </summary>
        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (textBoxCoor.Text.Contains("24.3063861947961") ||
                textBoxCoor.Text.Trim() == "") return;
            Coors = GetCoors(textBoxCoor.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        /// <summary>
        /// 解析坐标组
        /// </summary>
        /// <param name="text"></param>
        private List<double[]> GetCoors(string text)
        {
            List<double[]> result = new List<double[]>();
            text = text.Replace("\r", "");
            string[] lines = text.Split('\n');
            for (int i = 0; i < lines.Length; i++) {
                // 解析每一行
                string line = lines[i];
                string[] vars = line.Split('\t');
                double lat = 0;
                double lng = 0;
                // 
                foreach (string v in vars) {
                    double d = 0;
                    if (double.TryParse(v, out d) == false) continue;
                    // 用简单的方式判断经纬度
                    if (0 <= d && d <= 90) lat = d;                 // 纬度
                    else if (100 <= d && d <= 180) lng = d;         // 经度
                }
                if (lat == 0 || lng == 0) continue;
                result.Add(new double[] { lat, lng });
            }
            return result;
        }
    }
}
