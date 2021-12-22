using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule.ItemGoiY
{
    public partial class FormChonMaLop : Form
    {
        #region Declare

        private DataSet ds;
        private string HeDaoTao;
        private List<string> DanhSachMonChinhTri;
        private List<DataRow> DanhSachMonHocLyThuyet;
        private List<DataRow> DanhSachMonHocThucHanh;

        #endregion Declare

        public FormChonMaLop(string hdt)
        {
            InitializeComponent();

            HeDaoTao = hdt;

            DanhSachMonChinhTri = new List<string>() { "SS003", "SS006", "SS007", "SS008", "SS009", "SS010" };
            DanhSachMonHocLyThuyet = new List<DataRow>();
            DanhSachMonHocThucHanh = new List<DataRow>();
        }

        #region Form Load
        private void FormChonMaLop_Load(object sender, EventArgs e)
        {
            try
            {
                string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                string FileName = ConfigurationManager.AppSettings["Path"];
                string ExcelFile = string.Format(@"{0}\Data{1}", Path.GetFullPath(Path.Combine(RunningPath, @"..\")), FileName);

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
                string KhoaQL = string.Empty;
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
                        MaLop = row.ItemArray[2].ToString();
                        TenMon = row.ItemArray[3].ToString();
                        Thu = row.ItemArray[10].ToString();
                        Tiet = row.ItemArray[11].ToString();
                        row[7] = SoTC;
                        DataGridViewMaLop.Rows.Add(new string[] { MaLop, TenMon, SoTC.ToString(), Thu, Tiet });
                    }
                    else
                        DanhSachLopHocBiXoa.Add(row);
                }

                foreach (DataRow row in DanhSachLopHocBiXoa)
                    DanhSachMonHocLyThuyet.Remove(row);

                int idx = DataGridViewMaLop.SelectedRows[0].Index;
                DataGridViewMaLop.Rows[idx].Selected = false;
            }
            catch
            {
                MessageBox.Show("File đang được sử dụng ở một tiến trình khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
            }

            Setup();
        }

        #endregion Form Load

        #region Set up

        private void Setup()
        {
            foreach (DataRow row in FormGoiY.DanhSachMaLopDaChon)
            {
                DataGridViewSelected.Rows.Add(row.ItemArray[2].ToString(), row.ItemArray[3].ToString());
            }
        }

        #endregion Set up

        #region Add id class

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int selectedRowCount = DataGridViewMaLop.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridViewMaLop.SelectedRows[0].Index;
            if (DataGridViewMaLop.Rows[idx].Cells[1].Value == null)
                return;

            string MaLop = string.Empty;
            string DTGVMaLop = DataGridViewMaLop.Rows[idx].Cells[0].Value.ToString();
            foreach (DataRow row in DanhSachMonHocLyThuyet)
            {
                MaLop = row.ItemArray[2].ToString();
                if (MaLop == DTGVMaLop)
                {
                    int isAdd = 0;
                    foreach (DataRow rowCheck in FormGoiY.DanhSachMaLopDaChon)
                    {
                        if (MaLop == rowCheck.ItemArray[2].ToString())
                        {
                            isAdd = 1;
                            break;
                        }
                        if (rowCheck.ItemArray[1].ToString() == row.ItemArray[1].ToString())
                        {
                            isAdd = 2;
                            break;
                        }
                    }

                    if (isAdd == 0)
                    {
                        FormGoiY.DanhSachMaLopDaChon.Add(row);
                        DataGridViewSelected.Rows.Add(new string[] { MaLop, row.ItemArray[3].ToString() });
                        MessageBox.Show("Thêm mã lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else
                    {
                        if (isAdd == 1)
                        {
                            MessageBox.Show("Mã lớp đã được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Không thể chọn hai lớp cho cùng một môn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }

                }
            }

            DataGridViewMaLop.Rows[idx].Selected = false;
            btnSelect.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        #endregion Add id class

        #region Search

        private void TextBoxSearch_TextChange(object sender, EventArgs e)
        {
            DataGridViewMaLop.Rows.Clear();
            string code = TextBoxSearch.Text.Trim().ToUpper();
            string MaLop = string.Empty;
            string TenMon = string.Empty;
            string SoTC = string.Empty;
            string Thu = string.Empty;
            string Tiet = string.Empty;

            foreach (DataRow row in DanhSachMonHocLyThuyet)
            {
                MaLop = row.ItemArray[2].ToString();
                if (MaLop.Contains(code))
                {
                    TenMon = row.ItemArray[3].ToString();
                    SoTC = row.ItemArray[7].ToString();
                    Thu = row.ItemArray[10].ToString();
                    Tiet = row.ItemArray[11].ToString();

                    DataGridViewMaLop.Rows.Add(new string[] { MaLop, TenMon, SoTC, Thu, Tiet });
                }
            }
        }

        #endregion Search

        #region Delete id class

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowCount = DataGridViewSelected.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridViewSelected.SelectedRows[0].Index;
            if (DataGridViewSelected.Rows[idx].Cells[1].Value == null)
                return;

            string MaLop = DataGridViewSelected.Rows[idx].Cells[0].Value.ToString();
            DataRow rowSelected = null;

            foreach (DataRow row in FormGoiY.DanhSachMaLopDaChon)
            {
                if (MaLop == row.ItemArray[2].ToString())
                {
                    rowSelected = row;
                    break;
                }
            }

            FormGoiY.DanhSachMaLopDaChon.Remove(rowSelected);
            DataGridViewSelected.Rows.Remove(DataGridViewSelected.Rows[idx]);

            MessageBox.Show("Xóa mã lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Delete id class
    }
}
