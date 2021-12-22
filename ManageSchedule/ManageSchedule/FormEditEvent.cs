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
    public partial class FormEditEvent : Form
    {
        SqlConnection sqlCon = null;
        private bool isClickButton;

        private event EventHandler edited;
        public event EventHandler Edited
        {
            add { edited += value; }
            remove { edited -= value; }
        }

        private event EventHandler deleted;
        public event EventHandler Deleted
        {
            add { deleted += value; }
            remove { deleted -= value; }
        }

        private OneEvent itemEvent;
        public OneEvent ItemEvent
        {
            get { return itemEvent; }
            set { itemEvent = value; }
        }

        private bool isMinSize;

        public FormEditEvent(DateTime dateTime)
        {
            InitializeComponent();
            itemEvent = new OneEvent();
            dtpkNgay.Value = dateTime;
            dtpkToiNgay.Value = dateTime;
            raBtnNoTimeTo.Checked = true;
            isMinSize = true;
        }

        public FormEditEvent(OneEvent suKien)
        {
            InitializeComponent();
            ItemEvent = suKien;

            isMinSize = true;
            ShowEvent();
            btnDelete.Visible = true;
        }

        private void ShowEvent()
        {
            txtbxTilte.Text = ItemEvent.TieuDe;
            if (!string.IsNullOrEmpty(ItemEvent.MonHoc))
            {
                bxSubject.Text = ItemEvent.MonHoc;
            }

            if (!string.IsNullOrEmpty(ItemEvent.MoTa))
            {
                bxDescrip.Text = ItemEvent.MoTa;
                isMinSize = false;
            }

            SetTime(ItemEvent.Ngay);
            if (ItemEvent.ToiNgay == DateTime.MinValue)
            {
                SetToTime(ItemEvent.Ngay);
                raBtnNoTimeTo.Checked = true;
            }
            else
            {
                SetToTime(ItemEvent.ToiNgay);
                raBtnTo.Checked = true;
                isMinSize = false;
            }

            for (int i = 0; i < ItemEvent.ListTB.Count; i++)
            {
                ThongBao tb = new ThongBao(ItemEvent.ListTB[i]);
                tb.Delete += Tb_Delete;
                flPnlNotify.Controls.Add(tb);
            }
            if (itemEvent.ListTB.Count == 5)
            {
                btnAddNotify.Enabled = false;
            }
        }

        private void EditSuKien_Load(object sender, EventArgs e)
        {
            isClickButton = false;
            if (isMinSize)
                MinSize();
            else
                MaxSize();
        }

        private void MaxSize()
        {
            lblShow.Text = "Hiển thị ít hơn";
            this.Size = new Size(this.Width, pnlTittle.Height + pnlMore.MaximumSize.Height + btnSave.Height + 15);
            pnlTotal.Size = new Size(pnlTittle.Width, this.Size.Height);
            flPnlMore.Size = new Size(flPnlMore.Width, pnlMore.MaximumSize.Height + btnSave.Height + 15);
            pnlMore.Size = pnlMore.MaximumSize;
        }

        private void MinSize()
        {
            lblShow.Text = "Hiển thị thêm . . .";
            pnlMore.Size = pnlMore.MinimumSize;
            flPnlMore.Size = new Size(flPnlMore.Width, pnlMore.Height + btnSave.Height + 15);
            pnlTotal.Size = new Size(pnlTittle.Width, pnlTittle.Height + flPnlMore.Height);
            this.Size = new Size(this.Width, pnlTotal.Height);
        }

        private void SetTime(DateTime date)
        {
            nmDay.Value = date.Day;
            dmMonth.SelectedIndex = date.Month - 1;
            nmYear.Value = date.Year;
            nmHour.Value = date.Hour;
            nmMinute.Value = date.Minute;
            dtpkNgay.Value = date;
        }

        private void SetToTime(DateTime date)
        {
            nmToDay.Value = date.Day;
            dmToMonth.SelectedIndex = date.Month - 1;
            nmToYear.Value = date.Year;
            nmToHour.Value = date.Hour;
            nmToMinute.Value = date.Minute;
            dtpkToiNgay.Value = date;
        }

        private void lblShow_Click(object sender, EventArgs e)
        {
            if (lblShow.Text == "Hiển thị thêm . . .")
                MaxSize();
            else
                MinSize();
        }

        private void Tb_Delete(object sender, EventArgs e)
        {
            flPnlNotify.Controls.Remove(sender as ThongBao);
            itemEvent.ListTB.Remove((sender as ThongBao).ItemTB);
            if (itemEvent.ListTB.Count < 5)
            {
                btnAddNotify.Enabled = true;
            }
        }

        private void btnAddNotify_Click(object sender, EventArgs e)
        {
            ThongBao tb = new ThongBao();
            tb.Delete += Tb_Delete;
            flPnlNotify.Controls.Add(tb);
            tb.Focus();

            this.itemEvent.ListTB.Add(tb.ItemTB);
            if (itemEvent.ListTB.Count == 5)
            {
                btnAddNotify.Enabled = false;
            }
        }

        private void btnlich_Click(object sender, EventArgs e)
        {
            dtpkNgay.Visible = !dtpkNgay.Visible;
            dtpkNgay.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void btnToTimeLich_Click(object sender, EventArgs e)
        {
            dtpkToiNgay.Visible = !dtpkToiNgay.Visible;
            dtpkToiNgay.Select();
            SendKeys.Send("%{DOWN}");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HangSo.SqlSetDateFormat();
            if (string.IsNullOrEmpty(txtbxTilte.Text))
            {
                lbNoEmpty.Visible = true;
                txtbxTilte.Select();
                return;
            }

            isClickButton = true;
            //--------thêm
            DateTime ngaybd = new DateTime(Convert.ToInt32(nmYear.Value), dmMonth.SelectedIndex + 1, Convert.ToInt32(nmDay.Value), Convert.ToInt32(nmHour.Value), Convert.ToInt32(nmMinute.Value), 0);
            DateTime ngaykt;

            if (!raBtnNoTimeTo.Checked)
            {
                ngaykt = new DateTime(Convert.ToInt32(nmToYear.Value), dmToMonth.SelectedIndex + 1, Convert.ToInt32(nmToDay.Value), Convert.ToInt32(nmToHour.Value), Convert.ToInt32(nmToMinute.Value), 0);
                if (DateTime.Compare(ngaykt, ngaybd) < 0)
                {
                    MessageBox.Show("Ngày kết thúc không thể trước ngày bắt đầu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetToTime(ngaybd);
                    return;
                }
                ItemEvent.ToiNgay = ngaykt;
            }
            //-------thêm----end
            ItemEvent.TieuDe = txtbxTilte.Text;
            ItemEvent.Ngay = new DateTime(Convert.ToInt32(nmYear.Value), dmMonth.SelectedIndex + 1, Convert.ToInt32(nmDay.Value), Convert.ToInt32(nmHour.Value), Convert.ToInt32(nmMinute.Value), 0);
            ItemEvent.MonHoc = bxSubject.Text;
            ItemEvent.MoTa = bxDescrip.Text;
            if (!raBtnNoTimeTo.Checked)
            {
                ItemEvent.ToiNgay = new DateTime(Convert.ToInt32(nmToYear.Value), dmToMonth.SelectedIndex + 1, Convert.ToInt32(nmToDay.Value), Convert.ToInt32(nmToHour.Value), Convert.ToInt32(nmToMinute.Value), 0);
            }

            HangSo.SqlSetDateFormat();
            if (ItemEvent.ID == -1)
                InsertIntoTableSK();
            else
                UpdateInTableSK();

            if (edited != null)
                edited(this, new EventArgs());
            this.Close();
        }

        #region Database

        private void SetValueOfTableSK(ref SqlCommand sql)
        {
            sql.Parameters.Add("@tieude", SqlDbType.NVarChar);
            sql.Parameters["@tieude"].Value = ItemEvent.TieuDe;

            sql.Parameters.Add("@ngay", SqlDbType.DateTime);
            sql.Parameters["@ngay"].Value = ItemEvent.Ngay;

            sql.Parameters.Add("@toingay", SqlDbType.DateTime);
            if (raBtnNoTimeTo.Checked)
            {
                sql.Parameters["@toingay"].Value = DBNull.Value;
            }
            else
            {
                sql.Parameters["@toingay"].Value = ItemEvent.ToiNgay;
            }

            sql.Parameters.Add("@monhoc", SqlDbType.NVarChar);
            if (string.IsNullOrEmpty(ItemEvent.MonHoc))
            {
                sql.Parameters["@monhoc"].Value = DBNull.Value;
            }
            else
            {
                sql.Parameters["@monhoc"].Value = ItemEvent.MonHoc;
            }

            sql.Parameters.Add("@mota", SqlDbType.NText);
            if (string.IsNullOrEmpty(ItemEvent.MoTa))
            {
                sql.Parameters["@mota"].Value = DBNull.Value;
            }
            else
            {
                sql.Parameters["@mota"].Value = ItemEvent.MoTa;
            }
        }

        private void InsertIntoTableSK()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlIns = new SqlCommand("insert into dbo.SUKIEN (USERNAME, TIEUDE, NGAY, TOINGAY, MONHOC, MOTA) VALUES (@username, @tieude, @ngay, @toingay, @monhoc, @mota)", sqlCon);
            sqlIns.Parameters.Add("@username", SqlDbType.VarChar);
            sqlIns.Parameters["@username"].Value = CaiDat.GetPreUsername();

            SetValueOfTableSK(ref sqlIns);
            sqlIns.ExecuteNonQuery();
            sqlIns.Dispose();

            SqlCommand sqlSelect = new SqlCommand("select max(IDSK) from dbo.SUKIEN", sqlCon);
            var reader = sqlSelect.ExecuteReader();
            while (reader.Read())
            {
                ItemEvent.ID = reader.GetInt32(0);
            }
            reader.Close();
            sqlSelect.Dispose();

            if (ItemEvent.ID == -1)
            {
                MessageBox.Show("Lấy ID sự kiện không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InsertIntoTHONGBAO();

            sqlCon.Close();
        }

        private void InsertIntoTHONGBAO()
        {
            var listTB = ItemEvent.ListTB.Distinct().ToList();
            listTB.Sort();
            ItemEvent.ListTB.Clear();
            ItemEvent.ListTB = new List<ItemThongBao>(listTB);

            SqlCommand sqlInsertTB = new SqlCommand($"insert into dbo.THONGBAO (USERNAME, IDSK, GIATRI, DONVI, THOIGIAN) values (@username, @id, @giatri, @donvi, @thoigian)", sqlCon);
            sqlInsertTB.Parameters.Add("@username", SqlDbType.VarChar);
            sqlInsertTB.Parameters.Add("@id", SqlDbType.Int);
            sqlInsertTB.Parameters.Add("@giatri", SqlDbType.Int);
            sqlInsertTB.Parameters.Add("@donvi", SqlDbType.NChar);
            sqlInsertTB.Parameters.Add("@thoigian", SqlDbType.DateTime);
            string username = CaiDat.GetPreUsername();
            int ID = itemEvent.ID;

            int count = ItemEvent.ListTB.Count;
            for (int i = 0; i < count; i++)
            {
                ItemThongBao item = new ItemThongBao(itemEvent.ListTB[i]);
                DateTime date = item.ConvertToTime(ItemEvent.Ngay);
                //sqlInsertTB.Parameters.Clear();

                sqlInsertTB.Parameters["@username"].Value = username;

                sqlInsertTB.Parameters["@id"].Value = ID;

                sqlInsertTB.Parameters["@giatri"].Value = item.GiaTri;

                sqlInsertTB.Parameters["@donvi"].Value = item.DonVi;

                sqlInsertTB.Parameters["@thoigian"].Value = date;
                //try
                //{
                sqlInsertTB.ExecuteNonQuery();
                //}
                //catch (SqlException) 
                //{ 

                //}                
            }
            sqlInsertTB.Dispose();
        }

        private void UpdateInTableSK()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sql = new SqlCommand("update dbo.SUKIEN set TIEUDE = @tieude, NGAY = @ngay, TOINGAY = @toingay, MONHOC = @monhoc, MOTA = @mota WHERE IDSK = @id", sqlCon);
            SetValueOfTableSK(ref sql);
            sql.Parameters.Add("@id", SqlDbType.Int);
            sql.Parameters["@id"].Value = ItemEvent.ID;
            sql.ExecuteNonQuery();

            sql.CommandText = "delete from dbo.THONGBAO where IDSK = @id";
            sql.ExecuteNonQuery();
            sql.Dispose();

            InsertIntoTHONGBAO();
            sqlCon.Close();
        }

        #endregion Database

        private void raBtnNoTimeTo_CheckedChanged(object sender, EventArgs e)
        {
            pnlToTime.Enabled = raBtnTo.Checked;
        }

        private void txtbxTilte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (lbNoEmpty.Visible)
                lbNoEmpty.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            isClickButton = true;
            ItemEvent.Delete();
            if (deleted != null)
                deleted(this, new EventArgs());
            this.Close();
        }

        private void EditSuKien_Deactivate(object sender, EventArgs e)
        {
            if (!isClickButton)
                this.Close();
        }

        private void dtpkNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dtpkNgay.Value;
            SetTime(date);
        }

        private void dtpkToiNgay_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dtpkToiNgay.Value;
            SetToTime(date);
        }

        private int DayOfMonth(int month, int year)
        {
            switch (month)
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
                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                        return 29;
                    else
                        return 28;
                default:
                    return 30;
            }
        }

        private void dmMonth_SelectedItemChanged(object sender, EventArgs e)
        {
            int month = (sender as DomainUpDown).SelectedIndex + 1;
            nmDay.Maximum = DayOfMonth(month, (int)nmYear.Value);
        }

        private void dmToMonth_SelectedItemChanged(object sender, EventArgs e)
        {
            int month = (sender as DomainUpDown).SelectedIndex + 1;
            nmToDay.Maximum = DayOfMonth(month, (int)nmToYear.Value);
        }
    }
}
