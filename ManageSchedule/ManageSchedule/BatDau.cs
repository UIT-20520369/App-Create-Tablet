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
namespace ManageSchedule
{
    public partial class BatDau : Form
    {
        internal static bool isThoat;
        static string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        string ExcelFile = string.Format(@"{0}\Data\TKB.xlsx", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
        Workbook wb = new Workbook();
        public BatDau()
        {
            wb.LoadDocument(ExcelFile, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
            InitializeComponent();
            toolTipBtnThoat.SetToolTip(btnThoat, "Thoát ứng dụng");
            toolTipBtnMini.SetToolTip(btnMini, "Minimize");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            isThoat = false;
            FormDangNhap dangnhap = new FormDangNhap();
            this.Hide();
            dangnhap.ShowDialog();
            if (!isThoat)
                this.Show();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            isThoat = false;
            FormDangKy dangky = new FormDangKy();
            this.Hide();
            dangky.ShowDialog();
            if (!isThoat)
                this.Show();
        }

        private void btnKhach_Click(object sender, EventArgs e)
        {
            isThoat = false;
            FormDungNgay dungngay = new FormDungNgay(wb);
            this.Hide();
            dungngay.ShowDialog();
            if (!isThoat)
                this.Show();
        }
    }
}
