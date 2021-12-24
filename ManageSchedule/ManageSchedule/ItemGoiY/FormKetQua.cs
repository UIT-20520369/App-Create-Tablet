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
    public partial class FormKetQua : Form
    {
        #region Declare

        private string HeDaoTao;
        private int CountResult = 0;
        private string[,] TKB;
        private string curUser = string.Empty;
        private DataSet ds;
        private List<string> DanhSachMonChinhTri;
        private List<DataRow> DanhSachMonHocLyThuyet;
        private List<DataRow> DanhSachMonHocThucHanh;
        private List<string[,]> listTKB;
        private bool isSearch = true;

        #endregion Declare

        #region Constructor

        public FormKetQua(string hdt, string x)
        {
            InitializeComponent();

            HeDaoTao = hdt;
            curUser = x;
            btnShowResult.Enabled = false;

            TKB = new string[12, 10];

            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(btnStart, "Bắt đầu tìm kiếm kết quả phù hợp");
            tooltip.SetToolTip(btnShowResult, "Xem các thời khóa biểu phù hợp");

            DanhSachMonChinhTri = new List<string>() { "SS003", "SS006", "SS007", "SS008", "SS009", "SS010" };
            DanhSachMonHocLyThuyet = new List<DataRow>();
            DanhSachMonHocThucHanh = new List<DataRow>();
            listTKB = new List<string[,]>();
        }

        #endregion Constructor

        #region Form Load

        private void FormKetQua_Load(object sender, EventArgs e)
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
                    }
                    else
                        DanhSachLopHocBiXoa.Add(row);
                }

                foreach (DataRow row in DanhSachLopHocBiXoa)
                    DanhSachMonHocLyThuyet.Remove(row);
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
            int LocationY = 0;
            List<DataRow> tempRow = new List<DataRow>();
            foreach (DataRow rowMM in FormGoiY.DanhSachMaMonDaChon)
                foreach (DataRow rowML in FormGoiY.DanhSachMaLopDaChon)
                {
                    if (rowMM.ItemArray[1].ToString() == rowML.ItemArray[1].ToString())
                    {
                        Label label = new Label();
                        label.AutoSize = true;
                        label.Location = new Point(0, LocationY);
                        label.Text = "Đã xóa mã môn " + rowMM.ItemArray[1].ToString() + " vì có lớp " + rowML.ItemArray[2].ToString() + " trong danh sách";
                        panel1.Controls.Add(label);
                        tempRow.Add(rowMM);
                        LocationY += 18;
                        break;
                    }
                }

            foreach (DataRow row in tempRow)
                FormGoiY.DanhSachMaMonDaChon.Remove(row);

            foreach (DataRow row in FormGoiY.DanhSachMaMonDaChon)
                DataGridViewMaMon.Rows.Add(new string[] { row.ItemArray[1].ToString(), row.ItemArray[3].ToString() });

            foreach (DataRow row in FormGoiY.DanhSachMaLopDaChon)
                DataGridViewMaLop.Rows.Add(new string[] { row.ItemArray[2].ToString(), row.ItemArray[3].ToString() });
        }

        #endregion Set up

        #region Delete

        private void btnDeleteIdSubject_Click(object sender, EventArgs e)
        {
            if (FormGoiY.DanhSachMaMonDaChon.Count == 0)
            {
                MessageBox.Show("Danh sách không có mã môn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDeleteIdSubject.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
                return;
            }

            int selectedRowCount = DataGridViewMaMon.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridViewMaMon.SelectedRows[0].Index;
            if (DataGridViewMaMon.Rows[idx].Cells[1].Value == null)
                return;

            string MaMon = DataGridViewMaMon.Rows[idx].Cells[0].Value.ToString();
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
            DataGridViewMaMon.Rows.Remove(DataGridViewMaMon.Rows[idx]);

            MessageBox.Show("Xóa mã môn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isSearch = true;
            btnDeleteIdSubject.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            LabelResult.Text = "";
        }

        private void btnDeleteIdClass_Click(object sender, EventArgs e)
        {
            if (FormGoiY.DanhSachMaLopDaChon.Count == 0)
            {
                MessageBox.Show("Danh sách không có mã lớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDeleteIdClass.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
                return;
            }

            int selectedRowCount = DataGridViewMaLop.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount <= 0)
                return;

            int idx = DataGridViewMaLop.SelectedRows[0].Index;
            if (DataGridViewMaLop.Rows[idx].Cells[1].Value == null)
                return;

            string MaLop = DataGridViewMaLop.Rows[idx].Cells[0].Value.ToString();
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
            DataGridViewMaLop.Rows.Remove(DataGridViewMaLop.Rows[idx]);

            MessageBox.Show("Xóa mã lớp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isSearch = true;
            btnDeleteIdClass.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
            LabelResult.Text = "";
        }

        #endregion Delete

        #region Search

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isSearch)
            {
                MessageBox.Show("Đã xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnStart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
                return;
            }

            if (FormGoiY.DanhSachMaLopDaChon.Count == 0 && FormGoiY.DanhSachMaMonDaChon.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn mã lớp hoặc mã môn để bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnStart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
                return;
            }

            btnShowResult.Enabled = false;
            int pos = 0;
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 10; j++)
                    TKB[i, j] = string.Empty;

            if (CheckIdClass() == false)
            {
                LabelResult.Text = "Có 0 kết quả phù hợp với yêu cầu của bạn";
                MessageBox.Show("Đã xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[,] tempTKB = new string[12, 10];

            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 10; j++)
                    tempTKB[i, j] = TKB[i, j];

            CheckIdSubject(pos, tempTKB);

            if (CountResult > 0)
            {
                if (FormGoiY.isConstraint)
                    CheckConstraint();

                if (CountResult == 0)
                    btnShowResult.Enabled = false;
                else
                    btnShowResult.Enabled = true;
            }

            LabelResult.Text = "Có " + CountResult.ToString() + " kết quả phù hợp với yêu cầu của bạn";
            MessageBox.Show("Đã xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            isSearch = false;
            
            btnStart.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }

        private void CheckConstraint()
        {
            List<string[,]> listTKBWillbeDelete = new List<string[,]>();

            foreach (string[,] TKB in listTKB)
            {
                bool ThoaDK = true;

                #region Morning

                if (FormGoiY.DanhSachRangBuoc[1, 2])
                    for (int i = 1; i <= 5; i++)
                        if (TKB[i, 2] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[1, 3])
                    for (int i = 1; i <= 5; i++)
                        if (TKB[i, 3] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[1, 4])
                    for (int i = 1; i <= 5; i++)
                        if (TKB[i, 4] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[1, 5])
                    for (int i = 1; i <= 5; i++)
                        if (TKB[i, 5] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[1, 6])
                    for (int i = 1; i <= 5; i++)
                        if (TKB[i, 6] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[1, 7])
                    for (int i = 1; i <= 5; i++)
                        if (TKB[i, 7] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;

                #endregion Morning

                #region Afternoon

                if (FormGoiY.DanhSachRangBuoc[2, 2])
                    for (int i = 6; i <= 10; i++)
                        if (TKB[i, 2] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[2, 3])
                    for (int i = 6; i <= 10; i++)
                        if (TKB[i, 3] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[2, 4])
                    for (int i = 6; i <= 10; i++)
                        if (TKB[i, 4] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[2, 5])
                    for (int i = 6; i <= 10; i++)
                        if (TKB[i, 5] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[2, 6])
                    for (int i = 6; i <= 10; i++)
                        if (TKB[i, 6] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;
                if (FormGoiY.DanhSachRangBuoc[2, 7])
                    for (int i = 6; i <= 10; i++)
                        if (TKB[i, 7] != string.Empty)
                        {
                            listTKBWillbeDelete.Add(TKB);
                            ThoaDK = false;
                            break;
                        }
                if (ThoaDK == false)
                    continue;

                #endregion Afternoon
            }

            foreach (string[,] TKB in listTKBWillbeDelete)
            {
                listTKB.Remove(TKB);
                CountResult--;
            }
        }

        private void CheckIdSubject(int pos, string[,] tempTKB)
        {
            if (pos == FormGoiY.DanhSachMaMonDaChon.Count)
            {
                CountResult++;
                string[,] strTKB = new string[12, 10];
                for (int i = 0; i < 12; i++)
                    for (int j = 0; j < 10; j++)
                        strTKB[i, j] = tempTKB[i, j];
                listTKB.Add(strTKB);
                return;
            }

            #region Declare

            DataRow row = FormGoiY.DanhSachMaMonDaChon[pos];
            string MaMon = row.ItemArray[1].ToString();
            string MaLop = string.Empty;
            string malopLT = string.Empty;
            string malopTH = string.Empty;
            string Thu = string.Empty;
            string Tiet = string.Empty;
            List<DataRow> rows = new List<DataRow>();
            List<DataRow> listRowsIgnore = new List<DataRow>();
            bool isIgnore = false;

            #endregion Declare

            #region Get list id class

            List<DataRow> listIDClass = new List<DataRow>();

            foreach (DataRow LT in DanhSachMonHocLyThuyet)
            {
                if (MaMon == LT.ItemArray[1].ToString())
                    listIDClass.Add(LT);
            }

            #endregion Get list id class

            pos++;

            foreach (DataRow IdClass in listIDClass)
            {
                MaLop = IdClass.ItemArray[2].ToString();
                isIgnore = false;

                foreach (DataRow check in listRowsIgnore)
                    if (MaLop == check.ItemArray[2].ToString())
                    {
                        isIgnore = true;
                        break;
                    }

                if (isIgnore)
                    continue;

                rows.Clear();

                #region LT

                foreach (DataRow LT in listIDClass)
                {
                    malopLT = LT.ItemArray[2].ToString();
                    if (malopLT == MaLop)
                    {
                        Thu = LT.ItemArray[10].ToString();
                        Tiet = LT.ItemArray[11].ToString();

                        if (CheckTimeInTKB(Thu, Tiet, tempTKB))
                            rows.Add(LT);
                        else
                        {
                            isIgnore = true;
                            listRowsIgnore.Add(LT);
                            break;
                        }
                    }
                }

                #endregion LT

                if (isIgnore)
                    continue;

                #region TH 

                isIgnore = false;
                string tempMalop = string.Empty;
                malopTH = string.Empty;
                foreach (DataRow TH in DanhSachMonHocThucHanh)
                {
                    tempMalop = TH.ItemArray[2].ToString();

                    if (tempMalop.Contains(MaLop) && string.IsNullOrEmpty(malopTH))
                        malopTH = tempMalop;

                    if (tempMalop == malopTH)
                    {
                        Thu = TH.ItemArray[10].ToString();
                        Tiet = TH.ItemArray[11].ToString();

                        if (CheckTimeInTKB(Thu, Tiet, tempTKB))
                            rows.Add(TH);
                        else
                        {
                            isIgnore = true;
                            listRowsIgnore.Add(IdClass);
                            break;
                        }
                    }
                }

                #endregion TH

                if (isIgnore)
                    continue;

                foreach (DataRow ClassMeetTheConditions in rows)
                    AddTimeInTKB(ClassMeetTheConditions.ItemArray[10].ToString(), ClassMeetTheConditions.ItemArray[11].ToString(), ClassMeetTheConditions.ItemArray[2].ToString(), tempTKB);

                CheckIdSubject(pos, tempTKB);

                foreach (DataRow ClassMeetTheConditions in rows)
                    DeleteTimeInTKB(ClassMeetTheConditions.ItemArray[10].ToString(), ClassMeetTheConditions.ItemArray[11].ToString(), tempTKB);
                listRowsIgnore.Add(rows[0]);
            }
        }

        #region Check id class

        private bool CheckIdClass()
        {
            string Thu = string.Empty;
            string Tiet = string.Empty;
            string MaLop = string.Empty;
            string MaLopLT = string.Empty;
            string MaLopTH = string.Empty;

            foreach (DataRow row in FormGoiY.DanhSachMaLopDaChon)
            {
                MaLop = row.ItemArray[2].ToString();
                foreach (DataRow LT in DanhSachMonHocLyThuyet)
                {
                    MaLopLT = LT.ItemArray[2].ToString();
                    if (MaLop == MaLopLT)
                    {
                        Thu = LT.ItemArray[10].ToString();
                        Tiet = LT.ItemArray[11].ToString();

                        if (CheckTimeInTKB(Thu, Tiet, TKB))
                            AddTimeInTKB(Thu, Tiet, MaLop, TKB);
                        else
                        {
                            return (false);
                        }
                    }
                }

                MaLopTH = string.Empty;
                string malopth;
                foreach (DataRow TH in DanhSachMonHocThucHanh)
                {
                    malopth = TH.ItemArray[2].ToString();
                    if (malopth.Contains(MaLop) && string.IsNullOrEmpty(MaLopTH))
                        MaLopTH = malopth;

                    if (malopth == MaLopTH)
                    {
                        Thu = TH.ItemArray[10].ToString();
                        Tiet = TH.ItemArray[11].ToString();

                        if (CheckTimeInTKB(Thu, Tiet, TKB))
                            AddTimeInTKB(Thu, Tiet, MaLopTH, TKB);
                        else
                        {
                            return (false);
                        }
                    }
                }
            }

            return (true);
        }

        #endregion Check id class

        #region Check time in TKB

        private bool CheckTimeInTKB(string Thu, string Tiet, string[,] tempTKB)
        {
            int thu = int.Parse(Thu);
            for (int i = 0; i < Tiet.Length; i++)
            {
                int k = int.Parse(Tiet[i].ToString());
                k = k == 0 ? 10 : k;

                if (tempTKB[k, thu] != string.Empty)
                {
                    return (false);
                }     
            }

            return (true);
        }

        #endregion Check time in TKB

        #region Add time in TKB

        private void AddTimeInTKB(string Thu, string Tiet, string MaLop, string[,] tempTKB)
        {
            int thu = int.Parse(Thu.ToString());
            for (int i = 0; i < Tiet.Length; i++)
            {
                int k = int.Parse(Tiet[i].ToString());
                k = k == 0 ? 10 : k;

                tempTKB[k, thu] = MaLop;
            }
        }

        #endregion Add time in TKB

        #region Delete time in TKB

        private void DeleteTimeInTKB(string Thu, string Tiet, string[,] tempTKB)
        {
            int thu = int.Parse(Thu.ToString());
            for (int i = 0; i < Tiet.Length; i++)
            {
                int k = int.Parse(Tiet[i].ToString());
                k = k == 0 ? 10 : k;

                tempTKB[k, thu] = string.Empty;
            }
        }

        #endregion Delete time in TKB

        #endregion Search

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            ItemGoiY.FormXemKetQua formShow = new ItemGoiY.FormXemKetQua(listTKB, DanhSachMonHocLyThuyet, DanhSachMonHocThucHanh, curUser);
            formShow.ShowDialog();
            btnShowResult.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton2.ButtonStates.Idle;
        }
    }
}
