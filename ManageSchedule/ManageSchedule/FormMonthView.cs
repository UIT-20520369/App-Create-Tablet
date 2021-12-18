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
    public partial class FormMonthView : Form
    {
        #region Peoperties
        private List<List<FlowLayoutPanel>> matrix;
        public List<List<FlowLayoutPanel>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }
        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        #endregion

        private List<OneDay> listMonth;

        private Point chosenDay;
        private DateTime dateMonth;
        public DateTime DateMonth
        {
            get { return dateMonth; }
            set { dateMonth = value; }
        }
        private bool isFromOutSide;
        public bool IsFromOutSide
        {
            get { return isFromOutSide; }
            set { isFromOutSide = value; }
        }
        private event EventHandler dateChanged;
        public event EventHandler DateChanged
        {
            add { dateChanged += value; }
            remove { dateChanged -= value; }
        }

        public FormMonthView(DateTime _date)
        {
            InitializeComponent();

            listMonth = new List<OneDay>();
            dateMonth = _date;
            LoadMatrix();
            isFromOutSide = false;
        }

       
        void LoadMatrix()
        {
            Matrix = new List<List<FlowLayoutPanel>>();
            //Tạo oldBtn với chiều rộng và chiều cao = 0, nằm ở vị trí (-6, 0)
            FlowLayoutPanel oldBtn = new FlowLayoutPanel() { Width = 0, Height = 0, Location = new Point(-HangSo.Margin_MV, 0) };

            for (int i = 0; i < HangSo.DayofColumn; i++)
            {
                Matrix.Add(new List<FlowLayoutPanel>());
                for (int j = 0; j < HangSo.DayofWeek; j++)
                {
                    FlowLayoutPanel btn = new FlowLayoutPanel() { Width = HangSo.dateButtonWidth_MV, Height = HangSo.dateButtonHeight_MV };
                    btn.BorderStyle = BorderStyle.FixedSingle;
                    btn.Click += Btn_Click;

                    // Vị trí của button kế tiếp được tính toán theo vị trí và chiều rộng button cũ + lề
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + HangSo.Margin_MV, oldBtn.Location.Y);
                    pnlMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);

                    oldBtn = btn;
                }
                // Đặt oldBtn về vị trí đầu dòng
                oldBtn = new FlowLayoutPanel() { Width = 0, Height = 0, Location = new Point(-HangSo.Margin_MV, oldBtn.Location.Y + HangSo.dateButtonHeight_MV + HangSo.Margin_MV) };
            }

            AddDayIntoMatrix(dateMonth, false);
        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || date.Year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30;
            }
        }

        void AddDayIntoMatrix(DateTime date, bool flag)
        {
            if (!flag)
            {
                ClearMatrix();
                LoadEventForMatrix();
            }
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            int line = 0;
            //Đánh số cột cho các kết quả thu được từ useDate.DayOfWeek.ToString() (bắt đầu từ 0)
            int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                if (column > 6)
                {
                    line++;
                    column = 0;
                }

                FlowLayoutPanel btn = Matrix[line][column];

                if (!flag)
                {
                    Bunifu.UI.WinForms.BunifuButton.BunifuButton2 btnDay = new Bunifu.UI.WinForms.BunifuButton.BunifuButton2();
                    btnDay.Click += btnDay_Click;
                    btn.Controls.Add(btnDay);
                    btnDay.AutoSize = false;
                    btnDay.Size = new System.Drawing.Size(25, 25);
                    btnDay.Margin = new System.Windows.Forms.Padding(59, 1, 59, 1);
                    //btnDay.Width = btn.Width;
                    btnDay.Font = lblMonday.Font;
                    btnDay.Text = i.ToString();
                    btnDay.TextAlign = ContentAlignment.MiddleCenter;
                    //using (Graphics g = CreateGraphics())
                    //{
                    //    SizeF size = g.MeasureString(btnDay.Text, btnDay.Font, btnDay.Width);
                    //    btnDay.Height = (int)Math.Ceiling(size.Height);
                    //}
                    int index = listMonth.FindIndex(c => c.Day.Day == i);
                    if (index != -1)
                    {
                        SetButtonEventsForOneDay(ref btn, listMonth[index]);
                    }
                }
                else
                {
                    btn.BackColor = Color.WhiteSmoke;
                }

                //Thay màu nền cho ngày hôm nay
                if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.LightCyan;
                }

                //Thay màu nền cho ngày được chọn
                if (isEqualDate(useDate, date))
                {
                    chosenDay = new Point(line, column);
                    btn.BackColor = Color.Aquamarine;
                }

                column++;

                useDate = useDate.AddDays(1);
            }
        }

        //click vào btn 1 ngày thì thêm sự kiện
        private void Btn_Click(object sender, EventArgs e)
        {
            if ((sender as FlowLayoutPanel).Controls.Count == 0)
                return;
            int day = Convert.ToInt32((sender as FlowLayoutPanel).Controls[0].Text);
            DateTime date = new DateTime(dateMonth.Year, dateMonth.Month, day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            DateChange(date);
            EditSuKien form = new EditSuKien(date);
            form.Edited += EditSk_Edited;
            form.Show();
        }

        //click vào label thì ngày dc chọn
        private void btnDay_Click(object sender, EventArgs e)
        {
            //thay màu cho ngày dc chọn cũ
            int day = Convert.ToInt32(Matrix[chosenDay.X][chosenDay.Y].Controls[0].Text);
            if (day == DateTime.Now.Day)
            {
                Matrix[chosenDay.X][chosenDay.Y].BackColor = Color.LightCyan;
            }
            else
            {
                Matrix[chosenDay.X][chosenDay.Y].BackColor = Color.WhiteSmoke;
            }

            var fl = (sender as Bunifu.UI.WinForms.BunifuButton.BunifuButton2).Parent;
            day = Convert.ToInt32(fl.Controls[0].Text);
            DateTime date = new DateTime(dateMonth.Year, dateMonth.Month, day);
            DateChange(date);
            fl.BackColor = Color.Aquamarine;

            //tìm
            DateTime useDate = new DateTime(dateMonth.Year, dateMonth.Month, 1);
            int line = 0;
            int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
            for (int i = 1; i <= DayOfMonth(dateMonth); i++)
            {
                if (column > 6)
                {
                    line++;
                    column = 0;
                }
                int index = Matrix[line].IndexOf((FlowLayoutPanel)fl);
                if (index != -1)
                {
                    chosenDay = new Point(line, index);
                    Matrix[chosenDay.X][chosenDay.Y].BackColor = Color.Aquamarine;
                    return;
                }
                column++;
                useDate = useDate.AddDays(1);
            }
        }

        private void LoadEventForMatrix()
        {
            HangSo.SqlSetDateFormat();

            SqlConnection sqlCon = new SqlConnection(HangSo.strCon);
            sqlCon.Open();

            SqlCommand sqlGet = new SqlCommand("select * from dbo.SUKIEN where USERNAME = @username and NGAY >= @ngaybd and NGAY <= @ngaykt order by NGAY asc", sqlCon);
            sqlGet.Parameters.Add("@username", SqlDbType.VarChar);
            sqlGet.Parameters["@username"].Value = CaiDat.GetPreUsername();
            sqlGet.Parameters.Add("@ngaybd", SqlDbType.DateTime);
            sqlGet.Parameters["@ngaybd"].Value = new DateTime(this.dateMonth.Year, dateMonth.Month, 1, 0, 0, 0);
            sqlGet.Parameters.Add("@ngaykt", SqlDbType.DateTime);
            sqlGet.Parameters["@ngaykt"].Value = new DateTime(this.dateMonth.Year, dateMonth.Month, DayOfMonth(dateMonth), 23, 59, 59);

            var reader = sqlGet.ExecuteReader();
            while (reader.Read())
            {
                int day = reader.GetDateTime(3).Day;

                OneEvent one = new OneEvent();
                one.ID = reader.GetInt32(1);
                one.TieuDe = reader.GetString(2);
                one.Ngay = reader.GetDateTime(3);
                if (reader.GetValue(4) != DBNull.Value)
                {
                    one.ToiNgay = reader.GetDateTime(4);
                }
                if (reader.GetValue(5) != DBNull.Value)
                {
                    one.MonHoc = reader.GetString(5);
                }
                if (reader.GetValue(6) != DBNull.Value)
                {
                    one.MoTa = reader.GetString(6);
                }
                int index = listMonth.FindIndex(c => c.Day.Day == day);
                if (index != -1)
                {
                    //trung ngay
                    listMonth[index].ListOfDay.Add(one);
                }
                else
                {
                    //khacngay
                    OneDay oneDay = new OneDay(new DateTime(dateMonth.Year, dateMonth.Month, day));
                    oneDay.ListOfDay.Add(one);
                    listMonth.Add(oneDay);
                }
            }
            reader.Close();
            sqlGet.Dispose();

            int count_Month = listMonth.Count;
            for (int day = 0; day < count_Month; day++) 
            {
                listMonth[day].UploadThongBao(ref sqlCon);                
            }
            
            sqlCon.Close();
        }

        //thêm btn đại diện cho 1 sự kiệnn
        private void SetButtonEventsForOneDay(ref FlowLayoutPanel pnl, OneDay oneDay)
        {
            int quantity = oneDay.ListOfDay.Count;
            for (int i = 0; i < quantity; i++)
            {
                OneEvent oneEvent = oneDay.ListOfDay[i];
                Button btnEvent = new Button();
                btnEvent.Click += BtnEvent_Click;
                btnEvent.AutoSize = false;
                btnEvent.AutoEllipsis = true;
                btnEvent.BackColor = Color.WhiteSmoke;
                btnEvent.FlatStyle = FlatStyle.Flat;
                btnEvent.FlatAppearance.BorderSize = 0;

                btnEvent.Width = pnl.Width - 8;
                btnEvent.Height = 26;
                string monHoc = oneEvent.MonHoc + "_";
                btnEvent.Text = $"* {oneEvent.Ngay.ToString("HH:mm")}: {monHoc}{oneEvent.TieuDe}";
                btnEvent.TextAlign = ContentAlignment.TopLeft;
                btnEvent.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                pnl.Controls.Add(btnEvent);
            }
        }

        private void DeleteEventFromOtherForm(OneEvent oneEvent)
        {
            int dayActive = oneEvent.Ngay.Day;
            int index = listMonth.FindIndex(c => c.Day.Day == dayActive);
            int indexOfDay = listMonth[index].ListOfDay.IndexOf(oneEvent);

            listMonth[index].ListOfDay.RemoveAt(indexOfDay);
            UpdateDay(dayActive, index);
        }

        public void EditSk_Update(OneEvent one)
        {
            int day = one.Ngay.Day;
            int index = listMonth.FindIndex(c => c.Day.Day == day);
            if (index == -1)
            {
                //thêm sự kiện cho 1 ngày trống                      
                OneDay oneDay = new OneDay(new DateTime(dateMonth.Year, dateMonth.Month, day));
                oneDay.ListOfDay.Add(one);
                listMonth.Add(oneDay);
                index = listMonth.Count - 1;
            }
            else
            {
                int id = listMonth[index].ListOfDay.FindIndex(c => c.ID == one.ID);
                if (id == -1)
                {
                    listMonth[index].ListOfDay.Add(one);
                    listMonth[index].ListOfDay.Sort();
                }
            }
            UpdateDay(day, index);
        }

        private void UpdateDay(int day, int index)
        {
            DateTime useDate = new DateTime(dateMonth.Year, dateMonth.Month, 1);
            int line = 0;
            int dayOfMonth = DayOfMonth(dateMonth);
            //Đánh số cột cho các kết quả thu được từ useDate.DayOfWeek.ToString() (bắt đầu từ 0)
            int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
            for (int i = 1; i <= dayOfMonth; i++)
            {
                if (column > 6)
                {
                    line++;
                    column = 0;
                }
                FlowLayoutPanel btn = Matrix[line][column];

                if (btn.Controls.Count > 0)
                {
                    if (day == Convert.ToInt32(btn.Controls[0].Text))
                    {
                        int count = btn.Controls.Count - 1;
                        while (count > 0)
                        {
                            btn.Controls.RemoveAt(count);
                            count--;
                        }
                        SetButtonEventsForOneDay(ref btn, listMonth[index]);
                        break;
                    }
                }

                column++;
                useDate = useDate.AddDays(1);
            }
        }

        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j < Matrix[i].Count; j++)
                {
                    FlowLayoutPanel btn = Matrix[i][j];
                    btn.Controls.Clear();
                    //  btn.FlatStyle = 0;
                    btn.BackColor = Color.WhiteSmoke;
                    //  btn.FlatAppearance.BorderSize = 1;
                    //  btn.FlatAppearance.BorderColor = Color.Gainsboro;
                }
            }
            listMonth.Clear();
        }

        public void DateChange(DateTime _date)
        {
            bool isSameMonth;
            if (_date.Month == dateMonth.Month && _date.Year == dateMonth.Year)
                isSameMonth = true;
            else
                isSameMonth = false;
            this.dateMonth = _date;

            AddDayIntoMatrix(dateMonth, isSameMonth);
            if (isFromOutSide)
            {
                isFromOutSide = false;
                return;
            }
            if (dateChanged != null)
                dateChanged(this, new EventArgs());
        }
        
      

       

        //click vào 1 btn sukien thì hiển thị sukien
        private void BtnEvent_Click(object sender, EventArgs e)
        {
            int day = Convert.ToInt32((sender as Button).Parent.Controls[0].Text);
            int indexOfBtn = (sender as Button).Parent.Controls.IndexOf(sender as Button);
            int index = listMonth.FindIndex(c => c.Day.Day == day);

            FormShowSuKien form = new FormShowSuKien(listMonth[index].ListOfDay[indexOfBtn - 1]);
            form.Show();

            form.Deleted += FormShowSK_Deleted;
            form.Edited += FormShowSK_Edited;
        }


        private void FormShowSK_Edited(object sender, EventArgs e)
        {
            OneEvent one = (sender as FormShowSuKien).SuKien.SuKien;
            EditSuKien form = new EditSuKien(one);
            form.Edited += EditSk_Edited;
            form.Deleted += EditSk_Deleted;
            form.Show();
        }

        private void EditSk_Deleted(object sender, EventArgs e)
        {
            OneEvent oneEvent = (sender as EditSuKien).ItemEvent;
            DeleteEventFromOtherForm(oneEvent);
        }

        private void FormShowSK_Deleted(object sender, EventArgs e)
        {
            OneEvent oneEvent = (sender as FormShowSuKien).SuKien.SuKien;
            DeleteEventFromOtherForm(oneEvent);
        }

        private void EditSk_Edited(object sender, EventArgs e)
        {
            OneEvent one = (sender as EditSuKien).ItemEvent;
            EditSk_Update(one);
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            DateChange(dateMonth.AddMonths(-1));
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            DateChange(dateMonth.AddMonths(1));
        }
    
    }
}
