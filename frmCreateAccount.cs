using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace FinalHomework
{
    public partial class frmCreateAccount : Form
    {
        public frmCreateAccount()
        {
            InitializeComponent();
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        static string dbPath = "user.db";
        static string connStr = "data source=" + dbPath;

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool error = false;
            if (nameBox.Text == "" || passwordBox1.Text == "" || passwordBox2.Text == "")
            {
                errMsg.Text = "请输入用户名或密码";
            }
            else
            {
                if (passwordBox1.Text == passwordBox2.Text)
                {
                    errMsg.Text = "加载中，请稍候";
                    string insert = "INSERT INTO 'main'.'userData' (Name, Password, IsSetQuestion) VALUES (@name, @password, 'false')";
                    SQLiteConnection conn = new SQLiteConnection(connStr);
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(insert, conn);
                    cmd.Parameters.AddWithValue("@name", nameBox.Text);
                    cmd.Parameters.AddWithValue("@password", passwordBox1.Text);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception err)
                    {
                        errMsg.Text = "用户名已被注册，请更改";
                        error = true;
                    }
                    if (error == false)
                    {
                        conn.Close();
                        this.DialogResult = DialogResult.OK;
                        saveButton.Enabled = false;
                        MessageBox.Show("注册成功", "提示");
                    }
                }
                else
                {
                    errMsg.Text = "两次输入的密码不一致";
                }
            }
        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.saveButton_Click(sender, e);
            }
        }
    }
}