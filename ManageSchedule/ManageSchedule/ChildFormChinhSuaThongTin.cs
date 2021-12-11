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
    public partial class ChildFormChinhSuaThongTin : Form
    {
        public ChildFormChinhSuaThongTin()
        {
            InitializeComponent();

            textBoxHoTen.Text = TaiKhoan.GetFullName();

            string[] listNganh = new string[] { "Công nghệ Thông tin", "Hệ thống Thông tin", "Khoa học Máy tính", "Kỹ thuật Phần mềm", "Kỹ thuật Máy tính", "Mạng máy tính và Truyền thông", "An toàn Thông tin", "Thương mại điện tử", "Khoa học Dữ liệu" };
            comboBoxNganh.Items.AddRange(listNganh);
            int index = 0;
            foreach (string _nganh in listNganh)
            {
                if (_nganh == TaiKhoan.GetSpec())
                    break;
                index++;
            }
            comboBoxNganh.SelectedIndex = index;

            string[] listHe = new string[] { "Chính quy", "Chất lượng cao"};
            comboBoxHeDaoTao.Items.AddRange(listHe);
            index = 0;
            foreach (string _he in listHe)
            {
                if (_he == TaiKhoan.GetSys())
                    break;
                index++;
            }
            comboBoxHeDaoTao.SelectedIndex = index;

            textBoxKhoaHoc.Text = TaiKhoan.GetYear();
            textBoxEmail.Text = TaiKhoan.GetEmail();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textBoxHoTen.Text.Trim() == string.Empty || textBoxKhoaHoc.Text == string.Empty || textBoxEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int khoa = 0;
            int khoahochientai = DateTime.Now.Year - 2005;
            if (int.TryParse(textBoxKhoaHoc.Text, out khoa))
            {
                if (khoa < 1 || khoa > khoahochientai)
                {
                    MessageBox.Show("Khóa học phải là số nguyên từ 1 đến " + khoahochientai.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxKhoaHoc.Text = "";
                    textBoxKhoaHoc.Focus();
                    return;
                }
            }
            else
            {
                textBoxKhoaHoc.Text = "";
                textBoxKhoaHoc.Focus();
                MessageBox.Show("Khóa học phải là số nguyên từ 1 đến " + khoahochientai.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FormDangKy.isEmail(textBoxEmail.Text) == false)
            {
                textBoxEmail.Text = "";
                textBoxEmail.Focus();
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (TaiKhoan.ChangeAccountInfo(textBoxHoTen.Text.Trim(),
                     Convert.ToInt32(textBoxKhoaHoc.Text),
                     textBoxEmail.Text.Trim(),
                     comboBoxNganh.SelectedItem.ToString(),
                     comboBoxHeDaoTao.SelectedItem.ToString()))
                MessageBox.Show("Chỉnh sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
            else
                MessageBox.Show("Chỉnh sửa thông tin không thành công!", "Thông báo", MessageBoxButtons.OK);

            this.Close();
        }

        private void textBoxKhoaHoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
