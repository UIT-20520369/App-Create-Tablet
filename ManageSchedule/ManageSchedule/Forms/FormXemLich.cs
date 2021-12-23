using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Spire.Xls;
using System.Drawing.Imaging;

namespace ManageSchedule
{
    public partial class FormXemLich : Form
    {
        #region Declare

        private SqlConnection sqlCon = null;
        private string curUser = "";
        private string chooseUser = string.Empty;
        private string sttc = string.Empty;
        private int pos = 1;
        private int maxSL = 0;
        private int Count = 0;
        Workbook wbExport;

        #endregion Declare

        #region Constructor

        public FormXemLich(string x)
        {
            InitializeComponent();

            curUser = x;
            btnLeft.Visible = false;

            Init();
        }

        #endregion Constructor

        #region Init

        private void Init()
        {
            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                CountTKB();

                if (Count <= 0)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    PictureBoxTKB.Visible = false;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    btnXuatFile.Visible = false;
                    btnXoa.Visible = false;
                    btnSetDefault.Visible = false;
                    labelPos.Visible = false;
                    return;
                }

                if (Count == 1)
                {
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    ShowTKB();
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select MAX(stt),MIN(stt) from dbo.THONGTINTKB where username=@us";
                SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
                spr.Value = curUser;
                cmd.Parameters.Add(spr);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    try
                    {
                        maxSL = int.Parse(rd.GetString(0));
                        pos = int.Parse(rd.GetString(1));
                    }
                    catch
                    {
                        MessageBox.Show("Vui lòng tạo lịch để có thể sử dụng tính năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                rd.Close();

                if (maxSL != 0)
                    Input();
            }
            catch 
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Init

        #region Input

        private void Input()
        {
            Workbook wb = new Workbook();
            wb.Worksheets.Add("Sheet 1");
            wb.Worksheets[0].Range["A2"].Value = "Buổi";
            wb.Worksheets[0].Range["A3"].Value = "Sáng";
            wb.Worksheets[0].Range["A8"].Value = "Chiều";
            wb.Worksheets[0].Range["B2"].Value = "Thứ / Tiết";
            wb.Worksheets[0].Range["C2"].Value = "Thứ 2";
            wb.Worksheets[0].Range["D2"].Value = "Thứ 3";
            wb.Worksheets[0].Range["E2"].Value = "Thứ 4";
            wb.Worksheets[0].Range["F2"].Value = "Thứ 5";
            wb.Worksheets[0].Range["G2"].Value = "Thứ 6";
            wb.Worksheets[0].Range["H2"].Value = "Thứ 7";
            wb.Worksheets[0].Range["B3"].Value = "Tiết 1" + Environment.NewLine + "(7:30 - 8:15)";
            wb.Worksheets[0].Range["B4"].Value = "Tiết 2" + Environment.NewLine + "(8:15 - 9:00)";
            wb.Worksheets[0].Range["B5"].Value = "Tiết 3" + Environment.NewLine + "(9:00 - 9:45)";
            wb.Worksheets[0].Range["B6"].Value = "Tiết 4" + Environment.NewLine + "(10:00 - 10:45)";
            wb.Worksheets[0].Range["B7"].Value = "Tiết 5" + Environment.NewLine + "(10:45 - 11:30)";
            wb.Worksheets[0].Range["B8"].Value = "Tiết 6" + Environment.NewLine + "(13:00 - 13:45)";
            wb.Worksheets[0].Range["B9"].Value = "Tiết 7" + Environment.NewLine + "(13:45 - 14:30)";
            wb.Worksheets[0].Range["B10"].Value = "Tiết 8" + Environment.NewLine + "(14:30 - 15:15)";
            wb.Worksheets[0].Range["B11"].Value = "Tiết 9" + Environment.NewLine + "(15:30 - 16:15)";
            wb.Worksheets[0].Range["B12"].Value = "Tiết 10" + Environment.NewLine + "(16:15 - 17:00)";

            wb.Worksheets[0].Range["A3:A7"].Merge();
            wb.Worksheets[0].Range["A1:H1"].Merge();
            wb.Worksheets[0].Range["A8:A12"].Merge();
            wb.Worksheets[0].Range["A2:H12"].Style.Color = Color.FromArgb(171, 171, 171);
            wb.Worksheets[0].Range["A2:H12"].Style.Font.Size = 10;
            wb.Worksheets[0].Range["A2:H2"].Style.Font.Size = 11;
            wb.Worksheets[0].Range["A2:H2"].Style.Font.IsBold = true;
            wb.Worksheets[0].Range["B3:B12"].Style.Font.IsBold = true;
            wb.Worksheets[0].Range["B3:B12"].Style.Font.Size = 11;
            wb.Worksheets[0].Range["A2:H2"].Style.Color = Color.FromArgb(210, 210, 210);

            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from dbo.THONGTINTKB where username= @us and stt= @n";
            SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
            spr.Value = curUser;
            cmd.Parameters.Add(spr);
            SqlParameter stt = new SqlParameter("@n", SqlDbType.VarChar);
            stt.Value = pos.ToString();
            cmd.Parameters.Add(stt);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                string rowins = "";
                string colin = "";
                string rowine = "";
                int td = int.Parse((rd.GetString(5))[0].ToString());
                rowins = (td + 2).ToString();
                int tc = int.Parse(rd.GetString(5)[rd.GetString(5).Length - 1].ToString());
                if (tc == 0) { tc = 10; }
                rowine = (tc + 2).ToString();
                int thu = int.Parse(rd.GetString(4));
                if (thu == 2)
                {
                    colin = "C";
                }
                else if (thu == 3)
                {
                    colin = "D";
                }
                else if (thu == 4)
                {
                    colin = "E";
                }
                else if (thu == 5)
                {
                    colin = "F";
                }
                else if (thu == 6)
                {
                    colin = "G";
                }
                else if (thu == 7)
                {
                    colin = "H";
                }
                wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Style.Color = Color.FromArgb(255, 255, 255);
                wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Merge();
                wb.Worksheets[0].Range[colin + rowins].Value = (rd.GetString(3) + Environment.NewLine + rd.GetString(2)).ToString();
                int y = rd.GetString(3).Length - 1;
                ExcelFont z = wb.CreateFont();
                z.IsBold = true;
                z.Size = 13;
                wb.Worksheets[0].Range[colin + rowins].RichText.SetFont(0, y, z);
                wb.Worksheets[0].Range[colin + rowins].Style.WrapText = true;
            }
            rd.Close();
            sqlCon.Close();

            if (PictureBoxTKB.Image != null)
            {
                PictureBoxTKB.Image.Dispose();
            }
            wb.Worksheets[0].Range["A2:H12"].BorderInside(LineStyleType.Thin, Color.Black);
            wb.Worksheets[0].Range["A2:H12"].BorderAround(LineStyleType.Medium, Color.Black);
            wb.Worksheets[0].Range["A2:H12"].Style.HorizontalAlignment = HorizontalAlignType.Center;
            wb.Worksheets[0].Range["A2:H12"].Style.VerticalAlignment = VerticalAlignType.Center;
            wb.Worksheets[0].Range["A2:H12"].Style.Font.Size = 13;
            wb.Worksheets[0].Range["A2:H12"].ColumnWidth = 20.0;
            wb.Worksheets[0].Range["A2:H12"].RowHeight = 32;

            if (PictureBoxTKB.Image != null)
            {
                PictureBoxTKB.Image.Dispose();
                wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
            }
            else
                try
                {
                    wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
                }
                catch
                {
                    if (PictureBoxTKB.Image != null)
                    {
                        PictureBoxTKB.Image.Dispose();
                        wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
                    }
                }

            wbExport = wb;
            labelPos.Text = pos.ToString() + " / " + Count.ToString();
            PictureBoxTKB.Image = Image.FromFile("TKB.png");
        }

        #endregion Input

        #region Left Click

        private void btnLeft_Click(object sender, EventArgs e)
        {
            // Sau = Right, Truoc = Left
            if (pos < 1)
            {
                btnLeft.Visible = false;
                return;
            }

            if (btnRight.Visible == false)
                btnRight.Visible = true;
            pos--;
            if (pos == 1)
                btnLeft.Visible = false;

            ShowTKB();
        }

        #endregion Left Click

        #region Right Click

        private void btnRight_Click(object sender, EventArgs e)
        {
            if (btnLeft.Visible == false)
                btnLeft.Visible = true;

            if (pos >= Count)
            {
                btnRight.Visible = false;
                return;
            }

            if (btnLeft.Visible == false)
                btnLeft.Visible = true;
            pos++;
            if (pos == Count)
                btnRight.Visible = false;

            ShowTKB();
        }

        #endregion Right Click

        #region Show TKB

        private void ShowTKB()
        {
            Workbook wb = new Workbook();
            wb.Worksheets.Add("Sheet 1");

            #region Set default Columns and Rows

            wb.Worksheets[0].Range["A2"].Value = "Buổi";
            wb.Worksheets[0].Range["A3"].Value = "Sáng";
            wb.Worksheets[0].Range["A8"].Value = "Chiều";
            wb.Worksheets[0].Range["B2"].Value = "Tiết";
            wb.Worksheets[0].Range["C2"].Value = "Thứ 2";
            wb.Worksheets[0].Range["D2"].Value = "Thứ 3";
            wb.Worksheets[0].Range["E2"].Value = "Thứ 4";
            wb.Worksheets[0].Range["F2"].Value = "Thứ 5";
            wb.Worksheets[0].Range["G2"].Value = "Thứ 6";
            wb.Worksheets[0].Range["H2"].Value = "Thứ 7";
            wb.Worksheets[0].Range["B3"].Value = "Tiết 1" + Environment.NewLine + "(7:30 - 8:15)";
            wb.Worksheets[0].Range["B4"].Value = "Tiết 2" + Environment.NewLine + "(8:15 - 9:00)";
            wb.Worksheets[0].Range["B5"].Value = "Tiết 3" + Environment.NewLine + "(9:00 - 9:45)";
            wb.Worksheets[0].Range["B6"].Value = "Tiết 4" + Environment.NewLine + "(10:00 - 10:45)";
            wb.Worksheets[0].Range["B7"].Value = "Tiết 5" + Environment.NewLine + "(10:45 - 11:30)";
            wb.Worksheets[0].Range["B8"].Value = "Tiết 6" + Environment.NewLine + "(13:00 - 13:45)";
            wb.Worksheets[0].Range["B9"].Value = "Tiết 7" + Environment.NewLine + "(13:45 - 14:30)";
            wb.Worksheets[0].Range["B10"].Value = "Tiết 8" + Environment.NewLine + "(14:30 - 15:15)";
            wb.Worksheets[0].Range["B11"].Value = "Tiết 9" + Environment.NewLine + "(15:30 - 16:15)";
            wb.Worksheets[0].Range["B12"].Value = "Tiết 10" + Environment.NewLine + "(16:15 - 17:00)";

            #endregion Set default Columns and Rows

            wb.Worksheets[0].Range["A3:A7"].Merge();
            wb.Worksheets[0].Range["A1:H1"].Merge();
            wb.Worksheets[0].Range["A8:A12"].Merge();
            wb.Worksheets[0].Range["A2:H12"].Style.Color = Color.FromArgb(171, 171, 171);
            wb.Worksheets[0].Range["A2:H12"].Style.Font.Size = 10;
            wb.Worksheets[0].Range["A2:H2"].Style.Font.Size = 11;
            wb.Worksheets[0].Range["A2:H2"].Style.Font.IsBold = true;
            wb.Worksheets[0].Range["B3:B12"].Style.Font.IsBold = true;
            wb.Worksheets[0].Range["B3:B12"].Style.Font.Size = 11;
            wb.Worksheets[0].Range["A2:H2"].Style.Color = Color.FromArgb(210, 210, 210);

            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dbo.THONGTINTKB where username= @us and stt= @n";
                SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
                spr.Value = curUser;
                cmd.Parameters.Add(spr);
                SqlParameter stt = new SqlParameter("@n", SqlDbType.VarChar);
                stt.Value = pos.ToString();
                cmd.Parameters.Add(stt);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string rowins = "";
                    string colin = "";
                    string rowine = "";
                    int td = int.Parse((rd.GetString(5))[0].ToString());
                    rowins = (td + 2).ToString();
                    int tc = int.Parse(rd.GetString(5)[rd.GetString(5).Length - 1].ToString());
                    if (tc == 0) { tc = 10; }
                    rowine = (tc + 2).ToString();
                    int thu = int.Parse(rd.GetString(4));
                    if (thu == 2)
                    {
                        colin = "C";
                    }
                    else if (thu == 3)
                    {
                        colin = "D";
                    }
                    else if (thu == 4)
                    {
                        colin = "E";
                    }
                    else if (thu == 5)
                    {
                        colin = "F";
                    }
                    else if (thu == 6)
                    {
                        colin = "G";
                    }
                    else if (thu == 7)
                    {
                        colin = "H";
                    }
                    wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Style.Color = Color.FromArgb(255, 255, 255);
                    wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Merge();
                    wb.Worksheets[0].Range[colin + rowins].Value = (rd.GetString(3) + Environment.NewLine + rd.GetString(2)).ToString();
                    int y = rd.GetString(3).Length - 1;
                    ExcelFont z = wb.CreateFont();
                    z.IsBold = true;
                    z.Size = 13;
                    wb.Worksheets[0].Range[colin + rowins].RichText.SetFont(0, y, z);
                    wb.Worksheets[0].Range[colin + rowins].Style.WrapText = true;
                }
                rd.Close();
                sqlCon.Close();

                if (PictureBoxTKB.Image != null)
                    PictureBoxTKB.Image.Dispose();

                wb.Worksheets[0].Range["A2:H12"].BorderInside(LineStyleType.Thin, Color.Black);
                wb.Worksheets[0].Range["A2:H12"].BorderAround(LineStyleType.Medium, Color.Black);
                wb.Worksheets[0].Range["A2:H12"].Style.HorizontalAlignment = HorizontalAlignType.Center;
                wb.Worksheets[0].Range["A2:H12"].Style.VerticalAlignment = VerticalAlignType.Center;
                wb.Worksheets[0].Range["A2:H12"].Style.Font.Size = 13;
                wb.Worksheets[0].Range["A2:H12"].ColumnWidth = 20.0;
                wb.Worksheets[0].Range["A2:H12"].RowHeight = 32;

                if (PictureBoxTKB.Image != null)
                {
                    PictureBoxTKB.Image.Dispose();
                    wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
                }
                else
                {
                    try
                    {
                        wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
                    }
                    catch
                    {
                        if (PictureBoxTKB.Image != null)
                        {
                            PictureBoxTKB.Image.Dispose();
                            wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
                        }
                    }
                }

                wbExport = wb;
                labelPos.Text = pos.ToString() + " / " + Count.ToString();
                PictureBoxTKB.Image = Image.FromFile("TKB.png");
            }
            catch 
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Show TKB

        #region Count TKB

        private void CountTKB()
        {
            Count = 0;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select distinct stt from dbo.THONGTINTKB where username=@us";

            SqlParameter parUser = new SqlParameter("@us", SqlDbType.VarChar);
            parUser.Value = curUser;
            sqlCmd.Parameters.Add(parUser);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
                Count++;
            reader.Close();
        }

        #endregion Count TKB

        #region Delete TKB

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                #region Delete TKB from DB

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from dbo.THONGTINTKB where username= @us and stt= @n";
                SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
                spr.Value = curUser;
                cmd.Parameters.Add(spr);
                SqlParameter stt = new SqlParameter("@n", SqlDbType.VarChar);
                stt.Value = pos.ToString();
                cmd.Parameters.Add(stt);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Close();

                #endregion Delete TKB from DB

                #region Update STT

                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = sqlCon;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update dbo.THONGTINTKB set stt=stt-1 where username= @us and stt > @n";
                SqlParameter spr1 = new SqlParameter("@us", SqlDbType.VarChar);
                spr1.Value = curUser;
                cmd1.Parameters.Add(spr1);
                SqlParameter stt1 = new SqlParameter("@n", SqlDbType.VarChar);
                stt1.Value = pos.ToString();
                cmd1.Parameters.Add(stt1);
                SqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Close();

                #endregion Update STT

                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Count--;

                if (Count == 0)
                {
                    label1.Visible = true;
                    label2.Visible = true;
                    PictureBoxTKB.Visible = false;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    btnXuatFile.Visible = false;
                    btnXoa.Visible = false;
                    btnSetDefault.Visible = false;
                    labelPos.Visible = false;
                    return;
                }

                if (Count == 1)
                {
                    pos = 1;
                    btnLeft.Visible = false;
                    btnRight.Visible = false;
                    ShowTKB();
                    return;
                }

                if (pos == 1)
                {
                    pos = 1;
                    ShowTKB();
                }
                else
                {
                    pos--;
                    ShowTKB();
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Delete TKB

        #region Export excel

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Export file excel";
            dialog.Filter = "Excel File|*.xlsx";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                wbExport.SaveToFile(dialog.FileName);
                MessageBox.Show("Xuất file excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Export excel

        private void FormXemLich_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PictureBoxTKB.Image != null)
                PictureBoxTKB.Image.Dispose();
        }

        #region Set default

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            try
            {
                sttc = pos.ToString();
                chooseUser = curUser;
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                #region Delete old TKB

                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = sqlCon;
                cmdd.CommandType = CommandType.Text;
                cmdd.CommandText = "delete from dbo.MAINTKB";
                SqlDataReader rdd = cmdd.ExecuteReader();
                rdd.Close();

                #endregion Delete old TKB

                #region Set new TKB

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into dbo.MAINTKB select * from dbo.THONGTINTKB where username= @us and stt= @n";
                SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
                spr.Value = curUser;
                cmd.Parameters.Add(spr);
                SqlParameter stt = new SqlParameter("@n", SqlDbType.VarChar);
                stt.Value = pos.ToString();
                cmd.Parameters.Add(stt);
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Close();

                #endregion Set new TKB

                MessageBox.Show("Đặt làm thời khóa biểu mặc định thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Set default
    }
}
