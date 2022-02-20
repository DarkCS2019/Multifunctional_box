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
using System.Threading;
using System.Runtime.InteropServices;
using ChineseCalendar;



namespace FinalHomework
{
    public partial class frmMain : Form
    {
        private string m_szUser;
        public frmMain(string username)
        {
            InitializeComponent();
            userNameLable.Text = username;
            m_szUser = username;

            calendar11.Call_button();

            logoutButton.DialogResult = DialogResult.OK;

            string query = "SELECT * FROM 'main'.'userData' WHERE Name = @name";
            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", username);
            SQLiteDataReader sr = cmd.ExecuteReader();
            while (sr.Read())
            {
                bool checkIsSetQuestion = Convert.ToBoolean(sr.GetString(2));
                if (checkIsSetQuestion == false)
                {
                    MessageBox.Show("为了确保您的帐户安全，请尽快设置密保问题！", "安全提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            sr.Close();
            conn.Close();

            label3.Text = 0.ToString();
        }

        static string dbPath = "user.db";
        static string connStr = "data source=" + dbPath;

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            string username = this.userNameLable.Text;
            frmResetPassword form4 = new frmResetPassword(username);
            form4.ShowDialog(this);

            if (form4.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                
            }
            else if (form4.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                
            }
            else
            {
                
            }
        }

        private void setPasswordQuestion_Click(object sender, EventArgs e)
        {
            string username = this.userNameLable.Text;
            frmSetQuestion form3 = new frmSetQuestion(username);
            form3.ShowDialog(this);

            if (form3.DialogResult == System.Windows.Forms.DialogResult.OK)
            {

            }
            else if (form3.DialogResult == System.Windows.Forms.DialogResult.Cancel)
            {

            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAdd form = new frmAdd(m_szUser);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmDelete form = new frmDelete(m_szUser);
            if (form.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }
        /// <summary>
        /// //////////////////
        /// </summary>
        private void RefreshGrid()
        {
            string szDate = string.Format("{0}-{1:D2}%", calendar11.GetSelectedYear(), calendar11.GetSelectedMonth());
            listView1.Items.Clear();
            string query = "SELECT * FROM 'main'.'memo' WHERE Date like @Date and User=@User";
            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Date", szDate);
            cmd.Parameters.AddWithValue("@User", m_szUser);
            SQLiteDataReader sr = cmd.ExecuteReader();
            ListViewItem it;
            while (sr.Read())
            {
                it = new ListViewItem();
                it.Text = sr.GetValue(sr.GetOrdinal("Date")).ToString();
                it.SubItems.Add(sr.GetValue(sr.GetOrdinal("Content")).ToString());
                listView1.Items.Add(it);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer2.Interval = 1000;
            timer2.Start();
            timer2.Tick += timer2_Tick;
            calendar11.UXEvent += new EventHandler(uxEvent);
            RefreshGrid();
        }

        private void uxEvent(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string szDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "%";
            string query = "SELECT * FROM 'main'.'memo' WHERE Date like @Date and Done=0 and User=@User";
            SQLiteConnection conn = new SQLiteConnection(connStr);
            conn.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            cmd.Parameters.AddWithValue("@Date", szDate);
            cmd.Parameters.AddWithValue("@User", m_szUser);
            SQLiteDataReader sr = cmd.ExecuteReader();
            while (sr.Read())
            {
                timer2.Stop();
                string szId = sr.GetValue(sr.GetOrdinal("id")).ToString();
                string szTime = sr.GetValue(sr.GetOrdinal("Date")).ToString();
                string szContent = sr.GetValue(sr.GetOrdinal("Content")).ToString();
                frmTips form = new frmTips(szTime, szContent);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string sql = "UPDATE 'main'.'memo' SET Done=@Done WHERE id=@id";
                    SQLiteCommand cmd1 = new SQLiteCommand(sql, conn);
                    cmd1.Parameters.AddWithValue("@Done", 1);
                    cmd1.Parameters.AddWithValue("@id", szId);
                    cmd1.ExecuteNonQuery();
                }
                timer2.Start();
            }
            conn.Close();
        }



        //Clock
        private int Timer;              //用户设置的倒计时的时间
        private DateTime startTime;     //用来保存开始番茄钟的时间
        private bool flag = true;      //用来控制是否保存数据到本地
        private const float op = 0.3f;  //设置变量，使透明度为30%
        int hours;                      //保存转换后的小时数
        int min;                        //保存分钟数
        int second;                     //保存秒数

        private void Button1_Click(object sender, EventArgs e)
        {
            #region 初始化一些参数
            startTime = DateTime.Now.ToLocalTime();             //记录此次番茄钟开始时间，用来后期数据保存
            Timer = Convert.ToInt32(numericUpDown1.Text) * 60;  //将用户设置的时间变为以秒为单位
            button_stop.Text = "暂停计时";
            timer1.Enabled = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = Timer;
            progressBar1.Step = 1;
            #endregion

            #region 番茄钟运行时变为半透明无边框样式
            this.FormBorderStyle = FormBorderStyle.None;    //窗体无边框
            this.Opacity = op;
            #endregion
        }
        /// <summary>
        /// 用计时器来控制实现 时间的减少
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Timer > 0)
            {
                Timer -= 1;
                hours = Timer / 3600;
                min = (Timer - 3600 * hours) / 60;
                second = Timer % 60;
                label4.Text = hours.ToString() + "h" + min.ToString() + "m" + second.ToString() + "s";
                progressBar1.Value = Timer;
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("时间到了，休息一会吧！");
                SaveDate();
                //返回初始界面
                timer1.Enabled = false;
                button_stop.Text = "暂停计时";
                Timer = 0;
                progressBar1.Value = 0;
                this.Opacity = 1;
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }


        private void SaveDate()
        {
            int i = Convert.ToInt32(label3.Text);
            i += 1;
            label3.Text = i.ToString();
            if (flag)
            {
                string directoryPath = @"C:\TomatoDate";//定义一个路径变量
                string filePath = "TomatoDate.txt";//定义一个文件路径变量
                if (!Directory.Exists(directoryPath))//如果路径不存在
                {
                    Directory.CreateDirectory(directoryPath);//创建一个路径的文件夹
                }
                StreamWriter sw = new StreamWriter(Path.Combine(directoryPath, filePath), true);//打开文件，并设定为追加数据
                sw.WriteLine("开始时间" + startTime.ToString() +
                             "结束时间" + DateTime.Now.ToLocalTime().ToString() +
                             "专注时间" + numericUpDown1.Text.ToString() + "分钟");
                sw.WriteLine("——————————————————————————————————————————————————————————————");
                sw.Flush();
                sw.Close();
            }
        }

        /// <summary>
        /// 控制暂停和恢复计时 按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            if (button_stop.Text == "暂停计时")
            {
                timer1.Stop();
                button_stop.Text = "恢复计时";
            }
            else
            {
                timer1.Start();
                button_stop.Text = "暂停计时";
            }
        }
        /// <summary>
        /// 放弃本次后将一切回归初始值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button_stop.Text = "暂停计时";
            Timer = 0;
            progressBar1.Value = 0;
            this.Opacity = 1;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }
    }
}
