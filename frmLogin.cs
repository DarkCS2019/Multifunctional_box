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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        static string dbPath = "user.db";
        static string connStr = "data source=" + dbPath;

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "" || passwordBox.Text == "")
            {
                errMsg.Text = "请输入用户名或密码";
            }
            else
            {
                string query = "SELECT * FROM 'main'.'userData' WHERE Name = @name AND Password = @password";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", nameBox.Text);
                cmd.Parameters.AddWithValue("@password", passwordBox.Text);
                conn.Close();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count>0)
                {
                    errMsg.Text = "登入成功";
                    loginButton.Enabled = false;
                    string username = this.nameBox.Text;
                    frmMain form2 = new frmMain(username);
                    this.Visible = false;
                    form2.ShowDialog(this);

                    if (form2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        nameBox.Text = "";
                        passwordBox.Text = "";
                        errMsg.Text = "";
                        loginButton.Enabled = true;
                        this.Visible = true;
                    }
                    else
                    {

                    }
                }
                else
                {
                    errMsg.Text = "登入失败";
                }
            }
        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loginButton_Click(sender, e);
            }
        }

        private void findPasswordButton_Click(object sender, EventArgs e)
        {
            frmFindPassword form6 = new frmFindPassword();
            form6.ShowDialog(this);

            if (form6.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (form6.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
            else
            {

            }
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            frmCreateAccount form5 = new frmCreateAccount();
            form5.ShowDialog(this);

            if (form5.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (form5.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
            else
            {

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}