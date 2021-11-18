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
    public partial class FormDangKy : Form
    {
        bool isShowPassMK = false;
        bool isShowPassXacNhan = false;
        string[] listNganh;
        public FormDangKy()
        {
            InitializeComponent();
            listNganh = new string[] { "Công nghệ Thông tin", "Hệ thống Thông tin", "Khoa học Máy tính", "Kỹ thuật Phần mềm", "Kỹ thuật Máy tính", "Mạng máy tính và Truyền thông", "An toàn Thông tin", "Thương mại điện tử", "Khoa học Dữ liệu"};
            comboBoxNganh.Items.AddRange(listNganh);
        }

        private void BtnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDangNhap dangnhap = new FormDangNhap();
            dangnhap.ShowDialog();
            this.Close();
        }

        private void btnShowPassMK_Click(object sender, EventArgs e)
        {
            if (isShowPassMK == false)
            {
                isShowPassMK = true;
                textBoxMatKhau.PasswordChar = '\0';
                btnShowPassMK.Image = Properties.Resources.eye_solid;
            }
            else
            {
                isShowPassMK = false;
                textBoxMatKhau.PasswordChar = '*';
                btnShowPassMK.Image = Properties.Resources.eye_slash_solid;
            }
        }

        private void btnShowPassXacNhan_Click(object sender, EventArgs e)
        {
            if (isShowPassXacNhan == false)
            {
                isShowPassXacNhan = true;
                textBoxXacNhan.PasswordChar = '\0';
                btnShowPassXacNhan.Image = Properties.Resources.eye_solid;
            }
            else
            {
                isShowPassXacNhan = false;
                textBoxXacNhan.PasswordChar = '*';
                btnShowPassXacNhan.Image = Properties.Resources.eye_slash_solid;
            }
        }
    }
}
