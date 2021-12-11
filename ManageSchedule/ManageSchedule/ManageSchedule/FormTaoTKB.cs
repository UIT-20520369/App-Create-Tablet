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
using ExcelDataReader;
using System.Text.RegularExpressions;

namespace ManageSchedule
{
    public partial class FormTaoTKB : Form
    {
        private static List<List<Button>> listButton = new List<List<Button>>();
        DataSet ds = new DataSet();
        string[,] TKB = new string[11, 8];
        List<Color> listColor = new List<Color>() { Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Pink, Color.Purple, Color.Aqua, Color.CadetBlue };
        int posColor = -1;
        public FormTaoTKB()
        {
            InitializeComponent();
        }

        private void FormTaoTKB_Load(object sender, EventArgs e)
        {
            Button tempBtn = new Button();
            List<Button> buttons1 = new List<Button>() { tempBtn, btn21, btn31, btn41, btn51, btn61, btn71, btnCN1 };
            List<Button> buttons2 = new List<Button>() { tempBtn, btn22, btn32, btn42, btn52, btn62, btn72, btnCN2 };
            List<Button> buttons3 = new List<Button>() { tempBtn, btn23, btn33, btn43, btn53, btn63, btn73, btnCN3 };
            List<Button> buttons4 = new List<Button>() { tempBtn, btn24, btn34, btn44, btn54, btn64, btn74, btnCN4 };
            List<Button> buttons5 = new List<Button>() { tempBtn, btn25, btn35, btn45, btn55, btn65, btn75, btnCN5 };
            List<Button> buttons6 = new List<Button>() { tempBtn, btn26, btn36, btn46, btn56, btn66, btn76, btnCN6 };
            List<Button> buttons7 = new List<Button>() { tempBtn, btn27, btn37, btn47, btn57, btn67, btn77, btnCN7 };
            List<Button> buttons8 = new List<Button>() { tempBtn, btn28, btn38, btn48, btn58, btn68, btn78, btnCN8 };
            List<Button> buttons9 = new List<Button>() { tempBtn, btn29, btn39, btn49, btn59, btn69, btn79, btnCN9 };
            List<Button> buttons10 = new List<Button>() { tempBtn, btn210, btn310, btn410, btn510, btn610, btn710, btnCN10 };
            listButton.AddRange(new List<Button>[] { buttons1, buttons2, buttons3, buttons4, buttons5, buttons6, buttons7, buttons8, buttons9, buttons10 });
            //string dir = System.IO.Directory.GetCurrentDirectory();
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 8; j++)
                    TKB[i, j] = string.Empty;

            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string ExcelFile = string.Format(@"{0}\Data\21-22-SEM1.xlsx", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));

            using (var stream = File.Open(ExcelFile, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;

                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                ds = reader.AsDataSet();

                reader.Close();
            }

            DataTable dt = ds.Tables[0];
            bool isAdd = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].ToString() == "1")
                    isAdd = true;

                if (isAdd)
                    dtgvChonLop.Rows.Add(new object[] { 
                        dt.Rows[i].ItemArray[0].ToString(),
                        dt.Rows[i].ItemArray[1].ToString(),
                        dt.Rows[i].ItemArray[2].ToString(),
                        dt.Rows[i].ItemArray[3].ToString(),
                        dt.Rows[i].ItemArray[7].ToString(),
                        dt.Rows[i].ItemArray[10].ToString(),
                        dt.Rows[i].ItemArray[11].ToString(),
                        dt.Rows[i].ItemArray[17].ToString(),
                    });
            }

            //dtgvChonLop.DataSource = ds.Tables[0];
            //bunifuDataGridView1;
        }

        public static bool isMaMonMaLop(string input)
        {
            //@"^[a-zA-Z0-9.]{4,20}$" +
            string strRegex1 =  @"(?=.*\d)(?=.*[a-z])";
            string strRegex2 = @"(?=.*\d)(?=.*[A-Z])";
            Regex re1 = new Regex(strRegex1);
            Regex re2 = new Regex(strRegex2);
            if (re1.IsMatch(input) || re2.IsMatch(input))
                return (true);
            else
                return (false);
        }

        private void txtBoxSearch_TextChange(object sender, EventArgs e)
        {
            dtgvChonLop.Rows.Clear();
            bool isAdd = false;
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].ItemArray[0].ToString() == "1")
                    isAdd = true;

                string code = txtBoxSearch.Text.ToUpper();
                if (isAdd)
                {
                    string MaMon = dt.Rows[i].ItemArray[1].ToString();
                    string MaLop = dt.Rows[i].ItemArray[2].ToString();
                    if (MaMon.Contains(code) || MaLop.Contains(code))
                        dtgvChonLop.Rows.Add(new object[] {
                            dt.Rows[i].ItemArray[0].ToString(),
                            dt.Rows[i].ItemArray[1].ToString(),
                            dt.Rows[i].ItemArray[2].ToString(),
                            dt.Rows[i].ItemArray[3].ToString(),
                            dt.Rows[i].ItemArray[7].ToString(),
                            dt.Rows[i].ItemArray[10].ToString(),
                            dt.Rows[i].ItemArray[11].ToString(),
                            dt.Rows[i].ItemArray[17].ToString(),
                            });
                }

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dtgvChonLop.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int idx = dtgvChonLop.SelectedRows[0].Index;
                int thu = int.Parse(dtgvChonLop.Rows[idx].Cells[5].Value.ToString());
                string tiets = dtgvChonLop.Rows[idx].Cells[6].Value.ToString();

                bool isAdd = true;
                for (int i = 0; i < tiets.Length; i++)
                {
                    int tiet = int.Parse(tiets[i].ToString());
                    if (tiet == 0)
                        tiet = 10;

                    if (TKB[tiet, thu] != string.Empty)
                    {
                        isAdd = false;
                        MessageBox.Show(dtgvChonLop.Rows[idx].Cells[2].Value.ToString() + " trùng lịch với " + TKB[tiet, thu]);
                        break;
                    }
                }

                if (isAdd)
                {
                    posColor++;
                    if (posColor == listColor.Count)
                        posColor = 0;
                    for (int i = 0; i < tiets.Length; i++)
                    {
                        int tiet = int.Parse(tiets[i].ToString());
                        if (tiet == 0)
                            tiet = 10;
                        listButton[tiet - 1][thu - 1].BackColor = listColor[posColor];
                        TKB[tiet, thu] = dtgvChonLop.Rows[idx].Cells[2].Value.ToString();
                    }
                    dtgvChonLop.Rows[idx].Selected = false;
                }
            }
        }

        private void ShowInfo(object sender, EventArgs e)
        {
            Button curBtn = (Button)sender;
            for (int i = 0; i < listButton.Count; i++)
                for (int j = 0; j < listButton[i].Count; j++)
                {
                    if (curBtn == listButton[i][j])
                    {
                        foreach(DataRow row in ds.Tables[0].Rows)
                        {
                            if (TKB[i + 1, j + 1] == row.ItemArray[2].ToString())
                            {
                                labelMaMon.Text = row.ItemArray[1].ToString();
                                labelMaLop.Text = row.ItemArray[2].ToString();
                                labelTenMon.Text = row.ItemArray[3].ToString();
                                labelTinChi.Text = row.ItemArray[7].ToString();
                                labelThu.Text = row.ItemArray[10].ToString();
                                labelTiet.Text = row.ItemArray[11].ToString();
                                labelHdt.Text = row.ItemArray[17].ToString();
                                break;
                            }
                        }
                        break;
                    }
                }
        }

        private void btnXoaLop_Click(object sender, EventArgs e)
        {
            string s = labelMaMon.Text.Trim();
            if (s == string.Empty)
                return;

            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 8; j++)
                    if (TKB[i, j] == labelMaLop.Text)
                    {
                        listButton[i - 1][j - 1].BackColor = Color.Silver;
                        TKB[i, j] = string.Empty;
                    }
            labelMaMon.Text = string.Empty;
            labelMaLop.Text = string.Empty;
            labelTenMon.Text = string.Empty;
            labelTinChi.Text = string.Empty;
            labelThu.Text = string.Empty;
            labelTiet.Text = string.Empty;
            labelHdt.Text = string.Empty;
        }
    }
}
