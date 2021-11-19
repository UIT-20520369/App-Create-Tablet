using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelDataReader;
using System.IO;

namespace DemoUI
{
    public partial class FormTaoTKB : Form
    {
        DataSet ds;
        DataTable noneDistinctTable;

        // Lưu mã lớp, mã môn của tất cả các môn trong file excel
        List<string> maMonHocLT;
        List<string> maMonHocTH;
        List<string> maLopHocLT;
        List<string> maLopHocTH;

        List<string> danhSachMaMonDaChon;
        List<string> danhSachMonHocDaNhap;
        bool daMoFile;
        int tongTinChi;

        public FormTaoTKB()
        {
            InitializeComponent();

            danhSachMaMonDaChon = new List<string>();
            maMonHocLT = new List<string>();
            maMonHocTH = new List<string>();
            maLopHocLT = new List<string>();
            maLopHocTH = new List<string>();
            danhSachMonHocDaNhap = new List<string>();
            tongTinChi = 0;
            daMoFile = false;

            cbChuongTrinhDaoTao.Items.Add("Chính quy");
            cbChuongTrinhDaoTao.Items.Add("Chất lượng cao");
            cbChuongTrinhDaoTao.SelectedIndex = 0;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Workbook|*xlsx|Excel Workbook 97-2003|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                danhSachMaMonDaChon.Clear();
                danhSachMonHocDaNhap.Clear();
                maLopHocLT.Clear();
                maLopHocTH.Clear();
                maMonHocLT.Clear();
                maMonHocTH.Clear();
                cbChuongTrinhDaoTao.SelectedIndex = 0;
                labelTinChi.Text = "0";
                tongTinChi = 0;
                lvDisplay.Items.Clear();

                try
                {
                    using (FileStream stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 2)
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }

                        ds = reader.AsDataSet();

                        labelFilePath.Text = ofd.FileName;

                        DataTable dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            maMonHocLT.Add(dt.Rows[i][1].ToString());
                            maLopHocLT.Add(dt.Rows[i][2].ToString());
                        }
                        dt = ds.Tables[1];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            maMonHocTH.Add(dt.Rows[i][1].ToString());
                            maLopHocTH.Add(dt.Rows[i][2].ToString());
                        }

                        noneDistinctTable = ds.Tables[0].DefaultView.ToTable(true, "Column1", "Column2");

                        daMoFile = true;

                        reader.Close();
                    }

                } 
                catch (Exception ex)
                {
                    MessageBox.Show("File đang được sử dụng ở một tiến trình khác", "Thông báo");
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check đã mở file chưa
            if (!daMoFile)
            {
                MessageBox.Show("Vui lòng mở file", "Thông báo");
                tbInput.Text = "";
                tbInput.Focus();
                return;
            }

            string s = tbInput.Text.Trim();
            s = s.ToUpper();

            // Check đã nhập mã chưa
            if (s == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã lớp hoặc mã môn", "Thông báo");
                tbInput.Text = "";
                tbInput.Focus();
                return;
            }

            int VitriLT = 0;
            int VitriTH = 0;
            int maLopLT = maLopHocLT.IndexOf(s);
            int maMonLT = maMonHocLT.IndexOf(s);
            int maLopTH = maLopHocTH.IndexOf(s);
            int maMonTH = maMonHocTH.IndexOf(s);

            if (maLopLT == -1 && maMonLT == -1 && maLopTH == -1 && maMonTH == -1)
            {
                MessageBox.Show("Không tìm thấy " + s, "Thông báo");
                tbInput.Text = "";
                tbInput.Focus();
                return;
            }

            if (maLopLT != -1)
                VitriLT = maLopLT;
            else
                if (maMonLT != -1)
                    VitriLT = maMonLT;

            if (maLopTH != -1)
                VitriTH = maLopTH;
            else
                if (maMonTH != -1)
                    VitriTH = maMonTH;

            for (int i = 0; i < danhSachMaMonDaChon.Count; i++)
            {
                if (s.Contains(danhSachMaMonDaChon[i]))
                {
                    MessageBox.Show("Môn học đã có trong danh sách của bạn", "Thông báo");
                    tbInput.Text = "";
                    tbInput.Focus();
                    return;
                }
            }

            danhSachMonHocDaNhap.Add(s);

            DataTable dt;
            if (VitriLT != 0)
            {
                if (VitriLT - 10 >= 10)
                    VitriLT -= 10;
                else
                    VitriLT = 0;

                dt = ds.Tables[0];
                for (int i = VitriLT; i < dt.Rows.Count; i++)
                {
                    if (s == dt.Rows[i][1].ToString() || s == dt.Rows[i][2].ToString())
                    {
                        VitriTH = maMonHocTH.IndexOf(dt.Rows[i][1].ToString());
                        if (VitriTH == -1)
                        {
                            ListViewItem item = new ListViewItem(new string[] { s, dt.Rows[i][3].ToString(), dt.Rows[i][7].ToString() });
                            tongTinChi += int.Parse(dt.Rows[i][7].ToString());
                            lvDisplay.Items.Add(item);
                        } 
                        else
                        {
                            if (VitriTH - 10 >= 0)
                                VitriTH = VitriTH - 10;
                            else
                                VitriTH = 0;

                            for (int j = VitriTH; j < ds.Tables[1].Rows.Count; j++)
                                if (dt.Rows[i][1] == ds.Tables[1].Rows[j][1])
                                {
                                    ListViewItem item = new ListViewItem(new string[] { s, dt.Rows[i][3].ToString(), dt.Rows[i][7].ToString() + " + " + ds.Tables[1].Rows[j][7].ToString() });
                                    tongTinChi += int.Parse(dt.Rows[i][7].ToString()) + int.Parse(ds.Tables[1].Rows[j][7].ToString());
                                    lvDisplay.Items.Add(item);
                                    break;
                                }
                        }

                        danhSachMaMonDaChon.Add(dt.Rows[i][1].ToString());
                        labelTinChi.Text = tongTinChi.ToString();
                        tbInput.Text = "";
                        tbInput.Focus();
                        break;
                    }
                }
            } 
            else
            {
                if (VitriTH - 10 >= 10)
                    VitriTH -= 10;
                else
                    VitriTH = 0;

                dt = ds.Tables[1];
                for (int i = VitriTH; i < dt.Rows.Count; i++)
                {
                    if (s == dt.Rows[i][1].ToString() || s == dt.Rows[i][2].ToString())
                    {
                        VitriLT = maMonHocLT.IndexOf(dt.Rows[i][1].ToString());
                        if (VitriLT == -1)
                        {
                            ListViewItem item = new ListViewItem(new string[] { s, dt.Rows[i][3].ToString(), dt.Rows[i][7].ToString() });
                            tongTinChi += int.Parse(dt.Rows[i][7].ToString());
                            lvDisplay.Items.Add(item);
                        }
                        else
                        {
                            if (VitriLT - 10 >= 0)
                                VitriLT = VitriTH - 10;
                            else
                                VitriLT = 0;

                            for (int j = VitriLT; j < ds.Tables[0].Rows.Count; j++)
                                if (dt.Rows[i][1] == ds.Tables[0].Rows[j][1])
                                {
                                    ListViewItem item = new ListViewItem(new string[] { s, dt.Rows[i][3].ToString(), ds.Tables[0].Rows[j][7].ToString() + " + " + dt.Rows[i][7].ToString() });
                                    tongTinChi += int.Parse(ds.Tables[0].Rows[j][7].ToString()) + int.Parse(dt.Rows[i][7].ToString());
                                    lvDisplay.Items.Add(item);
                                    break;
                                }
                        }

                        danhSachMaMonDaChon.Add(dt.Rows[i][1].ToString());
                        labelTinChi.Text = tongTinChi.ToString();
                        tbInput.Text = "";
                        tbInput.Focus();
                        break;
                    }
                }
            }
        }

        private void cbChuongTrinhDaoTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            //danhSachMonHocDaNhap.Clear();
            //danhSachMaMonDaChon.Clear();
            //lvDisplay.Items.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!daMoFile)
            {
                MessageBox.Show("Vui lòng mở file", "Thông báo");
                tbInput.Text = "";
                tbInput.Focus();
                return;
            }

            if (lvDisplay.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDisplay.SelectedItems[0];

                string[] arrNum = item.SubItems[2].Text.Split('+');
                if (arrNum.Length == 2)
                    tongTinChi -= (int.Parse(arrNum[0]) + int.Parse(arrNum[1]));
                else
                    tongTinChi -= int.Parse(arrNum[0]);
                labelTinChi.Text = tongTinChi.ToString();

                string[] arr = item.SubItems[0].Text.Split('.');
                danhSachMaMonDaChon.Remove(arr[0]);

                danhSachMonHocDaNhap.Remove(item.SubItems[0].Text);
                lvDisplay.Items.Remove(lvDisplay.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa", "Thông báo");
            }
        }

        private void btnTaoTKB_Click(object sender, EventArgs e)
        {
            if (!daMoFile)
            {
                MessageBox.Show("Vui lòng mở file", "Thông báo");
                tbInput.Text = "";
                tbInput.Focus();
                return;
            }

            List<List<MonHoc>> listTKB = new List<List<MonHoc>>();
            List<MonHoc> TKB = new List<MonHoc>();
            bool[,] checkTKB = new bool[11, 8];

            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 8; j++)
                    checkTKB[i, j] = false;

            TaoTKB(0, TKB, listTKB, checkTKB);
            labelKetQua.Text = listTKB.Count.ToString();

            MessageBox.Show(listTKB[3].Count.ToString());
            for (int i = 0; i < listTKB.Count; i++)
                for (int j = 0; j < listTKB[i].Count; j++)
                    MessageBox.Show((i + 1).ToString() + " " + listTKB[i][j].maLopHoc + " " + listTKB[i][j].thu + " " + listTKB[i][j].tiet);
        }

        private void TaoTKB(int pos, List<MonHoc> TKB, List<List<MonHoc>> listTKB, bool[,] checkTKB)
        {
            if (pos == danhSachMonHocDaNhap.Count)
            {
                List<MonHoc> tempList = new List<MonHoc>(TKB);
                listTKB.Add(tempList);
                tempList = null;
                return;
            }

            DataRow[] rows = new DataRow[1500];
            if (danhSachMonHocDaNhap[pos] == danhSachMaMonDaChon[pos])
                rows = noneDistinctTable.Select("Column1 = '" + danhSachMonHocDaNhap[pos] + "'");
            else
                rows = noneDistinctTable.Select("Column2 = '" + danhSachMonHocDaNhap[pos] + "'");

            for (int i = 0; i < rows.Length; i++)
            {
                string s = rows[i].ItemArray[1].ToString();
                DataRow[] oneSub = new DataRow[6];
                if (cbChuongTrinhDaoTao.Text == "Chính quy")
                    oneSub = ds.Tables[0].Select("Column2 = '" + s + "' and Column17 = 'CQUI'");
                else
                    oneSub = ds.Tables[0].Select("Column2 = '" + s + "' and Column17 = 'CLC'");

                bool coLich;

                if (oneSub.Length > 0)
                    coLich = true;
                else
                    coLich = false;

                for (int j = 0; j < oneSub.Length; j++)
                {
                    if (oneSub[j].ItemArray[10].ToString() == "*" || oneSub[j].ItemArray[11].ToString() == "*")
                    {
                        coLich = false;
                        break;
                    }

                    coLich = ToggleCheckTKB(0, oneSub[j].ItemArray[10].ToString(), oneSub[j].ItemArray[11].ToString(), checkTKB);

                    if (coLich == false)
                        break;
                }

                // Kiểm tra lớp thực hành .1
                if (coLich)
                {
                    // Thêm lớp lý thuyết
                    List<MonHoc> tempList = new List<MonHoc>();
                    for (int j = 0; j < oneSub.Length; j++)
                    {
                        ToggleCheckTKB(1, oneSub[j].ItemArray[10].ToString(), oneSub[j].ItemArray[11].ToString(), checkTKB);

                        MonHoc mh = new MonHoc(oneSub[j].ItemArray[1].ToString(), oneSub[j].ItemArray[2].ToString(), oneSub[j].ItemArray[3].ToString(), int.Parse(oneSub[j].ItemArray[7].ToString()), int.Parse(oneSub[j].ItemArray[10].ToString()), oneSub[j].ItemArray[11].ToString(), oneSub[j].ItemArray[17].ToString());
                        tempList.Add(mh);
                        TKB.Add(mh);
                        mh = null;
                    }
                    // ******************

                    // lớp thực hành .1
                    bool lichThucHanh1 = true;  
                    DataRow[] thucHanh1 = new DataRow[5];
                    if (cbChuongTrinhDaoTao.Text == "Chính quy")
                        thucHanh1 = ds.Tables[1].Select("Column2 = '" + s + ".1' and Column17 = 'CQUI'");
                    else
                        thucHanh1 = ds.Tables[1].Select("Column2 = '" + s + ".1' and Column17 = 'CLC'");
                    for (int j = 0; j < thucHanh1.Length; j++)
                    {
                        coLich = false;
                        if (thucHanh1[j].ItemArray[10].ToString() == "*" || thucHanh1[j].ItemArray[11].ToString() == "*")
                        {
                            lichThucHanh1 = false;
                            break;
                        }

                        lichThucHanh1 = ToggleCheckTKB(0, thucHanh1[j].ItemArray[10].ToString(), thucHanh1[j].ItemArray[11].ToString(), checkTKB);

                        if (lichThucHanh1 == false)
                            break;
                    }

                    if (lichThucHanh1 == true && coLich == false)
                    {
                        List<MonHoc> tempListTH1 = new List<MonHoc>();
                        for (int j = 0; j < thucHanh1.Length; j++)
                        {
                            ToggleCheckTKB(1, thucHanh1[j].ItemArray[10].ToString(), thucHanh1[j].ItemArray[11].ToString(), checkTKB);

                            MonHoc mh = new MonHoc(thucHanh1[j].ItemArray[1].ToString(), thucHanh1[j].ItemArray[2].ToString(), thucHanh1[j].ItemArray[3].ToString(), int.Parse(thucHanh1[j].ItemArray[7].ToString()), int.Parse(thucHanh1[j].ItemArray[10].ToString()), thucHanh1[j].ItemArray[11].ToString(), thucHanh1[j].ItemArray[17].ToString());
                            tempListTH1.Add(mh);
                            TKB.Add(mh);
                            mh = null;
                        }

                        TaoTKB(pos + 1, TKB, listTKB, checkTKB);

                        for (int j = 0; j < thucHanh1.Length; j++)
                            ToggleCheckTKB(2, thucHanh1[j].ItemArray[10].ToString(), thucHanh1[j].ItemArray[11].ToString(), checkTKB);

                        for (int j = 0; j < tempListTH1.Count; j++)
                            TKB.Remove(tempListTH1[j]);
                        tempListTH1 = null;
                    }

                    // Lớp thực hành .2
                    coLich = true;
                    bool lichThucHanh2 = true;
                    DataRow[] thucHanh2 = new DataRow[5];
                    if (cbChuongTrinhDaoTao.Text == "Chính quy")
                        thucHanh2 = ds.Tables[1].Select("Column2 = '" + s + ".2' and Column17 = 'CQUI'");
                    else
                        thucHanh2 = ds.Tables[1].Select("Column2 = '" + s + ".2' and Column17 = 'CLC'");
                    for (int j = 0; j < thucHanh2.Length; j++)
                    {
                        coLich = false;
                        if (thucHanh2[j].ItemArray[10].ToString() == "*" || thucHanh2[j].ItemArray[11].ToString() == "*")
                        {
                            lichThucHanh2 = false;
                            break;
                        }

                        lichThucHanh2 = ToggleCheckTKB(0, thucHanh2[j].ItemArray[10].ToString(), thucHanh2[j].ItemArray[11].ToString(), checkTKB);

                        if (lichThucHanh2 == false)
                            break;
                    }

                    if (lichThucHanh2 == true && coLich == false)
                    {
                        List<MonHoc> tempListTH2 = new List<MonHoc>();
                        for (int j = 0; j < thucHanh2.Length; j++)
                        {
                            ToggleCheckTKB(1, thucHanh2[j].ItemArray[10].ToString(), thucHanh2[j].ItemArray[11].ToString(), checkTKB);

                            MonHoc mh = new MonHoc(thucHanh2[j].ItemArray[1].ToString(), thucHanh2[j].ItemArray[2].ToString(), thucHanh2[j].ItemArray[3].ToString(), int.Parse(thucHanh2[j].ItemArray[7].ToString()), int.Parse(thucHanh2[j].ItemArray[10].ToString()), thucHanh2[j].ItemArray[11].ToString(), thucHanh2[j].ItemArray[17].ToString());
                            tempListTH2.Add(mh);
                            TKB.Add(mh);
                            mh = null;
                        }

                        TaoTKB(pos + 1, TKB, listTKB, checkTKB);

                        for (int j = 0; j < thucHanh2.Length; j++)
                            ToggleCheckTKB(2, thucHanh2[j].ItemArray[10].ToString(), thucHanh2[j].ItemArray[11].ToString(), checkTKB);

                        for (int j = 0; j < tempListTH2.Count; j++)
                            TKB.Remove(tempListTH2[j]);
                        tempListTH2 = null;
                    }

                    // Xóa lớp lí thuyết
                    for (int j = 0; j < oneSub.Length; j++)
                        ToggleCheckTKB(2, oneSub[j].ItemArray[10].ToString(), oneSub[j].ItemArray[11].ToString(), checkTKB);

                    for (int j = 0; j < tempList.Count; j++)
                        TKB.Remove(tempList[j]);
                    tempList = null;
                    // ******************
                }

                if (coLich)
                {
                    List<MonHoc> tempList = new List<MonHoc>();
                    for (int j = 0; j < oneSub.Length; j++)
                    {
                        ToggleCheckTKB(1, oneSub[j].ItemArray[10].ToString(), oneSub[j].ItemArray[11].ToString(), checkTKB);

                        MonHoc mh = new MonHoc(oneSub[j].ItemArray[1].ToString(), oneSub[j].ItemArray[2].ToString(), oneSub[j].ItemArray[3].ToString(), int.Parse(oneSub[j].ItemArray[7].ToString()), int.Parse(oneSub[j].ItemArray[10].ToString()), oneSub[j].ItemArray[11].ToString(), oneSub[j].ItemArray[17].ToString());
                        tempList.Add(mh);
                        TKB.Add(mh);
                        mh = null;
                    }

                    TaoTKB(pos + 1, TKB, listTKB, checkTKB);

                    for (int j = 0; j < oneSub.Length; j++)
                        ToggleCheckTKB(2, oneSub[j].ItemArray[10].ToString(), oneSub[j].ItemArray[11].ToString(), checkTKB);

                    for (int j = 0; j < tempList.Count; j++)
                        TKB.Remove(tempList[j]);
                    tempList = null;
                }
            }
        }

        //type = 0 kiểm tra có trùng lịch không
        //type = 1 đánh dấu đã có lịch
        //type = 2 đánh dấu chưa có lịch
        public bool ToggleCheckTKB(int type, string sThu, string tiets, bool[,] checkTKB)
        {
            int thu = int.Parse(sThu);
            if (type == 0)
            {
                for (int k = 0; k < tiets.Length; k++)
                {
                    int tiet = int.Parse(tiets[k].ToString());
                    if (tiet == 0)
                        tiet = 10;

                    if (checkTKB[tiet, thu] == true)
                        return false;
                }

                return true;
            }

            if (type == 1)
            {
                for (int k = 0; k < tiets.Length; k++)
                {
                    int tiet = int.Parse(tiets[k].ToString());
                    if (tiet == 0)
                        tiet = 10;

                    checkTKB[tiet, thu] = true;
                }
                return true;
            }

            for (int k = 0; k < tiets.Length; k++)
            {
                int tiet = int.Parse(tiets[k].ToString());
                if (tiet == 0)
                    tiet = 10;

                checkTKB[tiet, thu] = false;
            }
            return true;
        }
    }
}
