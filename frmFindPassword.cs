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
    public partial class frmFindPassword : Form
    {
        public frmFindPassword()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        static string dbPath = "user.db";
        static string connStr = "data source=" + dbPath;
        private string password = "";

        private void nextStepButton_Click(object sender, EventArgs e)
        {
            if (nameBox.Text == "")
            {
                errMsg.Text = "请输入用户名";
            }
            else
            {
                string query = "SELECT * FROM 'main'.'userData' WHERE Name = @name";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", nameBox.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    SQLiteDataReader sr = cmd.ExecuteReader();
                    while (sr.Read())
                    {
                        bool checkIsSetQuestion = Convert.ToBoolean(sr.GetString(2));
                        if (checkIsSetQuestion == true)
                        {
                            question1Lable.Text = sr.GetString(3);
                            question2Lable.Text = sr.GetString(5);
                            errMsg.Text = "读取问题成功";
                            nextStepButton.Enabled = false;
                        }
                        else
                        {
                            errMsg.Text = "尚未设置密保问题，请返回";
                            nameBox.Text = "";
                        }
                    }
                    sr.Close();
                    conn.Close();
                }
                else
                {
                    errMsg.Text = "找不到此用户";
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (question1Lable.Text != "" && question2Lable.Text != "")
            {
                string read = "SELECT * FROM 'main'.'userData' WHERE " +
                    "Question1 = @question1 AND " +
                    "Question2 = @question2 AND " +
                    "Answer1 = @answer1 AND " +
                    "Answer2 = @answer2";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                conn.Open();
                SQLiteCommand cmd1 = new SQLiteCommand(read, conn);
                cmd1.Parameters.AddWithValue("@question1", question1Lable.Text);
                cmd1.Parameters.AddWithValue("@question2", question2Lable.Text);
                cmd1.Parameters.AddWithValue("@answer1", answer1Box.Text);
                cmd1.Parameters.AddWithValue("@answer2", answer2Box.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd1);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string query = "SELECT * FROM 'main'.'userData' WHERE Name = @name";
                    SQLiteCommand cmd2 = new SQLiteCommand(query, conn);
                    cmd2.Parameters.AddWithValue("@name", nameBox.Text);
                    SQLiteDataReader sr = cmd2.ExecuteReader();
                    while (sr.Read())
                    {
                        password = sr.GetString(1);
                    }
                    sr.Close();
                    conn.Close();
                    MessageBox.Show("你的密码是：" + password + "，这次要好好记住喔！", "提示");
                    this.DialogResult = DialogResult.OK;
                    saveButton.Enabled = false;
                }
                else
                {
                    errMsg.Text = "问题回答错误，请重新尝试";
                }
            }
            else
            {
                errMsg.Text = "请先输入用户名";
            }
        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.saveButton_Click(sender, e);
            }
        }

        private void question1Lable_Click(object sender, EventArgs e)
        {

        }
    }
}
