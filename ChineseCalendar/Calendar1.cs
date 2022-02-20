using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseCalendar
{
    public partial class Calendar1 : UserControl
    {
        private DateTime dtNow = DateTime.Now;              //初始化当天日期
        private int daysOfMonth = 30;                       //初始化每月天数
        private int weekOfFirstDay = 1;                     //初始化某月第一天的星期
        private int selectYear;                             //初始化选择年份
        private int selectMonth;                            //初始化选择月份
        private DateTime dtInfo = DateTime.Now;             //初始化日期信息
        private string[,] dateArray = new string[7, 6];     //记录日期信息 a
        private bool flag = true;                           //标记是否重绘panel

        //添加事件代理
        public event EventHandler UXEvent;

        public Calendar1()
        {
            InitializeComponent();
            DrawControls();
        }
        private void Calender_Load(object sender, EventArgs e)
        {
            Control.ControlCollection controls = panelMonthInfo.Controls;
        }

        #region 绘制控件
        //绘制控件
        private void DrawControls()
        {

            for (int i = 1949; i <= 2049; i++)
            {
                cmbSelectYear.Items.Add(i);
                if (i == dtNow.Year)
                {
                    cmbSelectYear.SelectedItem = i;
                    selectYear = i;
                }
            }
            for (int i = 1; i <= 12; i++)
            {
                cmbSelectMonth.Items.Add(i);
                if (i == dtNow.Month)
                {
                    cmbSelectMonth.SelectedItem = i;
                    selectMonth = i;
                }
            }
            panelMonthInfo.Controls.Add(btnToday);
            panelMonthInfo.Controls.Add(lblMonth);
            panelMonthInfo.Controls.Add(lblYear);
            panelMonthInfo.Controls.Add(cmbSelectYear);
            panelMonthInfo.Controls.Add(cmbSelectMonth);
        }

        #endregion

        public int GetSelectedYear()
        {
            return selectYear;
        }

        public int GetSelectedMonth()
        {
            return selectMonth;
        }

        //主窗体绘制月历
        private void panelMonthInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var pen = new Pen(Color.FromArgb(128, 128, 0), 1);
            g.FillRectangle(new SolidBrush(Color.FromArgb(42, 42, 42)), 10, 45, 570, 435);  //绘制月历显示区域,背景为白色

            //画横线，日期区有六条横线(一个月最多有五周)
            g.DrawLine(pen, 10, 45, 570, 45);
            g.DrawLine(pen, 10, 75, 570, 75);
            for (int i = 1; i < 7; i++)
            {
                g.DrawLine(pen, 10, 75 + 60 * i, 570, 75 + 60 * i);
            }


            //画竖线，日期区有八条竖线(一周有七天)
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(pen, 10 + 80 * i, 45, 10 + 80 * i, 435);
            }



            var solidBrushWeekday = new SolidBrush(Color.FromArgb(212, 229, 129));
            var solidBrushWeekend = new SolidBrush(Color.Chocolate);
            g.DrawString("日", new Font("宋体", 12), solidBrushWeekend, 35, 50);
            g.DrawString("一", new Font("宋体", 12), solidBrushWeekday, 115, 50);
            g.DrawString("二", new Font("宋体", 12), solidBrushWeekday, 195, 50);
            g.DrawString("三", new Font("宋体", 12), solidBrushWeekday, 275, 50);
            g.DrawString("四", new Font("宋体", 12), solidBrushWeekday, 355, 50);
            g.DrawString("五", new Font("宋体", 12), solidBrushWeekday, 435, 50);
            g.DrawString("六", new Font("宋体", 12), solidBrushWeekend, 515, 50);

            if (flag)//判断是否需要全部刷新
            {
                GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);//此方法是根据给出的年份和月份计算当月的第一天的星期,和当月的总天数
                DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month); ;
            }
        }

        //当点选不同月份时，更新日历
        private void cmbSelectMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectMonth = sender as ComboBox;          //从选择框中获得所选择的月份
            selectMonth = (int)cmbSelectMonth.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
            //将消息传给主界面
            if (UXEvent != null)
            {
                UXEvent(this, e);
            }
        }

        //当点选不同年份时，更新日历
        private void cmbSelectYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectYear = sender as ComboBox;
            selectYear = (int)cmbSelectYear.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        //点击"今天"按钮，刷新日历
        private void btnToday_Click(object sender, EventArgs e)
        {
            flag = true;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
            DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
            dtInfo = dtNow;
        }

        public void Call_button()
        {
            this.btnToday.Enabled = true;
            btnToday_Click((object)btnToday, new EventArgs());
        }

        //绘制月历日期
        private void DrawDateNum(int firstDayofWeek, int endMonthDay, int year, int month)
        {
            //获取当前时间
            DateTime dtNow = DateTime.Parse(DateTime.Now.ToShortDateString());

            var font = new Font("", 14);
            var solidBrushWeekdays = new SolidBrush(Color.FromArgb(212, 229, 129));
            var solidBrushWeekend = new SolidBrush(Color.Chocolate);
            var solidBrushHoliday = new SolidBrush(Color.BurlyWood);
            Graphics g = panelMonthInfo.CreateGraphics();
            int num = 1;

            for (int j = 0; j < 6; j++)//这个月的第j+1周
            {
                for (int i = 0; i < 7; i++)//这个月的第i+1天
                {
                    if (j == 0 && i < firstDayofWeek) //定义当月第一天的星期的位置
                    {
                        continue;
                    }
                    else
                    {
                        if (num > endMonthDay) //定义当月最后一天的位置
                        {
                            break;
                        }
                        string cMonth = null;
                        string cDay = null;
                        string cHoliday = null;
                        string ccHoliday = null;

                        if (i > 0 && i < 6)
                        {
                            DateTime dt = DateTime.Parse(year + "-" + month + "-" + num);
                            TimeSpan ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();

                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (15 + 80 * i), (85 + 60 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);

                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),
                                             solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                            }
                            //绘农历
                            if (ccHoliday != "")
                            {
                                g.DrawString(ccHoliday, new Font("", 10), solidBrushWeekdays, (25 + 80 * i),
                                                                         (115 + 60 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("", 10), solidBrushWeekdays, (25 + 80 * i),
                                                                         (115 + 60 * j));
                            }


                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekdays,
                                         (15 + 80 * i), (80 + 60 * j));

                        }
                        else
                        {
                            var dt = DateTime.Parse(year + "-" + month + "-" + num);
                            var ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();
                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (15 + 80 * i), (85 + 60 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);

                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),
                                             solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                            }
                            //绘农历
                            if (ccHoliday != "")
                            {
                                g.DrawString(ccHoliday, new Font("", 10), solidBrushWeekend, (25 + 80 * i),
                                         (115 + 60 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("", 10), solidBrushWeekend, (25 + 80 * i),
                                         (115 + 60 * j));
                            }

                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekend,
                                         (15 + 80 * i), (80 + 60 * j));
                        }

                        num++;

                    }

                }
            }
        }

        //获取某月首日星期及某月天数
        private void GetWeekInfo(ref int weekOfFirstDay, ref int daysOfMonth, int year = 1900, int month = 2, int day = 1)
        {
            //在不同语言环境下输出相同的格式
            DateTime dt =
                DateTime.Parse(year.ToString(CultureInfo.InvariantCulture) + "-" +
                               month.ToString(CultureInfo.InvariantCulture) + "-" +
                               day.ToString(CultureInfo.InvariantCulture));
            weekOfFirstDay = (int)dt.DayOfWeek;
            daysOfMonth = (int)DateTime.DaysInMonth(year, month);
        }
    }
}

