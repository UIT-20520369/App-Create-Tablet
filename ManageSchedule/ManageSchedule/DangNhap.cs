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
        //string strCon = @"Server=209.209.40.89,19058;Database=manageschedule;User=team4;Password=Team45678";
        SqlConnection sqlCon = null;
        string curuser = "";
        public FormDangNhap()
        {
            InitializeComponent();
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
            string taikhoan = textBoxTaiKhoan.Text.Trim();
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
                        curuser = dbTaiKhoan;
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
                    FormUngDung ungdung = new FormUngDung(hedaotao,curuser);
                    ungdung.ShowDialog();
                }
            }
        }
    }
}
