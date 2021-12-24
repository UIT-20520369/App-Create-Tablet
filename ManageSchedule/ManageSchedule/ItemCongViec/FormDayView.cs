using ManageSchedule.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule
{
    public partial class FormDayView : Form
    {
        private DateTime day;
        public DateTime Day
        {
            get { return day; }
            set { day = value; }
        }

        private OneDay oneDay;
        public OneDay One_Day
        {
            get { return oneDay; }
            set { oneDay = value; }
        }

        private event EventHandler dayChanged;
        public event EventHandler DayChanged
        {
            add { dayChanged += value; }
            remove { dayChanged -= value; }
        }

        public FormDayView(DateTime _day)
        {
            InitializeComponent();
            this.day = _day;
            Init();
            ShowEvents();
        }

        public void Init()
        {
            string thu = HangSo.DayofWeek_vn[(int)day.DayOfWeek];
            string thang = HangSo.Month_vn[day.Month - 1];
            string text = $"{thu}, {day.Day} {thang}, {day.Year}";
            lbDay.Text = text;
            oneDay = new OneDay(day);

            SqlConnection sqlCon = null;
            oneDay.UploadData(ref sqlCon);
        }

        public void ShowEvents()
        {
            flPnlListDay.Controls.Clear();
            int quantity = oneDay.ListOfDay.Count;
            if (quantity == 0)
            {
                Label lbl = new Label();
                lbl.Text = "Lịch trống";
                lbl.ForeColor = System.Drawing.Color.Green;
                lbl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.Margin = new Padding((flPnlListDay.Width - lbl.Width) / 2, 0, 3, 0);
                flPnlListDay.Controls.Add(lbl);
                return;
            }
            for (int i = 0; i < quantity; i++)
            {
                MotSuKien motSuKien = new MotSuKien(oneDay.ListOfDay[i], flPnlListDay.Width - 50);
                motSuKien.Deleted += MotSuKien_Deleted;
                flPnlListDay.Controls.Add(motSuKien);
            }
        }

        public void Update(OneEvent _one)
        {
            if (oneDay.ListOfDay.Count == 0)
                flPnlListDay.Controls.Clear();
            this.One_Day.ListOfDay.Add(_one);
            this.One_Day.ListOfDay.Sort();
            int index = oneDay.ListOfDay.IndexOf(_one);
            MotSuKien mot = new MotSuKien(_one, flPnlListDay.Width - 50);
            mot.Deleted += MotSuKien_Deleted;
            flPnlListDay.Controls.Add(mot);
            flPnlListDay.Controls.SetChildIndex(mot, index);
        }

        private void MotSuKien_Deleted(object sender, EventArgs e)
        {
            OneEvent one = (sender as MotSuKien).SuKien;
            oneDay.ListOfDay.Remove(one);
            flPnlListDay.Controls.Remove(sender as MotSuKien);
            ShowEvents();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            ChangeDay(day.AddDays(-1));
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangeDay(day.AddDays(1));
        }

        private void ChangeDay(DateTime date)
        {
            day = date;
            Init();
            ShowEvents();
            if (dayChanged != null)
                dayChanged(this, new EventArgs());
        }
    }
}
