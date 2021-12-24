using ManageSchedule.UserControls;
using ManageSchedule.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule.Forms
{
    public partial class FormThongBao : Form
    {
        public FormThongBao()
        {
            InitializeComponent();

            listSKToday = new OneDay(true, DateTime.Now);
            ShowPlan();
        }

        private int x, y;
        OneDay listSKToday;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.White;
        }

        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            btnThoat.ForeColor = Color.OrangeRed;
        }

        private void ShowPlan()
        {
            this.Refresh();
            this.StartPosition = FormStartPosition.Manual;

            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5;
            this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5;
            this.Location = new Point(this.x, this.y);

            if (listSKToday.ListOfDay.Count > 0)
            {
                List<MotThongBao> ThongBao = new List<MotThongBao>();
                foreach (OneEvent ev in listSKToday.ListOfDay)
                {
                    ThongBao.Add(new MotThongBao(ev));
                }

                Label title = new Label();
                title.AutoSize = false;
                title.TextAlign = ContentAlignment.MiddleCenter;
                title.Text = "Công việc hôm nay";
                panelNotice.Controls.Add(title);
                title.Dock = DockStyle.Top;
                title.Location = new System.Drawing.Point(0, 0);
                title.ForeColor = Color.Black;
                title.Font = new System.Drawing.Font("Verdana", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                FlowLayoutPanel fPanel = new FlowLayoutPanel();
                fPanel.Width = panelNotice.Width;
                fPanel.Height = panelNotice.Height - title.Height;
                fPanel.AutoScroll = true;
                panelNotice.Controls.Add(fPanel);
                fPanel.Location = new Point(0, title.Height);
                
                foreach (MotThongBao notice in ThongBao)
                {
                    fPanel.Controls.Add(notice);
                }
            }
            else
            {
                Label noWork = new Label();
                noWork.AutoSize = false;
                noWork.TextAlign = ContentAlignment.MiddleCenter;
                noWork.Text = "Bạn không có công việc nào \n trong hôm nay!";
                panelNotice.Controls.Add(noWork);
                noWork.Dock = DockStyle.Fill;
                noWork.Location = new System.Drawing.Point(0, 0);
                noWork.ForeColor = Color.Black;
                noWork.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }

            this.Show();
        }
    }
}
