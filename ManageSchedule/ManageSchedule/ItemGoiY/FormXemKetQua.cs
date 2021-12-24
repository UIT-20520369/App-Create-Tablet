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

namespace ManageSchedule.ItemGoiY
{
    public partial class FormXemKetQua : Form
    {
        #region Declare

        int Count;
        string curUser = string.Empty;
        SqlConnection sqlCon = null;
        Workbook wbExport;
        List<DataRow> dtslt = new List<DataRow>();
        List<DataRow> dtsth = new List<DataRow>();
        List<string[,]> listTKB = new List<string[,]>();
        int pos = 0;

        #endregion Declare

        public FormXemKetQua(List<string[,]> tempList, List<DataRow> x, List<DataRow> y, string user)
        {
            InitializeComponent();

            listTKB = tempList;
            dtslt = x;
            dtsth = y;
            curUser = user;

            if (curUser == "")
                btnSaveTKB.Enabled = false;

            if (listTKB.Count == 1)
            {
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else
                btnPrevious.Enabled = false;

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnClose, "Thoát chế độ xem thời khóa biểu");

            LabelPos.Text = (pos + 1).ToString() + " / " + listTKB.Count.ToString();
            ShowTKB(listTKB[pos]);
            btnNext.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        #region Show TKB

        private void ShowTKB(string[,] TKB)
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
            if (PictureBoxTKB.Image != null)
            {
                PictureBoxTKB.Image.Dispose();
                wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("GoiY.png", ImageFormat.Png);
            }
            else
            {
                try
                {
                    wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("GoiY.png", ImageFormat.Png);
                }
                catch
                {
                    if (PictureBoxTKB.Image != null)
                    {
                        PictureBoxTKB.Image.Dispose();
                        wb.Worksheets[0].ToImage(2, 2, 12, 8).Save("GoiY.png", ImageFormat.Png);
                    }
                }
            }

            wbExport = wb;
            LabelPos.Text = (pos + 1).ToString() + " / " + listTKB.Count.ToString();
            PictureBoxTKB.Image = Image.FromFile("GoiY.png");
            // wb.SaveToFile(ExcelFile, ExcelVersion.Version2013);

            //wbExport = wb;
        }

        #endregion Show TKB

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos++;
            if (curUser != "")
                btnSaveTKB.Enabled = true;

            if (btnPrevious.Enabled == false)
                btnPrevious.Enabled = true;

            if (pos + 1 == listTKB.Count)
                btnNext.Enabled = false;

            ShowTKB(listTKB[pos]);
            btnNext.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            pos--;
            if (curUser != "")
                btnSaveTKB.Enabled = true;

            if (btnNext.Enabled == false)
                btnNext.Enabled = true;

            if (pos == 0)
                btnPrevious.Enabled = false;

            ShowTKB(listTKB[pos]);
            btnPrevious.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        private void FormXemKetQua_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (PictureBoxTKB.Image != null)
                PictureBoxTKB.Image.Dispose();
        }

        #region Export excel

        private void btnExportExcel_Click(object sender, EventArgs e)
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

        #region Save

        private void btnSaveTKB_Click(object sender, EventArgs e)
        {
            try
            {
                CountTKB();

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
                            if (listTKB[pos][i, j].Length > 5)
                            {
                                if (listTKB[pos][i, j] == row.ItemArray[2].ToString())
                                {
                                    int thu = int.Parse(row.ItemArray[10].ToString());
                                    SqlCommand sqlCmdInsert = new SqlCommand();
                                    sqlCmdInsert.CommandType = CommandType.Text;
                                    sqlCmdInsert.CommandText = "insert into dbo.THONGTINTKB (username, mamon, tenmon, malop, thu, tiet, stt) values (@username, @mamon, @tenmon, @malop, @thu, @tiet, @stt)";

                                    SqlParameter paruser = new SqlParameter("@username", SqlDbType.VarChar);
                                    paruser.Value = curUser;

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
                                    parstt.Value = (Count + 1).ToString();

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
                            if (listTKB[pos][i, j].Length > 5)
                            {
                                if (listTKB[pos][i, j] == row.ItemArray[2].ToString())
                                {
                                    int thu = int.Parse(row.ItemArray[10].ToString());
                                    SqlCommand sqlCmdInsert = new SqlCommand();
                                    sqlCmdInsert.CommandType = CommandType.Text;
                                    sqlCmdInsert.CommandText = "insert into dbo.THONGTINTKB (username, mamon, tenmon, malop, thu, tiet, stt) values (@username, @mamon, @tenmon, @malop, @thu, @tiet, @stt)";

                                    SqlParameter paruser = new SqlParameter("@username", SqlDbType.VarChar);
                                    paruser.Value = curUser;

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
                                    parstt.Value = (Count + 1).ToString() ;

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
                btnSaveTKB.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #endregion Save

        #region Count TKB
        private void CountTKB()
        {
            Count = 0;

            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

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
    }
}
