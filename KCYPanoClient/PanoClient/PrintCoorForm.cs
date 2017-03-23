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
    public partial class PrintCoorForm : Form
    {
        public PrintCoorForm(string text)
        {
            InitializeComponent();
            textBoxCoors.Text = text;
        }
    }
}
