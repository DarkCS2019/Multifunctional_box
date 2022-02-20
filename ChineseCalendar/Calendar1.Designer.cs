
namespace ChineseCalendar
{
    partial class Calendar1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbSelectYear = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbSelectMonth = new System.Windows.Forms.ComboBox();
            this.btnToday = new System.Windows.Forms.Button();
            this.panelMonthInfo = new System.Windows.Forms.Panel();
            this.panelMonthInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(229)))), ((int)(((byte)(129)))));
            this.lblYear.Location = new System.Drawing.Point(11, 8);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(56, 18);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "年份:";
            // 
            // cmbSelectYear
            // 
            this.cmbSelectYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectYear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSelectYear.FormattingEnabled = true;
            this.cmbSelectYear.Location = new System.Drawing.Point(54, 7);
            this.cmbSelectYear.Name = "cmbSelectYear";
            this.cmbSelectYear.Size = new System.Drawing.Size(61, 23);
            this.cmbSelectYear.TabIndex = 4;
            this.cmbSelectYear.SelectionChangeCommitted += new System.EventHandler(this.cmbSelectYear_SelectionChangeCommitted);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(229)))), ((int)(((byte)(129)))));
            this.lblMonth.Location = new System.Drawing.Point(121, 8);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(56, 18);
            this.lblMonth.TabIndex = 5;
            this.lblMonth.Text = "月份:";
            // 
            // cmbSelectMonth
            // 
            this.cmbSelectMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectMonth.FormattingEnabled = true;
            this.cmbSelectMonth.Location = new System.Drawing.Point(164, 7);
            this.cmbSelectMonth.Name = "cmbSelectMonth";
            this.cmbSelectMonth.Size = new System.Drawing.Size(63, 23);
            this.cmbSelectMonth.TabIndex = 6;
            this.cmbSelectMonth.SelectedIndexChanged += new System.EventHandler(this.cmbSelectMonth_SelectionChangeCommitted);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(231)))), ((int)(((byte)(204)))));
            this.btnToday.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToday.ForeColor = System.Drawing.Color.Black;
            this.btnToday.Location = new System.Drawing.Point(270, 1);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(84, 23);
            this.btnToday.TabIndex = 7;
            this.btnToday.Text = "今天";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // panelMonthInfo
            // 
            this.panelMonthInfo.Controls.Add(this.lblYear);
            this.panelMonthInfo.Controls.Add(this.lblMonth);
            this.panelMonthInfo.Controls.Add(this.btnToday);
            this.panelMonthInfo.Controls.Add(this.cmbSelectMonth);
            this.panelMonthInfo.Controls.Add(this.cmbSelectYear);
            this.panelMonthInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelMonthInfo.Location = new System.Drawing.Point(0, 0);
            this.panelMonthInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMonthInfo.Name = "panelMonthInfo";
            this.panelMonthInfo.Size = new System.Drawing.Size(556, 494);
            this.panelMonthInfo.TabIndex = 8;
            this.panelMonthInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthInfo_Paint);
            // 
            // Calendar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMonthInfo);
            this.Name = "Calendar1";
            this.Size = new System.Drawing.Size(633, 547);
            this.panelMonthInfo.ResumeLayout(false);
            this.panelMonthInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbSelectYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbSelectMonth;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Panel panelMonthInfo;
    }
}
