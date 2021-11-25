using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace ManageSchedule
{
    public partial class FormDangKy : Form
    {
        private string strCon = @"Server=172.107.32.132,10763;Database=manageschedule;User=xuanvuong;Password=Vuong21@!";
        private SqlConnection sqlCon = null;

        bool isShowPassMK = false;
        bool isShowPassXacNhan = false;
        string[] listNganh;
        public FormDangKy()
        {
            InitializeComponent();
            listNganh = new string[] { "Công nghệ Thông tin", "Hệ thống Thông tin", "Khoa học Máy tính", "Kỹ thuật Phần mềm", "Kỹ thuật Máy tính", "Mạng máy tính và Truyền thông", "An toàn Thông tin", "Thương mại điện tử", "Khoa học Dữ liệu"};
            comboBoxNganh.Items.AddRange(listNganh);
            comboBoxNganh.SelectedIndex = 0;
            textBoxHoTen.Focus();
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

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoten = textBoxHoTen.Text.Trim();
            string nganh = comboBoxNganh.Text;
            string khoahoc = textBoxKhoaHoc.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string taikhoan = textBoxTaiKhoan.Text.Trim();
            string matkhau = textBoxMatKhau.Text.Trim();
            string xacnhan = textBoxXacNhan.Text.Trim();

            if (hoten == string.Empty || khoahoc == string.Empty || email == string.Empty || taikhoan == string.Empty || matkhau == string.Empty || xacnhan == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int khoa = 0;
            int khoahochientai = DateTime.Now.Year - 2005;
            if (int.TryParse(khoahoc, out khoa))
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

            if (isEmail(textBoxEmail.Text) == false)
            {
                textBoxEmail.Text = "";
                textBoxEmail.Focus();
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (isTaiKhoan(textBoxTaiKhoan.Text) == false)
            {
                textBoxTaiKhoan.Text = "";
                textBoxTaiKhoan.Focus();
                MessageBox.Show("Tài khoản có độ dài ít nhất 4 ký tự, tối đa 20 ký tự bao gồm a-z, A-Z, 0-9, gạch dưới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (isMatKhau(textBoxMatKhau.Text) == false)
            {
                textBoxMatKhau.Text = "";
                textBoxMatKhau.Focus();
                MessageBox.Show("Mật khẩu có độ dài ít nhất 5 ký tự, tối đa 20 ký tự bao gồm a-z, A-Z, 0-9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxMatKhau.Text != textBoxXacNhan.Text)
            {
                textBoxXacNhan.Text = "";
                textBoxXacNhan.Focus();
                MessageBox.Show("Xác nhận mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from dbo.THONGTINTAIKHOAN";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            bool isExists = false;
            while (reader.Read())
            {
                string dbTaiKhoan = reader.GetString(4);
                if (textBoxTaiKhoan.Text == dbTaiKhoan)
                {
                    MessageBox.Show("Tài khoản đã được đăng kí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isExists = true;
                    break;
                }
            }

            if (isExists)
            {
                textBoxTaiKhoan.Text = "";
                textBoxTaiKhoan.Focus();
                reader.Close();
                sqlCmd.Dispose();
                sqlCon.Close();
                return;
            }

            reader.Close();
            sqlCmd.Dispose();

            using (SHA256 sha256hash = SHA256.Create())
            {
                string hash = MaHoa.GetHash(sha256hash, textBoxMatKhau.Text);

                SqlCommand sqlCmdInsert = new SqlCommand();
                sqlCmdInsert.CommandType = CommandType.Text;
                sqlCmdInsert.CommandText = "insert into dbo.THONGTINTAIKHOAN (HoVaTen, Nganh, KhoaHoc, Email, TaiKhoan, MatKhau) values (@hoten, @nganh, @khoahoc, @email, @taikhoan, @matkhau)";

                SqlParameter parHoten = new SqlParameter("@hoten", SqlDbType.NVarChar);
                parHoten.Value = textBoxHoTen.Text;

                SqlParameter parNganh = new SqlParameter("@nganh", SqlDbType.NVarChar);
                parNganh.Value = nganh;

                SqlParameter parKhoahoc = new SqlParameter("@khoahoc", SqlDbType.TinyInt);
                parKhoahoc.Value = khoa;

                SqlParameter parEmail = new SqlParameter("@email", SqlDbType.VarChar);
                parEmail.Value = textBoxEmail.Text;

                SqlParameter parTaiKhoan = new SqlParameter("@taikhoan", SqlDbType.VarChar);
                parTaiKhoan.Value = textBoxTaiKhoan.Text;

                SqlParameter parMatKhau = new SqlParameter("@matkhau", SqlDbType.VarChar);
                parMatKhau.Value = hash;

                sqlCmdInsert.Parameters.Add(parHoten);
                sqlCmdInsert.Parameters.Add(parNganh);
                sqlCmdInsert.Parameters.Add(parKhoahoc);
                sqlCmdInsert.Parameters.Add(parEmail);
                sqlCmdInsert.Parameters.Add(parTaiKhoan);
                sqlCmdInsert.Parameters.Add(parMatKhau);

                sqlCmdInsert.Connection = sqlCon;
                int kq = sqlCmdInsert.ExecuteNonQuery();
                if (kq > 0)
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Đăng ký không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxHoTen.Text = "";
                textBoxKhoaHoc.Text = "";
                comboBoxNganh.SelectedIndex = 0;
                textBoxEmail.Text = "";
                textBoxTaiKhoan.Text = "";
                textBoxMatKhau.Text = "";
                textBoxXacNhan.Text = "";
                textBoxHoTen.Focus();
                sqlCmdInsert.Dispose();
                sqlCon.Close();
            }
        }

        public static bool isMatKhau(string input) 
        {
            string strRegex = @"^[a-zA-Z0-9]{5,20}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isTaiKhoan(string input)
        {
            string strRegex = @"^[a-zA-Z0-9_]{4,20}$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(input))
                return (true);
            else
                return (false);
        }

        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool IsUnicode(string input)
        {
            return Encoding.ASCII.GetByteCount(input) != Encoding.UTF8.GetByteCount(input);
        }
    }
}
