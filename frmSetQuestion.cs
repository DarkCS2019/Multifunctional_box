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
    public partial class frmSetQuestion : Form
    {
        public frmSetQuestion(string username)
        {
            InitializeComponent();
            nameLabel.Text = username;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        static string dbPath = "user.db";
        static string connStr = "data source=" + dbPath;

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (question1Box.Text == "" || question2Box.Text == "")
            {
                errMsg.Text = "密保问题不能为空";
            }
            else
            {
                errMsg.Text = "加载中，请稍候";
                string update = "UPDATE 'main'.'userData' SET " +
                    "IsSetQuestion = 'true', " +
                    "Question1 = @question1, " +
                    "Question2 = @question2, " +
                    "Answer1 = @answer1, " +
                    "Answer2 = @answer2 " +
                    "WHERE Name = @name";
                SQLiteConnection conn = new SQLiteConnection(connStr);
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(update, conn);
                cmd.Parameters.AddWithValue("@name", nameLabel.Text);
                cmd.Parameters.AddWithValue("@question1", question1Box.Text);
                cmd.Parameters.AddWithValue("@question2", question2Box.Text);
                cmd.Parameters.AddWithValue("@answer1", answer1Box.Text);
                cmd.Parameters.AddWithValue("@answer2", answer2Box.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                this.DialogResult = DialogResult.OK;
                saveButton.Enabled = false;
            }
        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.saveButton_Click(sender, e);
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
