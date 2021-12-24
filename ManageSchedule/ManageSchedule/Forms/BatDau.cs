using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule
{
    public partial class BatDau : Form
    {
        internal static bool isThoat;
        public BatDau()
        {
            InitializeComponent();
            toolTipBtnThoat.SetToolTip(btnThoat, "Thoát ứng dụng");
            toolTipBtnMini.SetToolTip(btnMini, "Minimize");

            if (CaiDat.isPreLogin())
                btnDangNhap_Click(this, new EventArgs());
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
            try
            {
                dangnhap.ShowDialog();
            }
            catch
            {
                this.Hide();
            }
            if (!isThoat)
                this.Show();
        }

        internal void btnDangKy_Click(object sender, EventArgs e)
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
            FormDungNgay dungngay = new FormDungNgay();
            this.Hide();
            dungngay.ShowDialog();
            if (!isThoat)
                this.Show();
        }
    }
}
