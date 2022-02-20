using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinalHomework
{
    public partial class frmTips : Form
    {
        
        public frmTips(string szDate, string szContent)
        {
            InitializeComponent();
            labelDate.Text = szDate;
            labelContent.Text = szContent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }
    }
}
