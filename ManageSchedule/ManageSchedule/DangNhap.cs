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
using System.IO;

namespace ManageSchedule
{
    public partial class FormDangNhap : Form
    {
        bool isShowPass = false;
        string strCon = @"Server=172.107.32.132,10763;Database=manageschedule;User=xuanvuong;Password=Vuong21@!";
        SqlConnection sqlCon = null;
        internal static string SettingFile;
        internal static string[] setting;

        public FormDangNhap()
        {
            InitializeComponent();

            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            SettingFile = string.Format("{0}\\setting.txt", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
            setting = System.IO.File.ReadAllLines(SettingFile);
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

        internal bool KiemTraDangNhap(string _taiKhoan, string _matKhau)
        {
            if (_taiKhoan == string.Empty)
            {
                textBoxTaiKhoan.Focus();
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (_matKhau == string.Empty)
            {
                textBoxMatKhau.Focus();
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);

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
                    string dbTaiKhoan = reader.GetString(4);
                    string dbMatKhau = reader.GetString(5);

                    if (setting[3] != "" && setting[4] != "")
                    {
                        if (_taiKhoan == dbTaiKhoan && _matKhau == dbMatKhau)
                        {
                            isLogin = true;
                            break;
                        }
                    }
                    else if (_taiKhoan == dbTaiKhoan && MaHoa.VerifyHash(sha256Hash, _matKhau, dbMatKhau))
                    {
                        isLogin = true;
                        break;
                    }
                }

                reader.Close();
                sqlCmd.Dispose();
                sqlCon.Close();

                return isLogin;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = textBoxTaiKhoan.Text.Trim();
            string matkhau = textBoxMatKhau.Text.Trim();

            if (!KiemTraDangNhap(taikhoan, matkhau))
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Hide();
                this.Close();

                SHA256 sha256hash = SHA256.Create();
                string hash = MaHoa.GetHash(sha256hash, matkhau);
                setting[3] = taikhoan;
                setting[4] = hash;
                File.WriteAllLines(SettingFile, setting);

                FormUngDung ungdung = new FormUngDung();
                ungdung.ShowDialog();
            }
        }

        private void textBoxMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(this, new EventArgs());
        }
    }
}
