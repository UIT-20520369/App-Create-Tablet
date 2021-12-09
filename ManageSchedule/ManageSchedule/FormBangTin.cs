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
using ExcelDataReader;
using DevExpress.Spreadsheet;
using System.IO;
namespace ManageSchedule
{
    public partial class FormBangTin : Form
    {
        //private string strCon = @"Server=204.2.195.207,18708;Database=manageschedule;User=team4;Password=Team45678";
        private SqlConnection sqlCon = null;
        string curuser = "";
        static string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        string ExcelFile = string.Format(@"{0}\Data\TKB.xlsx", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
        Workbook wb = new Workbook();
        static int pos = 1;
        int maxsl = 0;
        public FormBangTin(string x,Workbook e)
        {
            wb = e;
            //wb.LoadDocument(ExcelFile, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
            InitializeComponent();
            curuser = x;
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MAX(stt),MIN(stt) from dbo.THONGTINTKB where username=@us";
            SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
            spr.Value = curuser;
            cmd.Parameters.Add(spr);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
 
                try
                {
                    maxsl = int.Parse(rd.GetString(0));
                }
                catch
                {
                    MessageBox.Show("Vui lòng chọn dữ liệu từ Xem Lịch để có thể sử dụng tính năng này");
                    break;
                }
            }
            rd.Close();
            if(maxsl!=0)
                Input();
               
        }
        private void Input()
        {

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
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from dbo.MAINTKB where username= @us";
            SqlParameter spr = new SqlParameter("@us", SqlDbType.VarChar);
            spr.Value = curuser;
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
                wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine].Fill.BackgroundColor = Color.FromArgb(251, 166, 135);
                wb.Worksheets[0].MergeCells(wb.Worksheets[0].Range[colin + rowins + ":" + colin + rowine]);
                wb.Worksheets[0].Cells[colin + rowins].Value = (rd.GetString(2) + "--" + rd.GetString(1) + "--" + rd.GetString(3)).ToString();
            }
            rd.Close();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            wb.Worksheets[0].Range["A2:H12"].Borders.SetAllBorders(Color.Black, BorderLineStyle.Double);
            wb.Worksheets[0].Range["A2:H12"].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            wb.Worksheets[0].Range["A2:H12"].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            wb.Worksheets[0].Range["A2:H12"].ColumnWidth = 340;
            wb.Worksheets[0].Range["A2:H12"].RowHeight = 100;
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                wb.Worksheets[0].Range["A2:H12"].ExportToImage("TKBM.png", ImageFileFormat.Png);
            }
            else
                try
                {
                    wb.Worksheets[0].Range["A2:H12"].ExportToImage("TKBM.png", ImageFileFormat.Png);
                }
                catch
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        wb.Worksheets[0].Range["A2:H12"].ExportToImage("TKBM.png", ImageFileFormat.Png);
                    }
                }
            pictureBox1.Image = Image.FromFile("TKBM.png");

            wb.SaveDocument(ExcelFile, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
        }

        private void FormBangTin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            this.Dispose();
        }
    }
}
