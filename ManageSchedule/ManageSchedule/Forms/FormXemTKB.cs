using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Spire.Xls;
using System.Drawing.Imaging;

namespace ManageSchedule
{
    public partial class FormXemTKB : Form
    {
        #region Declare

        bool isSave = false;
        Workbook wbExport;
        private SqlConnection sqlCon = null;
        string[,] TKB = new string[12, 10];
        List<DataRow> dtslt = new List<DataRow>();
        List<DataRow> dtsth = new List<DataRow>();
        int maxsl = 0;
        int pos = 0;

        // user from FormTaoLich
        string curuser = "";

        #endregion Declare

        #region Constructor

        public FormXemTKB(string[,] x, List<DataRow> y, List<DataRow> yy, string z)
        {
            InitializeComponent();

            curuser = z;

            if (curuser == "")
            {
                btnLuu.Visible = false;
                btnLuu.Enabled = false;
                btnXuatFile.Location = new Point(472, 692);
                btnThoat.Location = new Point(696, 692);
            }

            TKB = x;
            dtslt = y;
            dtsth = yy;

            // Get the present STT of last Schedule in dbo.THONGTINTKB
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MAX(stt) from dbo.THONGTINTKB where username=@us";
            SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
            spr.Value = curuser;
            cmd.Parameters.Add(spr);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.IsDBNull(0))
                { pos = 0; break; }
                maxsl = int.Parse(rd.GetString(0));
                pos = maxsl++;
            }
            btnLuu.Enabled = true;
            sqlCon.Close();
            // end
            Init();
            btnThoat.Focus();
        }

        #endregion Constructor

        #region Init

        public void Init()
        {
            // Get the path of excel file that is used to save as .xls file
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = System.Configuration.ConfigurationManager.AppSettings["Path"];
            string ExcelFile = string.Format(@"{0}\Data{1}", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")), FileName);
            // Access to an excel

            Workbook wb = new Workbook();
            wb.Worksheets.Add("Sheet 1");
            //wb = data;
            //Design normal infor of excel file
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
            //wb.SaveToFile(ExcelFile, ExcelVersion.Version2013);

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

            // Add and design infor of Schedule in excel file
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    foreach (DataRow row in dtslt)
                    {
                        if (TKB[i, j].Length > 5)
                        {
                            if (TKB[i, j] == row.ItemArray[2].ToString())
                            {
                                string rowins = "";
                                string colin = "";
                                string rowine = "";
                                int td = int.Parse(row.ItemArray[11].ToString()[0].ToString());
                                rowins = (td + 2).ToString();
                                int tc = int.Parse(row.ItemArray[11].ToString()[row.ItemArray[11].ToString().Length - 1].ToString());
                                if (tc == 0) { tc = 10; }
                                rowine = (tc + 2).ToString();
                                int thu = int.Parse(row.ItemArray[10].ToString());
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
                                wb.Worksheets[0].Range[colin + rowins].Value = (row.ItemArray[2].ToString() + Environment.NewLine + row.ItemArray[3].ToString()).ToString();
                                int y = row.ItemArray[2].ToString().Length - 1;
                                ExcelFont z = wb.CreateFont();
                                z.IsBold = true;
                                z.Size = 13;
                                wb.Worksheets[0].Range[colin + rowins].RichText.SetFont(0, y, z);
                                wb.Worksheets[0].Range[colin + rowins].Style.WrapText = true;
                            }
                        }
                    }

                }
            }
            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    foreach (DataRow row in dtsth)
                    {
                        if (TKB[i, j].Length > 5)
                        {
                            if (TKB[i, j] == row.ItemArray[2].ToString())
                            {
                                string rowins = "";
                                string colin = "";
                                string rowine = "";
                                int td = int.Parse(row.ItemArray[11].ToString()[0].ToString());
                                rowins = (td + 2).ToString();
                                int tc = int.Parse(row.ItemArray[11].ToString()[row.ItemArray[11].ToString().Length - 1].ToString());
                                if (tc == 0) { tc = 10; }
                                rowine = (tc + 2).ToString();
                                int thu = int.Parse(row.ItemArray[10].ToString());
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
                                wb.Worksheets[0].Range[colin + rowins].Value = (row.ItemArray[2].ToString() + Environment.NewLine + row.ItemArray[3].ToString()).ToString();
                                int y = row.ItemArray[2].ToString().Length - 1;
                                ExcelFont z = wb.CreateFont();
                                z.IsBold = true;
                                z.Size = 13;
                                wb.Worksheets[0].Range[colin + rowins].RichText.SetFont(0, y, z);
                                wb.Worksheets[0].Range[colin + rowins].Style.WrapText = true;
                            }
                        }
                    }

                }
            }
            if (PictureBoxTKB.Image != null)
            {
                PictureBoxTKB.Image.Dispose();
            }
            // Format excel file
            wb.Worksheets[0].Range["A2:H12"].BorderInside(LineStyleType.Thin, Color.Black);
            wb.Worksheets[0].Range["A2:H12"].BorderAround(LineStyleType.Medium, Color.Black);
            wb.Worksheets[0].Range["A2:H12"].Style.HorizontalAlignment = HorizontalAlignType.Center;
            wb.Worksheets[0].Range["A2:H12"].Style.VerticalAlignment = VerticalAlignType.Center;
            wb.Worksheets[0].Range["A2:H12"].ColumnWidth = 22.0;
            wb.Worksheets[0].Range["A2:H12"].RowHeight = 34;
            //export excel range to .Png file
            wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("TKB.png", ImageFormat.Png);
            //Show the Schedule
            PictureBoxTKB.Image = Image.FromFile("TKB.png");
            // wb.SaveToFile(ExcelFile, ExcelVersion.Version2013);

            wbExport = wb;
        }

        #endregion Init

        #region Thoat

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (dtslt.Count != 0)
            {
                PictureBoxTKB.Image.Dispose();
                this.Dispose();
            }
            this.Close();
        }

        #endregion Thoat

        #region Xuat File Excel

        private void btnXuatFile_Click(object sender, EventArgs e)
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

        #endregion Xuat File Excel

        #region Luu

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtslt.Count == 0)
            {
                MessageBox.Show("Không có môn học trong thời khóa biểu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isSave)
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThoat.Focus();
                return;
            }

            try
            {
                pos++;
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                for (int i = 1; i < 12; i++)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        foreach (DataRow row in dtslt)
                        {
                            if (TKB[i, j].Length > 5)
                            {
                                if (TKB[i, j] == row.ItemArray[2].ToString())
                                {
                                    int thu = int.Parse(row.ItemArray[10].ToString());
                                    SqlCommand sqlCmdInsert = new SqlCommand();
                                    sqlCmdInsert.CommandType = CommandType.Text;
                                    sqlCmdInsert.CommandText = "insert into dbo.THONGTINTKB (username, mamon, tenmon, malop, thu, tiet, stt) values (@username, @mamon, @tenmon, @malop, @thu, @tiet, @stt)";

                                    SqlParameter paruser = new SqlParameter("@username", SqlDbType.VarChar);
                                    paruser.Value = curuser;

                                    SqlParameter parmamon = new SqlParameter("@mamon", SqlDbType.VarChar);
                                    parmamon.Value = row.ItemArray[1].ToString();

                                    SqlParameter partenmon = new SqlParameter("@tenmon", SqlDbType.NVarChar);
                                    partenmon.Value = row.ItemArray[3].ToString();

                                    SqlParameter parmalop = new SqlParameter("@malop", SqlDbType.VarChar);
                                    parmalop.Value = row.ItemArray[2].ToString();

                                    SqlParameter parthu = new SqlParameter("@thu", SqlDbType.VarChar);
                                    parthu.Value = thu.ToString();

                                    SqlParameter partiet = new SqlParameter("@tiet", SqlDbType.VarChar);
                                    partiet.Value = row.ItemArray[11].ToString();

                                    SqlParameter parstt = new SqlParameter("@stt", SqlDbType.VarChar);
                                    parstt.Value = pos.ToString();

                                    sqlCmdInsert.Parameters.Add(paruser);
                                    sqlCmdInsert.Parameters.Add(parmamon);
                                    sqlCmdInsert.Parameters.Add(partenmon);
                                    sqlCmdInsert.Parameters.Add(parmalop);
                                    sqlCmdInsert.Parameters.Add(parthu);
                                    sqlCmdInsert.Parameters.Add(partiet);
                                    sqlCmdInsert.Parameters.Add(parstt);

                                    sqlCmdInsert.Connection = sqlCon;
                                    try
                                    {
                                        int kq = sqlCmdInsert.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    sqlCmdInsert.Dispose();
                                }
                            }
                        }

                    }
                }

                for (int i = 1; i < 12; i++)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        foreach (DataRow row in dtsth)
                        {
                            if (TKB[i, j].Length > 5)
                            {
                                if (TKB[i, j] == row.ItemArray[2].ToString())
                                {
                                    int thu = int.Parse(row.ItemArray[10].ToString());
                                    SqlCommand sqlCmdInsert = new SqlCommand();
                                    sqlCmdInsert.CommandType = CommandType.Text;
                                    sqlCmdInsert.CommandText = "insert into dbo.THONGTINTKB (username, mamon, tenmon, malop, thu, tiet, stt) values (@username, @mamon, @tenmon, @malop, @thu, @tiet, @stt)";

                                    SqlParameter paruser = new SqlParameter("@username", SqlDbType.VarChar);
                                    paruser.Value = curuser;

                                    SqlParameter parmamon = new SqlParameter("@mamon", SqlDbType.VarChar);
                                    parmamon.Value = row.ItemArray[1].ToString();

                                    SqlParameter partenmon = new SqlParameter("@tenmon", SqlDbType.NVarChar);
                                    partenmon.Value = row.ItemArray[3].ToString();

                                    SqlParameter parmalop = new SqlParameter("@malop", SqlDbType.VarChar);
                                    parmalop.Value = row.ItemArray[2].ToString();

                                    SqlParameter parthu = new SqlParameter("@thu", SqlDbType.VarChar);
                                    parthu.Value = thu.ToString();

                                    SqlParameter partiet = new SqlParameter("@tiet", SqlDbType.VarChar);
                                    partiet.Value = row.ItemArray[11].ToString();

                                    SqlParameter parstt = new SqlParameter("@stt", SqlDbType.VarChar);
                                    parstt.Value = pos.ToString();

                                    sqlCmdInsert.Parameters.Add(paruser);
                                    sqlCmdInsert.Parameters.Add(parmamon);
                                    sqlCmdInsert.Parameters.Add(partenmon);
                                    sqlCmdInsert.Parameters.Add(parmalop);
                                    sqlCmdInsert.Parameters.Add(parthu);
                                    sqlCmdInsert.Parameters.Add(partiet);
                                    sqlCmdInsert.Parameters.Add(parstt);

                                    sqlCmdInsert.Connection = sqlCon;
                                    try
                                    {
                                        int kq = sqlCmdInsert.ExecuteNonQuery();
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    sqlCmdInsert.Dispose();
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sqlCon.Close();
                isSave = true;
                btnThoat.Focus();
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Luu

        private void FormXemTKB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PictureBoxTKB.Image != null)
                PictureBoxTKB.Image.Dispose();
        }
    }
}
