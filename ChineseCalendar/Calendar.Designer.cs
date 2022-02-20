
namespace ChineseCalendar
{
    partial class Calendar
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calendar));
            this.panelMonthInfo = new System.Windows.Forms.Panel();
            this.cmbSelectMonth = new System.Windows.Forms.ComboBox();
            this.cmbSelectYear = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.panelMonthInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMonthInfo
            // 
            this.panelMonthInfo.Controls.Add(this.cmbSelectMonth);
            this.panelMonthInfo.Controls.Add(this.cmbSelectYear);
            this.panelMonthInfo.Controls.Add(this.lblMonth);
            this.panelMonthInfo.Controls.Add(this.lblYear);
            this.panelMonthInfo.Controls.Add(this.btnToday);
            this.panelMonthInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panelMonthInfo.Location = new System.Drawing.Point(-3, 0);
            this.panelMonthInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelMonthInfo.Name = "panelMonthInfo";
            this.panelMonthInfo.Size = new System.Drawing.Size(614, 489);
            this.panelMonthInfo.TabIndex = 0;
            this.panelMonthInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthInfo_Paint);
            // 
            // cmbSelectMonth
            // 
            this.cmbSelectMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectMonth.FormattingEnabled = true;
            this.cmbSelectMonth.Location = new System.Drawing.Point(296, 9);
            this.cmbSelectMonth.Name = "cmbSelectMonth";
            this.cmbSelectMonth.Size = new System.Drawing.Size(108, 23);
            this.cmbSelectMonth.TabIndex = 4;
            this.cmbSelectMonth.SelectionChangeCommitted += new System.EventHandler(this.cmbSelectMonth_SelectionChangeCommitted);
            // 
            // cmbSelectYear
            // 
            this.cmbSelectYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectYear.FormattingEnabled = true;
            this.cmbSelectYear.Location = new System.Drawing.Point(97, 9);
            this.cmbSelectYear.Name = "cmbSelectYear";
            this.cmbSelectYear.Size = new System.Drawing.Size(108, 23);
            this.cmbSelectYear.TabIndex = 3;
            this.cmbSelectYear.SelectionChangeCommitted += new System.EventHandler(this.cmbSelectYear_SelectionChangeCommitted);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMonth.Location = new System.Drawing.Point(211, 9);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(79, 23);
            this.lblMonth.TabIndex = 2;
            this.lblMonth.Text = "月份：";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYear.Location = new System.Drawing.Point(12, 9);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(79, 23);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "年份：";
            // 
            // btnToday
            // 
            this.btnToday.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnToday.Location = new System.Drawing.Point(437, 9);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(128, 26);
            this.btnToday.TabIndex = 0;
            this.btnToday.Text = "今天";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 474);
            this.Controls.Add(this.panelMonthInfo);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calendar";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "万年历";
            this.panelMonthInfo.ResumeLayout(false);
            this.panelMonthInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMonthInfo;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbSelectMonth;
        private System.Windows.Forms.ComboBox cmbSelectYear;
        private System.Windows.Forms.Label lblMonth;
    }
}

