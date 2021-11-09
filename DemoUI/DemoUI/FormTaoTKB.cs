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

        // Lưu mã lớp, mã môn của tất cả các môn trong file excel
        List<string> maMonHocLT;
        List<string> maMonHocTH;
        List<string> maLopHocLT;
        List<string> maLopHocTH;

        List<string> danhSachMaMonDaChon;
        List<string> danhSachMonHocDaNhap;
        bool daMoFile;
        int tongTinChi;
        int tongSoKetQua;
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
            //danhSachLopTaoTKB.Clear();
            //for (int i = 0; i < danhSachMonHocDaNhap.Count; i++)
            //{
            //    bool coLichHoc = false;
            //    foreach (DataTable dt in ds.Tables)
            //    {
            //        for (int j = 0; j < dt.Rows.Count; j++)
            //        {
            //            if (danhSachMonHocDaNhap[i] == dt.Rows[j][2].ToString())
            //            {
            //                if ((cbChuongTrinhDaoTao.Text == "Chính quy" && dt.Rows[j][17].ToString() == "CQUI") || (cbChuongTrinhDaoTao.Text == "Chất lượng cao" && dt.Rows[j][17].ToString() == "CLC"))
            //                {
            //                    if (dt.Rows[j][10].ToString() != "*" && dt.Rows[j][11].ToString() != "*")
            //                    {
            //                        MonHoc monHocMoi = new MonHoc(dt.Rows[j][1].ToString(), dt.Rows[j][2].ToString(), dt.Rows[j][3].ToString(), int.Parse(dt.Rows[j][7].ToString()), int.Parse(dt.Rows[j][10].ToString()), dt.Rows[j][11].ToString(), dt.Rows[j][17].ToString());
            //                        danhSachLopTaoTKB.Add(monHocMoi);
            //                        coLichHoc = true;
            //                        break;
            //                    }
            //                }
            //                continue;
            //            }

            //            if (danhSachMonHocDaNhap[i] == dt.Rows[j][1].ToString())
            //            {

            //            }
            //        }
            //    }

            //    if (!coLichHoc)
            //    {
            //        MessageBox.Show(danhSachMonHocDaNhap[i] + " chưa có lịch hoặc sai hệ đào tạo", "Thông báo");
            //    }
            //}    

            List<List<MonHoc>> listTKB = new List<List<MonHoc>>();
            List<MonHoc> TKB = new List<MonHoc>();
            bool[,] checkTKB = new bool[11, 8];

            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 8; j++)
                    checkTKB[i, j] = false;

            TaoTKB(0, TKB, listTKB, checkTKB);
            labelKetQua.Text = listTKB.Count.ToString();
        }

        private void TaoTKB(int pos, List<MonHoc> TKB, List<List<MonHoc>> listTKB, bool[,] checkTKB)
        {
            if (pos == danhSachMonHocDaNhap.Count)
                return;

            DataTable dt = ds.Tables[0];
            DataRow[] rows = new DataRow[1500];
            if (danhSachMonHocDaNhap[pos] == danhSachMaMonDaChon[pos])
            {
                if (cbChuongTrinhDaoTao.Text == "Chính quy")
                    rows = dt.Select("Column1 = '" + danhSachMonHocDaNhap[pos] + "' and Column17 = 'CQUI'");
                else
                    rows = dt.Select("Column1 = '" + danhSachMonHocDaNhap[pos] + "' and Column17 = 'CLC'");
            }
            else
            {
                if (cbChuongTrinhDaoTao.Text == "Chính quy")
                    rows = dt.Select("Column2 = '" + danhSachMonHocDaNhap[pos] + "' and Column17 = 'CQUI'");
                else
                    rows = dt.Select("Column2 = '" + danhSachMonHocDaNhap[pos] + "' and Column17 = 'CLC'");
            }

            if (rows.Length > 0)
            {
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].ItemArray[10].ToString() == "*" || rows[i].ItemArray[11].ToString() == "*")
                        continue;

                    int thu = int.Parse(rows[i].ItemArray[10].ToString());
                    string tiets = rows[i].ItemArray[11].ToString();
                    bool coLich = true;

                    for (int j = 0; j < tiets.Length; j++)
                    {
                        int tiet = int.Parse(tiets[j].ToString());
                        if (checkTKB[tiet, thu] == true)
                        {
                            coLich = false;
                            break;
                        }
                    }

                    if (coLich)
                    {
                        for (int j = 0; j < tiets.Length; j++)
                        {
                            int tiet = int.Parse(tiets[j].ToString());
                            checkTKB[tiet, thu] = true;
                        }
                        MonHoc mh = new MonHoc(rows[i].ItemArray[1].ToString(), rows[i].ItemArray[2].ToString(), rows[i].ItemArray[3].ToString(), int.Parse(rows[i].ItemArray[7].ToString()), int.Parse(rows[i].ItemArray[10].ToString()), rows[i].ItemArray[11].ToString(), rows[i].ItemArray[17].ToString());
                        TKB.Add(mh);

                        if (TKB.Count == danhSachMonHocDaNhap.Count)
                            listTKB.Add(TKB);

                        TaoTKB(pos + 1, TKB, listTKB, checkTKB);
                        TKB.Remove(mh);
                        for (int j = 0; j < tiets.Length; j++)
                        {
                            int tiet = int.Parse(tiets[j].ToString());
                            checkTKB[tiet, thu] = false;
                        }
                    }
                }
            }
            else
                return;

            //TaoTKB(pos + 1, TKB, listTKB, checkTKB);
            //MessageBox.Show(danhSachMonHocDaNhap.Count.ToString() + " " + danhSachMaMonDaChon.Count.ToString());
        }
    }
}
