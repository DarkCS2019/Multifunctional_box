using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace FinalHomework
{
    public partial class frmAdd : Form
    {
        private string connStr = "data source=user.db";
        private string m_szUser;
        public frmAdd(string username)
        {
            InitializeComponent();
            m_szUser = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("请输入事件！");
                return;
            }

            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            string szDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string szTime = dateTimePicker2.Value.ToString("HH:mm:ss");
            string update = "INSERT INTO 'main'.'memo'(Date,Content,User,Done) VALUES(@Date,@Content,@User,@Done)";
            SQLiteCommand cmd = new SQLiteCommand(update, conn);
            cmd.Parameters.AddWithValue("@Date", szDate + " " + szTime);
            cmd.Parameters.AddWithValue("@Content", textBox1.Text);
            cmd.Parameters.AddWithValue("@User", m_szUser);
            cmd.Parameters.AddWithValue("@Done", 0);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("添加成功！");
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}