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
    public partial class FormChonMaMon : Form
    {
        #region Declare

        private DataSet ds;
        private string HeDaoTao;
        private List<DataRow> listRow = new List<DataRow>();
        ToolTip tooltip = new ToolTip();

        #endregion Declare

        public FormChonMaMon(string hdt)
        {
            InitializeComponent();
            HeDaoTao = hdt;
            tooltip.SetToolTip(btnSelect, "Chọn mã lớp");
            tooltip.SetToolTip(btnDelete, "Xóa mã lớp khỏi danh sách");
        }

        #region Form Load

        private void FormChonMaMon_Load(object sender, EventArgs e)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = ConfigurationManager.AppSettings["Path"];
            string ExcelFile = string.Format(@"{0}\Data{1}", Path.GetFullPath(Path.Combine(RunningPath, @"..\")), FileName);
            try
            {
                using (var stream = File.Open(ExcelFile, FileMode.Open, FileAccess.Read))
                {
                    IExcelDataReader reader;

                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                    ds = reader.AsDataSet();

                    reader.Close();
                }

                string MaMon = string.Empty;
                string TenMon = string.Empty;
                string SoTC = string.Empty;
                string KhoaQL = string.Empty;

                DataTable distinctValues = ds.Tables[0].DefaultView.ToTable(true, "Column1");
                DataTable dt = ds.Tables[0];

                foreach (DataRow row in distinctValues.Rows)
                {
                    string tempString = row.ItemArray[0].ToString();
                    if (string.IsNullOrEmpty(tempString) || tempString == "MÃ MH")
                        continue;

                    string searchExpression = "Column1 = '" + tempString + "'";
                    DataRow[] foundRows = dt.Select(searchExpression);

                    foreach (DataRow r in foundRows)
                    {
                        if (r.ItemArray[17].ToString() == HeDaoTao)
                        {
                            MaMon = r.ItemArray[1].ToString();
                            TenMon = r.ItemArray[3].ToString();
                            SoTC = r.ItemArray[7].ToString();
                            KhoaQL = r.ItemArray[18].ToString();

                            listRow.Add(r);
                            break;
                        }
                    } 
                }

                dt = ds.Tables[1];
                int sotc = 0;
                foreach (DataRow row in listRow)
                {
                    string malopLT = row.ItemArray[2].ToString();
                    sotc = int.Parse(row.ItemArray[7].ToString());
                    foreach (DataRow rowTH in dt.Rows)
                    {
                        string malopTH = rowTH.ItemArray[2].ToString();
                        if (malopTH.Contains(malopLT))
                        {
                            sotc += int.Parse(rowTH.ItemArray[7].ToString());
                            break;
                        }
                    }
                    row[7] = sotc.ToString();

                    MaMon = row.ItemArray[1].ToString();
                    TenMon = row.ItemArray[3].ToString();
                    SoTC = row.ItemArray[7].ToString();
                    KhoaQL = row.ItemArray[18].ToString();

                    DataGridViewMaMon.Rows.Add(new string[] { MaMon, TenMon, SoTC, KhoaQL });
                }
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
            foreach (DataRow row in FormGoiY.DanhSachMaMonDaChon)
            {
                DataGridViewSelected.Rows.Add(new string[] { row.ItemArray[1].ToString(), row.ItemArray[3].ToString() });
            }
        }

        #endregion Set up

        #region Search

        private void TextBoxSearch_TextChange(object sender, EventArgs e)
        {
            DataGridViewMaMon.Rows.Clear();
            string code = TextBoxSearch.Text.Trim().ToUpper();
            string MaMon = string.Empty;
            string TenMon = string.Empty;
            string SoTC = string.Empty;
            string KhoaQL = string.Empty;

            foreach (DataRow row in listRow)
            {
                MaMon = row.ItemArray[1].ToString();
                if (MaMon.Contains(code))
                {
                    TenMon = row.ItemArray[3].ToString();
                    SoTC = row.ItemArray[7].ToString();
                    KhoaQL = row.ItemArray[18].ToString();

                    DataGridViewMaMon.Rows.Add(new string[] { MaMon, TenMon, SoTC, KhoaQL });
                }
            }
        }

        #endregion Search

        #region Add id subject

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int selectedRowCount = DataGridViewMaMon.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridViewMaMon.SelectedRows[0].Index;
            if (DataGridViewMaMon.Rows[idx].Cells[1].Value == null)
                return;

            string MaMon = string.Empty;
            string DTGVMaMon = DataGridViewMaMon.Rows[idx].Cells[0].Value.ToString();
            foreach (DataRow row in listRow)
            {
                MaMon = row.ItemArray[1].ToString();
                if (MaMon == DTGVMaMon)
                {
                    bool isAdd = true;
                    foreach (DataRow rowCheck in FormGoiY.DanhSachMaMonDaChon)
                        if (MaMon == rowCheck.ItemArray[1].ToString())
                            isAdd = false;

                    if (isAdd)
                    {
                        FormGoiY.DanhSachMaMonDaChon.Add(row);
                        DataGridViewSelected.Rows.Add(new string[] { MaMon, row.ItemArray[3].ToString() });
                        MessageBox.Show("Thêm mã môn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Mã môn đã được chọn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }

            DataGridViewMaMon.Rows[idx].Selected = false;
            btnSelect.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        #endregion Add id subject

        #region Delete id subject

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (FormGoiY.DanhSachMaMonDaChon.Count == 0)
            {
                MessageBox.Show("Danh sách không có mã môn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDelete.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
                return;
            }

            int selectedRowCount = DataGridViewSelected.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridViewSelected.SelectedRows[0].Index;
            if (DataGridViewSelected.Rows[idx].Cells[1].Value == null)
                return;

            string MaMon = DataGridViewSelected.Rows[idx].Cells[0].Value.ToString();
            DataRow rowSelected = null;

            foreach (DataRow row in FormGoiY.DanhSachMaMonDaChon)
            {
                if (MaMon == row.ItemArray[1].ToString())
                {
                    rowSelected = row;
                    break;
                }
            }

            FormGoiY.DanhSachMaMonDaChon.Remove(rowSelected);
            DataGridViewSelected.Rows.Remove(DataGridViewSelected.Rows[idx]);

            MessageBox.Show("Xóa mã môn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Delete id subject
    }
}
