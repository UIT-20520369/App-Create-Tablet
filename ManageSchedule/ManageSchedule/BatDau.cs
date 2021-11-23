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

            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            FormDangNhap.SettingFile = string.Format("{0}\\setting.txt", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            FormDangNhap.setting = System.IO.File.ReadAllLines(FormDangNhap.SettingFile);

            FormDangNhap.setting[2] = "ShowInTaskbar: true";
            File.WriteAllLines(FormDangNhap.SettingFile, FormDangNhap.setting);
            Visible = true;
            ShowInTaskbar = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            isThoat = true;
            FormDangNhap.setting = File.ReadAllLines(FormDangNhap.SettingFile);
            FormDangNhap.setting[2] = "ShowInTaskbar: false";
            File.WriteAllLines(FormDangNhap.SettingFile, FormDangNhap.setting);
            Visible = false;
            ShowInTaskbar = false;
            if (FormDangNhap.setting[0] == "StartupShortcut: false")
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
    }
}
