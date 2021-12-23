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
    public partial class FormCongViec : Form
    {
        #region Peoperties
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion        
        private Form curChildForm;
        private int typeChildForm;
        FormMonthView monthView;
        FormDayView dayView;

        public FormCongViec()
        {
            InitializeComponent();
            typeChildForm = -1;
            cbViewOption.Text = "Tháng";
            dtpkDate.Value = DateTime.Now;
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void SetToday()
        {
            dtpkDate.Value = DateTime.Now;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetToday();
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            switch (typeChildForm)
            {
                case 0:
                    if (!monthView.IsFromOutSide)
                    {
                        monthView.IsFromOutSide = true;
                        monthView.DateChange(dtpkDate.Value);
                    }
                    break;
                case 1:
                    dayView.Day = dtpkDate.Value;
                    dayView.Init();
                    dayView.ShowEvents();
                    break;
                default:
                    break;
            }

        }

        private void OpenChildForm(Form childForm)
        {
            if (curChildForm != null)
            {
                curChildForm.Close();
            }

            curChildForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panel5.Controls.Add(childForm);
            panel5.Tag = childForm;
            curChildForm.BringToFront();
            curChildForm.Show();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            switch (typeChildForm)
            {
                case 0:
                    date = DateTime.Now;
                    break;
                case 1:
                    date = dtpkDate.Value;
                    break;
                default:
                    break;
            }
            FormEditEvent form = new FormEditEvent(date);
            form.Show();
            form.Edited += EditSK_Edited;
        }

        private void EditSK_Edited(object sender, EventArgs e)
        {
            OneEvent one = (sender as FormEditEvent).ItemEvent;
            switch (typeChildForm)
            {
                case 0:
                    monthView.EditSk_Update(one);
                    break;
                case 1:
                    dayView.Update(one);
                    break;
                default:
                    break;
            }
        }

        private void cbViewOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeChildForm == cbViewOption.SelectedIndex)
            {
                return;
            }
            else
            {
                typeChildForm = cbViewOption.SelectedIndex;
            }
            panel5.BringToFront();
            switch (cbViewOption.SelectedIndex)
            {
                case 0:
                    this.monthView = new FormMonthView(dtpkDate.Value);
                    OpenChildForm(this.monthView);
                    monthView.DateChanged += MonthView_DateChanged;
                    monthView.FormChanged += MonthView_FormChanged;
                    dtpkDate.Format = DateTimePickerFormat.Long;
                    dtpkDate.Size = new Size(313, 27);
                    dtpkDate.Location = new Point(432, 10);
                    break;
                case 1:
                    this.dayView = new FormDayView(dtpkDate.Value);
                    dayView.DayChanged += DayView_DayChanged;
                    OpenChildForm(this.dayView);
                    dtpkDate.Format = DateTimePickerFormat.Custom;
                    dtpkDate.CustomFormat = "MMMM, yyyy";
                    dtpkDate.Size = new Size(185, 27);
                    dtpkDate.Location = new Point(472, 9);
                    break;
                default:
                    panel5.SendToBack();
                    dtpkDate.Format = DateTimePickerFormat.Long;
                    dtpkDate.Size = new Size(313, 27);
                    dtpkDate.Location = new Point(432, 10);
                    typeChildForm = -1;
                    break;
            }
        }

        private void MonthView_FormChanged(object sender, EventArgs e)
        {
            cbViewOption.SelectedIndex = 1;
        }

        private void MonthView_DateChanged(object sender, EventArgs e)
        {
            dtpkDate.Value = monthView.DateMonth;
        }

        private void DayView_DayChanged(object sender, EventArgs e)
        {
            ///đưa day trong child form ra ngoài
            dtpkDate.Value = dayView.Day;
        }
    }
}
