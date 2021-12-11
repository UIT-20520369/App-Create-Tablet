using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace ManageSchedule
{
    public partial class ChildFormDoiMatKhau : Form
    {
        public ChildFormDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnShowNowPass_Click(object sender, EventArgs e)
        {
            if (textBoxMatKhauHienTai.PasswordChar == '*')
            {
                textBoxMatKhauHienTai.PasswordChar = '\0';
                btnShowNowPass.Image = Properties.Resources.eye_solid;
            }
            else
            {
                textBoxMatKhauHienTai.PasswordChar = '*';
                btnShowNowPass.Image = Properties.Resources.eye_slash_solid;
            }
        }

        private void btnShowPassMK_Click(object sender, EventArgs e)
        {
            if (textBoxMatKhauMoi.PasswordChar == '*')
            {
                textBoxMatKhauMoi.PasswordChar = '\0';
                btnShowPassMK.Image = Properties.Resources.eye_solid;
            }
            else
            {
                textBoxMatKhauMoi.PasswordChar = '*';
                btnShowPassMK.Image = Properties.Resources.eye_slash_solid;
            }
        }

        private void btnShowPassXacNhan_Click(object sender, EventArgs e)
        {        
            if (textBoxXacNhan.PasswordChar == '*')
            {
                textBoxXacNhan.PasswordChar = '\0';
                btnShowPassXacNhan.Image = Properties.Resources.eye_solid;
            }
            else
            {
                textBoxXacNhan.PasswordChar = '*';
                btnShowPassXacNhan.Image = Properties.Resources.eye_slash_solid;
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (textBoxMatKhauHienTai.Text == string.Empty || textBoxMatKhauMoi.Text == string.Empty || textBoxXacNhan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SHA256 sha256hash = SHA256.Create();
            string preHash = MaHoa.GetHash(sha256hash, textBoxMatKhauHienTai.Text);

            if (preHash != CaiDat.GetPreHash())
            {
                textBoxMatKhauHienTai.Text = "";
                textBoxMatKhauHienTai.Focus();
                MessageBox.Show("Mật khẩu hiện tại không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormDangKy.isMatKhau(textBoxMatKhauMoi.Text) == false)
            {
                textBoxMatKhauMoi.Text = "";
                textBoxMatKhauMoi.Focus();
                MessageBox.Show("Mật khẩu mới phải có độ dài ít nhất 5 ký tự, tối đa 20 ký tự bao gồm a-z, A-Z, 0-9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxMatKhauMoi.Text != textBoxXacNhan.Text)
            {
                textBoxXacNhan.Text = "";
                textBoxXacNhan.Focus();
                MessageBox.Show("Xác nhận mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string hash = MaHoa.GetHash(sha256hash, textBoxMatKhauMoi.Text);
            if (CaiDat.ChangePassword(hash))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công!", "Thông báo", MessageBoxButtons.OK);
            }

            this.Close();
        }
    }
}
