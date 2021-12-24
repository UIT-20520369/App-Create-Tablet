using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule
{
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        #region Show Password

        private void ShowPass_Click(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuImageButton btn = (Bunifu.UI.WinForms.BunifuImageButton)sender;

            switch (btn.Name)
            {
                case "btnShowPassHienTai":
                    if (TextBoxMatKhauHienTai.PasswordChar == '*')
                    {
                        TextBoxMatKhauHienTai.PasswordChar = '\0';
                        btn.Image = Properties.Resources.eye_solid;
                    }
                    else
                    {
                        TextBoxMatKhauHienTai.PasswordChar = '*';
                        btn.Image = Properties.Resources.eye_slash_solid;
                    }
                    break;
                case "btnShowPassMoi":
                    if (TextBoxMatKhauMoi.PasswordChar == '*')
                    {
                        TextBoxMatKhauMoi.PasswordChar = '\0';
                        btn.Image = Properties.Resources.eye_solid;
                    }
                    else
                    {
                        TextBoxMatKhauMoi.PasswordChar = '*';
                        btn.Image = Properties.Resources.eye_slash_solid;
                    }
                    break;
                case "btnShowPassXacNhan":
                    if (TextBoxXacNhanMatKhau.PasswordChar == '*')
                    {
                        TextBoxXacNhanMatKhau.PasswordChar = '\0';
                        btn.Image = Properties.Resources.eye_solid;
                    }
                    else
                    {
                        TextBoxXacNhanMatKhau.PasswordChar = '*';
                        btn.Image = Properties.Resources.eye_slash_solid;
                    }
                    break;
            }
        }


        #endregion Show Password

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (TextBoxMatKhauHienTai.Text == string.Empty || TextBoxMatKhauMoi.Text == string.Empty || TextBoxXacNhanMatKhau.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SHA256 sha256hash = SHA256.Create();
            string preHash = MaHoa.GetHash(sha256hash, TextBoxMatKhauHienTai.Text);

            if (preHash != CaiDat.PreHashPassword)
            {
                TextBoxMatKhauHienTai.Text = "";
                TextBoxMatKhauHienTai.Focus();
                MessageBox.Show("Mật khẩu hiện tại không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (FormDangKy.isMatKhau(TextBoxMatKhauMoi.Text) == false)
            {
                TextBoxMatKhauMoi.Text = "";
                TextBoxMatKhauMoi.Focus();
                MessageBox.Show("Mật khẩu mới phải có độ dài ít nhất 5 ký tự, tối đa 20 ký tự bao gồm a-z, A-Z, 0-9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TextBoxMatKhauMoi.Text != TextBoxXacNhanMatKhau.Text)
            {
                TextBoxXacNhanMatKhau.Text = "";
                TextBoxXacNhanMatKhau.Focus();
                MessageBox.Show("Xác nhận mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hash = MaHoa.GetHash(sha256hash, TextBoxMatKhauMoi.Text);
            if (TaiKhoan.ChangePassword(hash))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }
    }
}
