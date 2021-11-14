using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImportExcelFile
{
    public class Lop
    {
        string MaMH;
        string TenMH;
        string MaLop;
        string Thu;
        string Tiet;
        string CachTuan;
        string TenGV;
        public Lop(string _maMH, string _tenMH, string _maLop, string _thu, string _tiet, string _cachtuan, string _tenGV)
        {
            MaMH = _maMH;
            TenMH = _tenMH;
            MaLop = _maLop;
            Thu = _thu;
            Tiet = _tiet;
            CachTuan = _cachtuan;
            TenGV = _tenGV;
        }
        public Lop(Lop _lop)
        {
            this.MaMH = _lop.MaMH;
            this.TenMH = _lop.TenMH;
            this.MaLop = _lop.MaLop;
            this.Thu = _lop.Thu;
            this.Tiet = _lop.Tiet;
            this.CachTuan = _lop.CachTuan;
            this.TenGV = _lop.TenGV;
        }
        public string getMaMH()
        {
            return MaMH;
        }
        public string getThu()
        {
            return Thu;
        }
        public string getTiet()
        {
            return Tiet;
        }
        public string getMaLop()
        {
            return MaLop;
        }
    }

    //class MonHoc
    //{
    //    string MaMH;
    //    string TenMH;
    //    List<Lop> DS;

    //    public MonHoc(string _maMH, string _tenMH, Lop lop)
    //    {
    //        MaMH = _maMH;
    //        TenMH = _tenMH;
    //        DS.Add(lop);
    //    }
    //    public string getMaMH()
    //    {
    //        return MaMH;
    //    }
    //    public List<Lop> getDS()
    //    {
    //        return DS;
    //    }
    //}

    class RandomTablet
    {
        List<List<Lop>> DanhSachMon;
        List<Lop> DanhSachLop;
        public RandomTablet(DataGridView dgv)
        {
            DanhSachLop = new List<Lop>();
            //DanhSachMon = new List<List<Lop>>();
            //foreach (DataGridViewRow dgvr in dgv.Rows)
            //{
            //    foreach (List<Lop> mon in DanhSachMon)
            //    {
            //        if (dgvr.Cells[1].Value.ToString() == mon[index].)
            //        {
            //            mon.getDS().Add(new Lop(dgvr.Cells[1].Value.ToString(),
            //            dgvr.Cells[2].Value.ToString(),
            //            dgvr.Cells[10].Value.ToString(),
            //            dgvr.Cells[11].Value.ToString(),
            //            dgvr.Cells[12].Value.ToString(),
            //            dgvr.Cells[5].Value.ToString()));
            //        }
            //        else if (dgvr.Cells[1].Value.ToString() == "")
            //            break;
            //        else
            //        {
            //            dsm.Add(new MonHoc(dgvr.Cells[1].Value.ToString(),
            //            dgvr.Cells[3].Value.ToString(),
            //            new Lop(dgvr.Cells[1].Value.ToString(),
            //            dgvr.Cells[2].Value.ToString(),
            //            dgvr.Cells[10].Value.ToString(),
            //            dgvr.Cells[11].Value.ToString(),
            //            dgvr.Cells[12].Value.ToString(),
            //            dgvr.Cells[5].Value.ToString())));
            //        }
            //    }
            //}
        }

        public List<Lop> GetDSL()
        {
            return DanhSachLop;
        }

        public List<Lop> RemoveLop(Lop c)
        {
            DanhSachLop.Remove(c);
            return DanhSachLop;
        }

        public int AddLTbyClick(DataGridView dgv, int index)
        {
            Lop newClass = new Lop(dgv.Rows[index].Cells[1].Value.ToString(),  // mã môn
                dgv.Rows[index].Cells[3].Value.ToString(),                     // tên môn
                dgv.Rows[index].Cells[2].Value.ToString(),                     // mã lớp
                dgv.Rows[index].Cells[10].Value.ToString(),                    // thứ
                dgv.Rows[index].Cells[11].Value.ToString(),                    // tiết
                dgv.Rows[index].Cells[12].Value.ToString(),                    // cách tuần
                dgv.Rows[index].Cells[5].Value.ToString());                    // tên giảng viên
            if (DanhSachLop.Count != 0) 
            {
                // Kiểm tra trùng lịch
                foreach (Lop c in DanhSachLop)
                {
                    if (newClass.getThu() == c.getThu())
                    {
                        if (newClass.getThu() == "*")
                            continue;
                        foreach (char i in newClass.getTiet())
                        {
                            if (c.getTiet().Contains(i))
                            {
                                MessageBox.Show("Trùng lịch!", "Thông báo", MessageBoxButtons.OK);
                                return 0;
                            }
                        }
                    }
                    if (newClass.getMaMH()==c.getMaMH()&&newClass.getMaLop()!=c.getMaLop())
                    {
                        MessageBox.Show("Đã có môn học trong thời khóa biểu!", "Thông báo", MessageBoxButtons.OK);
                        return 0;
                    }
                }
            }
            DanhSachLop.Add(newClass);

            // Kiểm tra lớp học 2 buổi / tuần
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (newClass.getMaLop() == r.Cells[2].Value.ToString())
                {
                    Lop newClass2 = new Lop(r.Cells[1].Value.ToString(), // mã môn
                        r.Cells[3].Value.ToString(),                     // tên môn
                        r.Cells[2].Value.ToString(),                     // mã lớp
                        r.Cells[10].Value.ToString(),                    // thứ
                        r.Cells[11].Value.ToString(),                    // tiết
                        r.Cells[12].Value.ToString(),                    // cách tuần
                        r.Cells[5].Value.ToString());                    // tên giảng viên
                    if (newClass.getThu() != newClass2.getThu() || newClass.getTiet() != newClass2.getTiet())
                    {
                        foreach (Lop c in DanhSachLop)
                        {
                            if (newClass2.getThu() == c.getThu())
                                foreach (char i in newClass.getTiet())
                                {
                                    if (c.getTiet().Contains(i))
                                    {
                                        DanhSachLop.Remove(newClass);
                                        MessageBox.Show("Trùng lịch!", "Thông báo", MessageBoxButtons.OK);
                                        return 0;
                                    }
                                }
                        }
                        DanhSachLop.Add(newClass2);
                        return 2;
                    }
                }
            }
            return 1;
        }

        public bool AddTHbyClick(DataGridView dgvTH, int index, List<Lop> LopLT)
        {
            Lop newClass = new Lop(dgvTH.Rows[index].Cells[1].Value.ToString(),  // mã môn
                dgvTH.Rows[index].Cells[3].Value.ToString(),                     // tên môn
                dgvTH.Rows[index].Cells[2].Value.ToString(),                     // mã lớp
                dgvTH.Rows[index].Cells[10].Value.ToString(),                    // thứ
                dgvTH.Rows[index].Cells[11].Value.ToString(),                    // tiết
                dgvTH.Rows[index].Cells[12].Value.ToString(),                    // cách tuần
                dgvTH.Rows[index].Cells[5].Value.ToString());                    // tên giảng viên

            // Kiểm tra môn học đã có trong danh sách hoặc đã trùng lịch

            for (int i = 0; i < DanhSachLop.Count; i++)
            {
                // Nếu trong danh sách đã có môn học này thì báo lỗi
                if (newClass.getMaMH() == DanhSachLop[i].getMaMH())
                {
                    MessageBox.Show("Đã có môn học trong thời khóa biểu!", "Thông báo", MessageBoxButtons.OK);
                    return false;
                }

                // Nếu bị trùng lịch thì báo lỗi
                if (newClass.getThu() == DanhSachLop[i].getThu())
                {
                    if (newClass.getThu() == "*")
                        continue;
                    foreach (char c in newClass.getTiet())
                    {
                        if (DanhSachLop[i].getTiet().Contains(c))
                        {
                            MessageBox.Show("Trùng lịch!", "Thông báo", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }            

            // Kiểm tra có trùng lịch với các môn lý thuyết không
            foreach (Lop c in LopLT)
            {
                if (newClass.getThu() == c.getThu())
                {
                    if (newClass.getThu() == "*")
                        continue;
                    foreach (char i in newClass.getTiet())
                    {
                        if (c.getTiet().Contains(i))
                        {
                            MessageBox.Show("Trùng lịch!", "Thông báo", MessageBoxButtons.OK);
                            return false;
                        }
                    }
                }
            }
            // Kiểm tra đã có lớp lý thuyết tương ứng chưa 
            foreach (Lop c in LopLT) 
            {
                if (newClass.getMaLop().Contains(c.getMaLop()))
                {
                    DanhSachLop.Add(newClass);
                    return true;
                }
            }
            MessageBox.Show("Chưa chọn lớp lý thuyết tương ứng!", "Thông báo", MessageBoxButtons.OK);
            return false;
        }
    }
}
