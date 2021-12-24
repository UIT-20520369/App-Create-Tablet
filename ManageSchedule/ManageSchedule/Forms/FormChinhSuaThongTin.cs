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
    public partial class FormChinhSuaThongTin : Form
    {
        public FormChinhSuaThongTin()
        {
            InitializeComponent();

            TextBoxHoTen.Text = TaiKhoan.FullName;

            string[] ListNganh = new string[] { "Công nghệ Thông tin", "Hệ thống Thông tin", "Khoa học Máy tính", "Kỹ thuật Phần mềm", "Kỹ thuật Máy tính", "Mạng máy tính và Truyền thông", "An toàn Thông tin", "Thương mại điện tử", "Khoa học Dữ liệu" };
            ComboBoxNganh.Items.AddRange(ListNganh);
            int index = 0;
            foreach (string nganh in ListNganh)
            {
                if (nganh == TaiKhoan.Spec)
                    break;
                index++;
            }
            ComboBoxNganh.SelectedIndex = index;

            string[] ListHeDaoTao = new string[] { "Chính quy", "Chất lượng cao" };
            ComboBoxHeDaoTao.Items.AddRange(ListHeDaoTao);
            index = 0;
            foreach (string hedaotao in ListHeDaoTao)
            {
                if (hedaotao == TaiKhoan.Sys)
                    break;
                index++;
            }
            ComboBoxHeDaoTao.SelectedIndex = index;

            TextBoxKhoaHoc.Text = TaiKhoan.Year;
            TextBoxEmail.Text = TaiKhoan.Email;
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (TextBoxHoTen.Text.Trim() == string.Empty || TextBoxKhoaHoc.Text == string.Empty || TextBoxEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int khoa = 0;
            int khoahochientai = DateTime.Now.Year - 2005;
            if (int.TryParse(TextBoxKhoaHoc.Text, out khoa))
            {
                if (khoa < 1 || khoa > khoahochientai)
                {
                    MessageBox.Show("Khóa học phải là số nguyên từ 1 đến " + khoahochientai.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxKhoaHoc.Text = "";
                    TextBoxKhoaHoc.Focus();
                    return;
                }
            }
            else
            {
                TextBoxKhoaHoc.Text = "";
                TextBoxKhoaHoc.Focus();
                MessageBox.Show("Khóa học phải là số nguyên từ 1 đến " + khoahochientai.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormDangKy.isEmail(TextBoxEmail.Text) == false)
            {
                TextBoxEmail.Text = "";
                TextBoxEmail.Focus();
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (TaiKhoan.ChangeAccountInfo(TextBoxHoTen.Text.Trim(),
                     Convert.ToInt32(TextBoxKhoaHoc.Text),
                     TextBoxEmail.Text.Trim(),
                     ComboBoxNganh.SelectedItem.ToString(),
                     ComboBoxHeDaoTao.SelectedItem.ToString()))
                MessageBox.Show("Chỉnh sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Chỉnh sửa thông tin không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void TextBoxKhoaHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }
    }
}
