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

namespace ManageSchedule
{
    public partial class FormTaoLich : Form
    {
        // Variable
        private string HeDaoTao;
        private int posColor;

        // Dataset
        private DataSet ds = new DataSet();

        // Array
        private string[,] strTKB;

        // List
        private List<DataRow> DanhSachMonHocLyThuyet;
        private List<DataRow> DanhSachMonHocThucHanh;
        private List<DataRow> DanhSachLopHocLTDaChon;
        private List<DataRow> DanhSachLopHocTHDaChon;
        private List<string> DanhSachMonChinhTri;
        private List<string> DanhSachMaMonDaChon;
        private List<Color> DanhSachMau;
        private List<List<Button>> TKBMini;
       
        public FormTaoLich(string hdt)
        {
            InitializeComponent();
            ToolTipAdd.SetToolTip(TextBoxSearch, "Tìm kiếm theo mã môn hoặc mã lớp");
            ToolTipAdd.SetToolTip(btnAdd, "Thêm lớp đã chọn từ danh sách vào thời khóa biểu");
            ToolTipAdd.SetToolTip(btnXoa, "Xóa lớp đã chọn trên thời khóa biểu mini");
            ToolTipAdd.SetToolTip(btnXem, "Xem thời khóa biểu chi tiết");

            // Variable
            HeDaoTao = hdt;
            posColor = -1;

            // Array
            strTKB = new string[12, 10];
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 10; j++)
                    strTKB[i, j] = string.Empty;

            // List
            DanhSachMonHocLyThuyet = new List<DataRow>();
            DanhSachMonHocThucHanh = new List<DataRow>();
            DanhSachLopHocLTDaChon = new List<DataRow>();
            DanhSachLopHocTHDaChon = new List<DataRow>();
            DanhSachMaMonDaChon = new List<string>();
            DanhSachMonChinhTri = new List<string>() { "SS003", "SS006", "SS007", "SS008", "SS009", "SS010" };
            DanhSachMau = new List<Color>()
            {
                Color.FromArgb(201, 151, 137), Color.DarkRed,
                Color.FromArgb(44, 105, 117), Color.OrangeRed,
                Color.BlueViolet, Color.FromArgb(11, 7, 66),
                Color.FromArgb(249, 196, 73), Color.FromArgb(93, 110, 30),
                Color.FromArgb(248, 217, 15), Color.DarkMagenta,
            };

            // Tạo list button TKB mini
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
            TKBMini = new List<List<Button>>() { buttons1, buttons2, buttons3, buttons4, buttons5, buttons6, buttons7, buttons8, buttons9, buttons10 };
        }

        private void FormTaoLich_Load(object sender, EventArgs e)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string ExcelFile = string.Format(@"{0}\Data\21-22-SEM1.xlsx", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));

            using (var stream = File.Open(ExcelFile, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;

                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                ds = reader.AsDataSet();

                reader.Close();
            }

            string MaMon = string.Empty;
            string MaLop = string.Empty;
            string TenMon = string.Empty;
            string Thu = string.Empty;
            string Tiet = string.Empty;
            string HDT = string.Empty;

            DataTable dt = ds.Tables[0];
            bool isRowNull = true;
            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray[0].ToString() == "1")
                    isRowNull = false;

                if (isRowNull == true)
                    continue;

                MaMon = row.ItemArray[1].ToString();
                Thu = row.ItemArray[10].ToString();
                Tiet = row.ItemArray[11].ToString();
                HDT = row.ItemArray[17].ToString();

                if ((Thu != "*" && Tiet != "*" && HDT == HeDaoTao) || DanhSachMonChinhTri.IndexOf(MaMon) != -1)
                    DanhSachMonHocLyThuyet.Add(row);
            }

            int count = 0;
            int SoTC = 0;

            List<DataRow> DanhSachLopHocBiXoa = new List<DataRow>();
            foreach (DataRow row in DanhSachMonHocLyThuyet)
            {
                bool isThucHanh = false;
                bool isAdd = false;
                SoTC = int.Parse(row.ItemArray[7].ToString());
                MaLop = row.ItemArray[2].ToString();
                HDT = row.ItemArray[17].ToString();
                foreach (DataRow rowTH in ds.Tables[1].Rows)
                {
                    string hdt = rowTH.ItemArray[17].ToString();
                    string malop = rowTH.ItemArray[2].ToString();
                    if (hdt == HDT && malop.Contains(MaLop))
                    {
                        isThucHanh = true;
                        if (rowTH.ItemArray[10].ToString() != "*" && rowTH.ItemArray[11].ToString() != "*")
                        {
                            if (isAdd == false)
                                SoTC += int.Parse(rowTH.ItemArray[7].ToString());
                            DanhSachMonHocThucHanh.Add(rowTH);
                            isAdd = true;
                        }
                    }
                }

                if (isThucHanh == false || (isThucHanh == true && isAdd == true))
                {
                    count++;
                    MaMon = row.ItemArray[1].ToString();
                    TenMon = row.ItemArray[3].ToString();
                    Thu = row.ItemArray[10].ToString();
                    Tiet = row.ItemArray[11].ToString();
                    row[7] = SoTC;
                    DataGridView.Rows.Add(new string[] { count.ToString(), MaMon, MaLop, TenMon, SoTC.ToString(), Thu, Tiet, HDT, row.ItemArray[18].ToString() });
                }
                else
                    DanhSachLopHocBiXoa.Add(row);
            }

            foreach (DataRow row in DanhSachLopHocBiXoa)
                DanhSachMonHocLyThuyet.Remove(row);

            int idx = DataGridView.SelectedRows[0].Index;
            DataGridView.Rows[idx].Selected = false;
        }

        private void TextBoxSearch_TextChange(object sender, EventArgs e)
        {
            DataGridView.Rows.Clear();
            int count = 0;

            string MaMon = string.Empty;
            string MaLop = string.Empty;
            string TenMon = string.Empty;
            string SoTC = string.Empty;
            string Thu = string.Empty;
            string Tiet = string.Empty;
            string HDT = string.Empty;
            string Khoa = string.Empty;
            string code = TextBoxSearch.Text.Trim().ToUpper();

            foreach (DataRow row in DanhSachMonHocLyThuyet)
            {
                MaMon = row.ItemArray[1].ToString();
                MaLop = row.ItemArray[2].ToString();
                if (MaMon.Contains(code) || MaLop.Contains(code))
                {
                    count++;
                    TenMon = row.ItemArray[3].ToString();
                    SoTC = row.ItemArray[7].ToString();
                    Thu = row.ItemArray[10].ToString();
                    Tiet = row.ItemArray[11].ToString();
                    HDT = row.ItemArray[17].ToString();
                    Khoa = row.ItemArray[18].ToString();
                    DataGridView.Rows.Add(new string[] { count.ToString(), MaMon, MaLop, TenMon, SoTC, Thu, Tiet, HDT, Khoa });
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ResetInfo();

            int selectedRowCount = DataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridView.SelectedRows[0].Index;
            if (DataGridView.Rows[idx].Cells[5].Value == null)
                return;

            string MaMon = DataGridView.Rows[idx].Cells[1].Value.ToString();
            if (DanhSachMaMonDaChon.IndexOf(MaMon) != -1)
            {
                MessageBox.Show("Không thể đăng ký hai lớp khác nhau cho một môn học", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string MaLop = DataGridView.Rows[idx].Cells[2].Value.ToString();

            AddClass(MaLop);

            DataGridView.Rows[idx].Selected = false;
        }

        private void AddClass(string MaLop)
        {
            List<DataRow> tempListLT = new List<DataRow>();
            foreach (DataRow row in DanhSachMonHocLyThuyet)
            {
                if (MaLop == row.ItemArray[2].ToString())
                {
                    string result = CheckTKB(row.ItemArray[10].ToString(), row.ItemArray[11].ToString());
                    if (result != "true")
                    {
                        string message = MaLop + "\n trùng lịch với \n" + result;
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        tempListLT.Add(row);
                }
            }

            List<DataRow> tempListTH = new List<DataRow>();
            string MaLopTH = string.Empty;
            foreach (DataRow row in DanhSachMonHocThucHanh)
            {
                string ml = row.ItemArray[2].ToString();
                if (ml.Contains(MaLop) && MaLopTH == string.Empty)
                    MaLopTH = ml;

                if (MaLopTH == ml)
                {
                    string result = CheckTKB(row.ItemArray[10].ToString(), row.ItemArray[11].ToString());
                    if (result != "true")
                    {
                        string message = MaLop + " trùng lịch với " + result;
                        MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        tempListTH.Add(row);
                }
            }

            posColor++;
            posColor = posColor == DanhSachMau.Count ? 0 : posColor;
            foreach (DataRow row in tempListLT)
            {
                DanhSachLopHocLTDaChon.Add(row);
                AddTKB(row.ItemArray[2].ToString(), row.ItemArray[10].ToString(), row.ItemArray[11].ToString());
            }
            foreach (DataRow row in tempListTH)
            {
                DanhSachLopHocTHDaChon.Add(row);
                AddTKB(row.ItemArray[2].ToString(), row.ItemArray[10].ToString(), row.ItemArray[11].ToString());
            }
            DanhSachMaMonDaChon.Add(tempListLT[0].ItemArray[1].ToString());
        }

        private void ShowInfo(object sender, EventArgs e)
        {
            ResetInfo();

            Button curBtn = (Button)sender;
            for (int i = 0; i < TKBMini.Count; i++)
                for (int j = 0; j < TKBMini[i].Count; j++)
                {
                    if (curBtn == TKBMini[i][j])
                    {
                        bool isNullButton = true;
                        string MaLop = string.Empty; // Lưu mã lớp xử lý phần thực hành
                        string MaLopLT = string.Empty; // dùng để chứa mã lớp của lớp LT đã chọn
                        foreach (DataRow row in DanhSachLopHocLTDaChon)
                        {
                            MaLopLT = row.ItemArray[2].ToString();
                            if (strTKB[i + 1, j + 1].Contains(MaLopLT))
                            {
                                MaLop = MaLopLT;
                                labelMaMon.Text = row.ItemArray[1].ToString();
                                labelMaLop.Text = MaLopLT;
                                labelTenMon.Text = row.ItemArray[3].ToString();
                                labelSoTC.Text = row.ItemArray[7].ToString();
                                if (labelLichHoc.Text == string.Empty)
                                    labelLichHoc.Text = "Thứ " + row.ItemArray[10].ToString() + " tiết " + row.ItemArray[11].ToString();
                                else
                                    labelLichHoc.Text += ", thứ " + row.ItemArray[10].ToString() + " tiết " + row.ItemArray[11].ToString();
                                labelHeDaoTao.Text = row.ItemArray[17].ToString();

                                isNullButton = false;
                            }
                        }

                        if (isNullButton)
                            return;

                        string MaLopTH = string.Empty;
                        bool CoLopTH = false;

                        foreach (DataRow row in DanhSachLopHocTHDaChon)
                        {
                            MaLopTH = row.ItemArray[2].ToString();
                            if (MaLopTH.Contains(MaLop))
                            {
                                labelThucHanh.Text = MaLopTH;
                                if (labelLichTH.Text == string.Empty)
                                    labelLichTH.Text = "Thứ " + row.ItemArray[10].ToString() + " tiết " + row.ItemArray[11].ToString();
                                else
                                    labelLichHoc.Text += ", thứ " + row.ItemArray[10].ToString() + " tiết " + row.ItemArray[11].ToString();

                                CoLopTH = true;
                            }
                        }

                        if (CoLopTH == false)
                        {
                            labelThucHanh.Text = "Không";
                            labelLichTH.Text = "Không";
                        }

                        return;
                    }
                }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (labelMaMon.Text == string.Empty)
                return;

            string MaMon = labelMaMon.Text;
            string MaLopLT = labelMaLop.Text;
            string MaLopTH = labelThucHanh.Text;

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 10; j++)
                    if (strTKB[i, j] == MaLopLT || strTKB[i, j] == MaLopTH)
                    {
                        TKBMini[i - 1][j - 1].BackColor = Color.Silver;
                        strTKB[i, j] = string.Empty;
                    }

            List<DataRow> tempList = new List<DataRow>();

            foreach (DataRow row in DanhSachLopHocLTDaChon)
                if (row.ItemArray[2].ToString() == MaLopLT)
                    tempList.Add(row);
            foreach (DataRow row in tempList)
                DanhSachLopHocLTDaChon.Remove(row);
            tempList.Clear();

            foreach (DataRow row in DanhSachLopHocTHDaChon)
                if (row.ItemArray[2].ToString() == MaLopTH)
                    tempList.Add(row);
            foreach (DataRow row in tempList)
                DanhSachLopHocTHDaChon.Remove(row);

            DanhSachMaMonDaChon.Remove(MaMon);
            ResetInfo();
        }

        private string CheckTKB(string Thu, string tiets)
        {
            int thu = int.Parse(Thu);
            for (int i = 0; i < tiets.Length; i++)
            {
                int tiet = int.Parse(tiets[i].ToString());
                tiet = tiet == 0 ? 10 : tiet;

                if (strTKB[tiet, thu] != string.Empty)
                    return strTKB[tiet, thu];
            }

            return "true";
        }

        private void AddTKB(string MaLop, string Thu, string tiets)
        {
            int thu = int.Parse(Thu);
            for (int i = 0; i < tiets.Length; i++)
            {
                int tiet = int.Parse(tiets[i].ToString());
                tiet = tiet == 0 ? 10 : tiet;

                TKBMini[tiet - 1][thu - 1].BackColor = DanhSachMau[posColor];
                strTKB[tiet, thu] = MaLop;
            }
        }

        private void ResetInfo()
        {
            labelTenMon.Text = string.Empty;
            labelMaMon.Text = string.Empty;
            labelMaLop.Text = string.Empty;
            labelSoTC.Text = string.Empty;
            labelLichHoc.Text = string.Empty;
            labelThucHanh.Text = string.Empty;
            labelLichTH.Text = string.Empty;
            labelHeDaoTao.Text = string.Empty;
        }
    }
}
