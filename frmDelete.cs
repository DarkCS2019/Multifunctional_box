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
    public partial class frmDelete : Form
    {
        private string connStr = "data source=user.db";
        private string m_szUser;

        public frmDelete(string username)
        {
            InitializeComponent();
            m_szUser = username;
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.FocusedItem == null || listView1.SelectedItems == null)
            {
                MessageBox.Show("请选中要删除的事件！");
                return;
            }

            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            string szId = this.listView1.FocusedItem.SubItems[0].Text;
            string sql = "DELETE FROM 'main'.'memo' WHERE id=@id";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", szId);
            cmd.ExecuteNonQuery();
            conn.Close();
            RefreshGrid();
            MessageBox.Show("删除成功！");
            this.DialogResult = DialogResult.OK;
        }

        private void RefreshGrid()
        {
            listView1.Items.Clear();
            string query = "SELECT * FROM 'main'.'memo' where User=@User";
            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@User", m_szUser);
            SQLiteDataReader sr = cmd.ExecuteReader();
            ListViewItem it;
            while (sr.Read())
            {
                it = new ListViewItem();
                it.Text = sr.GetValue(sr.GetOrdinal("id")).ToString();
                it.SubItems.Add(sr.GetValue(sr.GetOrdinal("Date")).ToString());
                it.SubItems.Add(sr.GetValue(sr.GetOrdinal("Content")).ToString());
                listView1.Items.Add(it);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}