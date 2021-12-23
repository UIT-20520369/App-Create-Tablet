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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ManageSchedule
{
    public partial class FormQuenMatKhau : Form
    {
        #region Declare

        public int code = 0;
        private string Email = string.Empty;
        Random random = new Random();
        bool isShowPassMatKhau = false;
        bool isShowPassXacNhan = false;
        SqlConnection sqlCon = null;

        #endregion Declare

        public FormQuenMatKhau()
        {
            InitializeComponent();

            #region Init

            labelMatKhau.Visible = false;
            labelNhapLai.Visible = false;
            labelOTP.Visible = false;
            TextBoxOTP.Visible = false;
            CircleProgress.Visible = false;
            btnXacNhan.Visible = false;
            TextBoxMatKhau.Visible = false;
            TextBoxNhapLai.Visible = false;
            btnDoiMatKhau.Visible = false;
            btnShowPassMK.Visible = false;
            btnShowPassXN.Visible = false;
            bunifuLoader.Visible = false;

            #endregion Init
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Show Password

        private void btnShowPassMK_Click(object sender, EventArgs e)
        {
            if (isShowPassMatKhau == false)
            {
                isShowPassMatKhau = true;
                btnShowPassMK.Image = Properties.Resources.eye_solid;
                TextBoxMatKhau.PasswordChar = '\0';
            }
            else
            {
                isShowPassMatKhau = false;
                btnShowPassMK.Image = Properties.Resources.eye_slash_solid;
                TextBoxMatKhau.PasswordChar = '*';
            }
        }

        private void btnShowPassXN_Click(object sender, EventArgs e)
        {
            if (isShowPassXacNhan == false)
            {
                isShowPassXacNhan = true;
                btnShowPassXN.Image = Properties.Resources.eye_solid;
                TextBoxNhapLai.PasswordChar = '\0';
            }
            else
            {
                isShowPassXacNhan = false;
                btnShowPassXN.Image = Properties.Resources.eye_slash_solid;
                TextBoxNhapLai.PasswordChar = '*';
            }
        }

        #endregion Show Password

        private void mail()
        {
            code = random.Next(123123, 999999);
            const string p = "1786045148";

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("20520369@gm.uit.edu.vn");

            //Enter your email blow and also change in database too

            message.To.Add(new MailAddress(Email));
            message.Subject = "Đổi mật khẩu";
            message.Body = "Đây là mã xác nhận của bạn\n" + code;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("20520369@gm.uit.edu.vn", p);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            MessageBox.Show("Đã gửi mã OTP về email của bạn, vui lòng kiểm tra và xác nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            bunifuLoader.Visible = false;
            TextBoxOTP.Visible = true;
            CircleProgress.Visible = true;
            btnXacNhan.Visible = true;
            TextBoxMatKhau.Visible = false;
            TextBoxNhapLai.Visible = false;
        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            CircleProgress.Value = 60;
            try
            {
                if (sqlCon == null)
                    sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from dbo.THONGTINTAIKHOAN where TaiKhoan =@us";
                SqlParameter us = new SqlParameter("@us", SqlDbType.VarChar);
                us.Value = TextBoxTaiKhoan.Text;
                sqlCmd.Parameters.Add(us);
                sqlCmd.Connection = sqlCon;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        Email = reader.GetString(4);
                        break;
                    } 
                    catch
                    {
                        MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TextBoxTaiKhoan.Text = "";
                        TextBoxTaiKhoan.Focus();
                        break;
                    }
                }

                if (Email != string.Empty)
                {
                    bunifuLoader.Visible = true;
                    mail();
                    labelOTP.Visible = true;
                    btnGuiMa.Enabled = false;
                    btnGuiMa.Visible = false;
                    TimerCountDown.Enabled = true;
                    TimerCountDown.Start();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxTaiKhoan.Text = "";
                    TextBoxTaiKhoan.Focus();
                }

                reader.Close();
                sqlCmd.Dispose();
                sqlCon.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        private void TimerCountDown_Tick(object sender, EventArgs e)
        {
            if (CircleProgress.Value > 0)
                CircleProgress.Value--;
            else
            {
                TimerCountDown.Stop();
                TimerCountDown.Enabled = false;
                MessageBox.Show("Mã OTP đã hết hạn vui lòng tạo mã OTP mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CircleProgress.Visible = false;
                btnGuiMa.Visible = true;
                btnGuiMa.Enabled = true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (code.ToString() == TextBoxOTP.Text)
            {
                TimerCountDown.Stop();
                CircleProgress.Visible = false;
                TextBoxMatKhau.Visible = true;
                TextBoxNhapLai.Visible = true;
                labelMatKhau.Visible = true;
                labelNhapLai.Visible = true;
                btnDoiMatKhau.Visible = true;
                btnShowPassMK.Visible = true;
                btnShowPassXN.Visible = true;
            }
            else
            {
                MessageBox.Show("Mã xác nhận không chính xác xin vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TextBoxOTP.Text = "";
                TextBoxOTP.Focus();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxMatKhau.Text) || string.IsNullOrEmpty(TextBoxNhapLai.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (isMatKhau(TextBoxMatKhau.Text) == false)
                {
                    TextBoxMatKhau.Text = "";
                    TextBoxMatKhau.Focus();
                    MessageBox.Show("Mật khẩu có độ dài ít nhất 5 ký tự, tối đa 20 ký tự bao gồm a-z, A-Z, 0-9", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (TextBoxMatKhau.Text == TextBoxNhapLai.Text)
                {
                    if (sqlCon == null)
                        sqlCon = new SqlConnection(HangSo.strCon);

                    if (sqlCon.State == ConnectionState.Closed)
                        sqlCon.Open();
                    using (SHA256 sha256hash = SHA256.Create())
                    {
                        string hash = MaHoa.GetHash(sha256hash, TextBoxMatKhau.Text);
                        SqlCommand sqlCmd = new SqlCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "update dbo.THONGTINTAIKHOAN set Matkhau=@ps where taikhoan =@us";
                        SqlParameter us = new SqlParameter("@us", SqlDbType.VarChar);
                        us.Value = TextBoxTaiKhoan.Text;
                        sqlCmd.Parameters.Add(us);
                        SqlParameter ps = new SqlParameter("@ps", SqlDbType.VarChar);
                        ps.Value = hash;
                        sqlCmd.Parameters.Add(ps);
                        sqlCmd.Connection = sqlCon;
                        SqlDataReader reader = sqlCmd.ExecuteReader();
                        reader.Close();
                        sqlCmd.Dispose();
                        sqlCon.Close();
                    }
                    MessageBox.Show("Bạn đã đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu xác nhận không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BatDau.isThoat = true;
                Application.Exit();
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
    }
}
