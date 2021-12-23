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

namespace ManageSchedule
{
    public partial class FormThongBaoTrongNgay : Form
    {
        private OneDay listSKToday;
        //public OneDay ListSKToday
        //{
        //    get { return listSKToday; }
        //    set { listSKToday = value; }
        //}

        private int x, y;

        public FormThongBaoTrongNgay()
        {
            InitializeComponent();

            listSKToday = new OneDay(DateTime.Now, true);
            ShowPlan();
        }

        private void labelCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelCancel_MouseHover(object sender, EventArgs e)
        {
            labelCancel.ForeColor = Color.OrangeRed;
        }

        private void labelCancel_MouseLeave(object sender, EventArgs e)
        {
            labelCancel.ForeColor = Color.White;
        }

        private void ShowPlan()
        {
            this.Refresh();
            this.StartPosition = FormStartPosition.Manual;

            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5;
            this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5;
            this.Location = new Point(this.x, this.y);

            List<MotThongBaoNgay> ThongBao = new List<MotThongBaoNgay>();
            foreach (OneEvent ev in listSKToday.ListOfDay)
            {
                ThongBao.Add(new MotThongBaoNgay(ev));
            }

            FlowLayoutPanel fPanel = new FlowLayoutPanel();
            fPanel.Width = panelNotice.Width;
            fPanel.Height = panelNotice.Height;
            fPanel.AutoScroll = true;
            panelNotice.Controls.Add(fPanel);

            foreach (MotThongBaoNgay notice in ThongBao)
            {
                fPanel.Controls.Add(notice);
            }

            this.Show();
        }
    }
}
