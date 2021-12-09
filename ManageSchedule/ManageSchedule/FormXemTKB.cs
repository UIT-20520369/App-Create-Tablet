using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Spreadsheet;
using System.IO;
using ExcelDataReader;
using System.Data.SqlClient;
namespace ManageSchedule
{
    public partial class FormXemTKB : Form
    {
        //private string strCon = @"Server=204.2.195.207,18708;Database=manageschedule;User=team4;Password=Team45678";
        private SqlConnection sqlCon = null;
        string[,] TKB = new string[12, 10];
        List<DataRow> dtslt = new List<DataRow>();
        List<DataRow> dtsth = new List<DataRow>();

        int maxsl = 0;
        int pos = 0;
        string curuser = "";
        Workbook data = new Workbook();
        public FormXemTKB(string[,] x, List<DataRow> y, List<DataRow> yy, string z, Workbook e)
        {
            curuser = z;
            InitializeComponent();
            TKB = x;
            dtslt = y;
            dtsth = yy;
            data = e;
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
            sqlCon.Close();
            Init();
        }
        public void Init()
        {
           /* string RunningPath0 = AppDomain.CurrentDomain.BaseDirectory;
            string ExcelFile0 = string.Format(@"{0}\Data\21-22-SEM1.xlsx", Path.GetFullPath(Path.Combine(RunningPath0, @"..\..\")));

            var stream = File.Open(ExcelFile0, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader;

            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            dtslt = reader.AsDataSet();

            reader.Close();*/
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string ExcelFile = string.Format(@"{0}\Data\TKB.xlsx", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            Workbook wb = new Workbook();
            wb = data;
            //wb.LoadDocument(ExcelFile, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
            wb.Worksheets[0].Cells["B3"].Value = "1";
            wb.Worksheets[0].Cells["B4"].Value = "2";
            wb.Worksheets[0].Cells["B5"].Value = "3";
            wb.Worksheets[0].Cells["B6"].Value = "4";
            wb.Worksheets[0].Cells["B7"].Value = "5";
            wb.Worksheets[0].Cells["B8"].Value = "6";
            wb.Worksheets[0].Cells["B9"].Value = "7";
            wb.Worksheets[0].Cells["B10"].Value = "8";
            wb.Worksheets[0].Cells["B11"].Value = "9";
            wb.Worksheets[0].Cells["B12"].Value = "10";
            wb.SaveDocument(ExcelFile, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
            foreach (var item in wb.Worksheets[0].Cells.GetMergedRanges())
            {
                item.UnMerge();
            }
            wb.Worksheets[0].MergeCells(wb.Worksheets[0].Range["A3:A7"]);
            wb.Worksheets[0].MergeCells(wb.Worksheets[0].Range["A1:H1"]);
            wb.Worksheets[0].MergeCells(wb.Worksheets[0].Range["A8:A12"]);
            wb.Worksheets[0].ClearContents(wb.Worksheets[0].Range["C3:H12"]);
            wb.Worksheets[0].Range["A2:H12"].Fill.BackgroundColor = Color.White;
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
                                wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Fill.BackgroundColor = Color.FromArgb(251, 166, 135);
                                wb.Worksheets[0].MergeCells(wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine]);
                                wb.Worksheets[0].Cells[colin + rowins].Value = (row.ItemArray[3].ToString() + " " + row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString()).ToString();
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
                                wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Fill.BackgroundColor = Color.FromArgb(251, 166, 135);
                                wb.Worksheets[0].MergeCells(wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine]);
                                wb.Worksheets[0].Cells[colin + rowins].Value = (row.ItemArray[3].ToString() + " " + row.ItemArray[1].ToString() + " " + row.ItemArray[2].ToString()).ToString();
                            }
                        }
                    }

                }
            }
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            wb.Worksheets[0].Range["A2:H12"].Borders.SetAllBorders(Color.Black, BorderLineStyle.Double);
            wb.Worksheets[0].Range["A2:H12"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wb.Worksheets[0].Range["A2:H12"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wb.Worksheets[0].Range["A2:H12"].ColumnWidth = 300;
            wb.Worksheets[0].Range["A2:H12"].RowHeight = 100;
            wb.Worksheets[0].Range["A2:H12"].ExportToImage("TKB.png", ImageFileFormat.Png);
            pictureBox1.Image = Image.FromFile("TKB.png");
            wb.SaveDocument(ExcelFile, DevExpress.Spreadsheet.DocumentFormat.Xlsx);

        }

        private void btnLuu_Click(object sender, EventArgs e)
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
            MessageBox.Show("Đã lưu thành công");
            sqlCon.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}