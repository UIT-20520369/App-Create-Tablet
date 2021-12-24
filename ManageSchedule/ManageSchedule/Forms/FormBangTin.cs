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
using System.Drawing.Imaging;
using Spire.Xls;

namespace ManageSchedule
{
    public partial class FormBangTin : Form
    {
        #region Declare

        Workbook wbExport;
        private SqlConnection sqlCon = null;
        private string curUser = string.Empty;

        #endregion Declare

        #region Constructor

        public FormBangTin(string x)
        {
            InitializeComponent();

            curUser = x;

            try
            {
                ShowTKB();
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Constructor

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

            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from dbo.MAINTKB where username= @us";
            SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
            spr.Value = curUser;
            cmd.Parameters.Add(spr);
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
                string MaLop = rd.GetString(3);
                wb.Worksheets[0].Range[colin + rowins].Value = (MaLop + Environment.NewLine + rd.GetString(2)).ToString();
                int y = MaLop.Length - 1;
                ExcelFont z = wb.CreateFont();
                z.IsBold = true;
                z.Size = 13;
                wb.Worksheets[0].Range[colin + rowins].RichText.SetFont(0, y, z);
                wb.Worksheets[0].Range[colin + rowins].Style.WrapText = true;
            }
            rd.Close();
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
            wb.Worksheets[0].Range["A2:H12"].RowHeight = 34;
            if (PictureBoxTKB.Image != null)
            {
                PictureBoxTKB.Image.Dispose();
                wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB2.png", ImageFormat.Png);
            }
            else
                try
                {
                    wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB2.png", ImageFormat.Png);
                }
                catch
                {
                    if (PictureBoxTKB.Image != null)
                    {
                        PictureBoxTKB.Image.Dispose();
                        wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB2.png", ImageFormat.Png);
                    }
                }

            wbExport = wb;
            PictureBoxTKB.Image = Image.FromFile("TKB2.png");
        }

        #endregion Show TKB

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
            }
        }

        #endregion Export excel

        #region Delete

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand cmdd = new SqlCommand();
                cmdd.Connection = sqlCon;
                cmdd.CommandType = CommandType.Text;
                cmdd.CommandText = "delete from dbo.MAINTKB";
                SqlDataReader rdd = cmdd.ExecuteReader();
                rdd.Close();

                ShowTKB();
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Delete

        private void FormBangTin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            if (PictureBoxTKB.Image != null)
                PictureBoxTKB.Image.Dispose();
        }
    }
}
