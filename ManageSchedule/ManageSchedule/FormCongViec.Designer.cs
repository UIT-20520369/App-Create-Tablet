
namespace ManageSchedule
{
    partial class FormCongViec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BoTronCongViec = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.cbViewOption = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BoTronCongViec
            // 
            this.BoTronCongViec.ElipseRadius = 10;
            this.BoTronCongViec.TargetControl = this;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(4, 55);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1124, 621);
            this.panel5.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1124, 673);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddEvent);
            this.panel2.Controls.Add(this.btnToday);
            this.panel2.Controls.Add(this.dtpkDate);
            this.panel2.Controls.Add(this.cbViewOption);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1124, 49);
            this.panel2.TabIndex = 0;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(206)))));
            this.btnAddEvent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEvent.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddEvent.Location = new System.Drawing.Point(956, 0);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(137, 46);
            this.btnAddEvent.TabIndex = 4;
            this.btnAddEvent.Text = "Thêm sự kiện";
            this.btnAddEvent.UseVisualStyleBackColor = false;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnToday
            // 
            this.btnToday.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(227)))), ((int)(((byte)(206)))));
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToday.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnToday.Location = new System.Drawing.Point(811, 0);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(118, 45);
            this.btnToday.TabIndex = 3;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(432, 10);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(313, 27);
            this.dtpkDate.TabIndex = 2;
            this.dtpkDate.Value = new System.DateTime(2021, 12, 19, 14, 36, 0, 0);
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // cbViewOption
            // 
            this.cbViewOption.FormattingEnabled = true;
            this.cbViewOption.Items.AddRange(new object[] {
            "Tháng",
            "Ngày",
            "Lịch"});
            this.cbViewOption.Location = new System.Drawing.Point(161, 11);
            this.cbViewOption.Name = "cbViewOption";
            this.cbViewOption.Size = new System.Drawing.Size(104, 26);
            this.cbViewOption.TabIndex = 1;
            this.cbViewOption.SelectedIndexChanged += new System.EventHandler(this.cbViewOption_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chế độ hiển thị";
            // 
            // FormCongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 679);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCongViec";
            this.Text = "Công việc";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse BoTronCongViec;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.ComboBox cbViewOption;
        private System.Windows.Forms.Label label1;
    }
}