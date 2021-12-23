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
using System.Security.Cryptography;
using System.Configuration;

namespace ManageSchedule
{
    public partial class FormDangNhap : Form
    {      
        bool isShowPass = false;
        SqlConnection sqlCon = null;
        public FormDangNhap()
        {
            InitializeComponent();

            if (CaiDat.isPreLogin())
                btnDangNhap_Click(this, new EventArgs());
        }

        private void BtnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (isShowPass == false)
            {
                isShowPass = true;
                btnShowPass.Image = Properties.Resources.eye_solid;
                textBoxMatKhau.PasswordChar = '\0';
            }
            else
            {
                isShowPass = false;
                btnShowPass.Image = Properties.Resources.eye_slash_solid;
                textBoxMatKhau.PasswordChar = '*';
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Login();
        }

        #region Login

        private void Login()
        {
            string taikhoan = string.Empty;
            string matkhau = string.Empty;
            string hedaotao = string.Empty;

            // Kiểm tra lưu đăng nhập
            if (CaiDat.isPreLogin())
            {
                taikhoan = CaiDat.GetPreUsername();
                matkhau = CaiDat.GetPreHash();
            }
            else
            {
                taikhoan = textBoxTaiKhoan.Text.Trim();
                matkhau = textBoxMatKhau.Text.Trim();
            }     

            // Không lưu đăng nhập
            if (taikhoan == string.Empty)
            {
                textBoxTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (matkhau == string.Empty)
            {
                textBoxMatKhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!CaiDat.isPreLogin())
                {
                    SHA256 sha256hash = SHA256.Create();
                    matkhau = MaHoa.GetHash(sha256hash, textBoxMatKhau.Text.Trim());
                }
            }

            // Kiểm tra đăng nhập
           try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from dbo.THONGTINTAIKHOAN";

                sqlCmd.Connection = sqlCon;

                SqlDataReader reader = sqlCmd.ExecuteReader();
                bool isLogin = false;

                while (reader.Read())
                {
                    hedaotao = reader.GetString(3);
                    string dbTaiKhoan = reader.GetString(5);
                    string dbMatKhau = reader.GetString(6);

                    if (taikhoan == dbTaiKhoan && matkhau == dbMatKhau)
                    {
                        isLogin = true;
                        break;
                    }
                }

                reader.Close();
                sqlCmd.Dispose();
                sqlCon.Close();

                if (!isLogin)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Thêm phần ghi nhớ đăng nhập = true + nếu true thì mới lưu lại đăng nhập
                    // Lưu đăng nhập
                    CaiDat.SetPreLogin(taikhoan, matkhau);

                    // Mở ứng dụng
                    this.Hide();
                    this.Close();
                    if (hedaotao == "Chính quy")
                        hedaotao = "CQUI";
                    else
                        hedaotao = "CLC";
                    FormUngDung ungdung = new FormUngDung(hedaotao);
                    ungdung.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }

            /*string taikhoan = textBoxTaiKhoan.Text.Trim();
            string matkhau = textBoxMatKhau.Text.Trim();
            string hedaotao = string.Empty;

            if (taikhoan == string.Empty)
            {
                textBoxTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (matkhau == string.Empty)
            {
                textBoxMatKhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                using (SHA256 sha256Hash = SHA256.Create())
                {
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "select * from dbo.THONGTINTAIKHOAN";

                    sqlCmd.Connection = sqlCon;

                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    bool isLogin = false;

                    while (reader.Read())
                    {
                        hedaotao = reader.GetString(3);
                        string dbTaiKhoan = reader.GetString(5);
                        string dbMatKhau = reader.GetString(6);

                        if (textBoxTaiKhoan.Text == dbTaiKhoan && MaHoa.VerifyHash(sha256Hash, textBoxMatKhau.Text, dbMatKhau))
                        {
                            isLogin = true;
                            break;
                        }
                    }

                    reader.Close();
                    sqlCmd.Dispose();
                    sqlCon.Close();

                    if (!isLogin)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.Hide();
                        this.Close();
                        if (hedaotao == "Chính quy")
                            hedaotao = "CQUI";
                        else
                            hedaotao = "CLC";
                        FormUngDung ungdung = new FormUngDung(hedaotao);
                        ungdung.ShowDialog();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }*/
        }

        #endregion Login

        private void textBoxMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(this, new EventArgs());
        }
    }
}
