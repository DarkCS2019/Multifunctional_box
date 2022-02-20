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
    public partial class frmResetPassword : Form
    {
        public frmResetPassword(string username)
        {
            InitializeComponent();
            nameLabel.Text = username;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        static string dbPath = "user.db";
        static string connStr = "data source=" + dbPath;

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (oldPasswordBox.Text == "" || newPasswordBox1.Text == "" || newPasswordBox2.Text == "")
            {
                errMsg.Text = "请输入全部內容";
            }
            else
            {
                if (newPasswordBox1.Text == newPasswordBox2.Text)
                {
                    string query = "SELECT * FROM 'main'.'userData' WHERE Name = @name AND Password = @password";
                    SQLiteConnection conn = new SQLiteConnection(connStr);
                    conn.Open();
                    SQLiteCommand cmd1 = new SQLiteCommand(query, conn);
                    cmd1.Parameters.AddWithValue("@name", nameLabel.Text);
                    cmd1.Parameters.AddWithValue("@password", oldPasswordBox.Text);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        errMsg.Text = "加载中，请稍候";
                        string update = "UPDATE 'main'.'userData' SET Password = @password WHERE Name = @name";
                        SQLiteCommand cmd2 = new SQLiteCommand(update, conn);
                        cmd2.Parameters.AddWithValue("@name", nameLabel.Text);
                        cmd2.Parameters.AddWithValue("@password", newPasswordBox1.Text);
                        cmd2.ExecuteNonQuery();
                        conn.Close();
                        this.DialogResult = DialogResult.OK;
                        saveButton.Enabled = false;
                    }
                    else
                    {
                        errMsg.Text = "用户名和旧密码不匹配";
                    }
                }
                else
                {
                    errMsg.Text = "两次输入的新密码不一致";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}