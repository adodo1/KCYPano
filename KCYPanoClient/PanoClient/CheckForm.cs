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
    public partial class CheckForm : Form
    {
        private DataTable _table = null;
        public CheckForm(DataTable table)
        {
            InitializeComponent();
            _table = table;
            dataGridViewPano.DataSource = _table;
        }
        /// <summary>
        /// 提交
        /// </summary>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 取消
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }




    }
}
