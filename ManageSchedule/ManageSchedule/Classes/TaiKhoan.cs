using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ManageSchedule
{
    class TaiKhoan
    {
        #region Properties
        private static string fullName;
        public static string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private static string year;
        public static string Year
        {
            get { return year; }
            set { year = value; }
        }

        private static string email;
        public static string Email
        {
            get { return email; }
            set { email = value; }
        }

        private static string spec;
        public static string Spec
        {
            get { return spec; }
            set { spec = value; }
        }
        private static string sys;
        public static string Sys
        {
            get { return sys; }
            set { sys = value; }
        }

        private static string strAvatar;
        public static string Avatar
        {
            get { return strAvatar; }
            set { strAvatar = value; }
        }
        #endregion Properties

        public TaiKhoan()
        {
            try
            {
                SqlConnection sqlCon = null;
                sqlCon = new SqlConnection(HangSo.strCon);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "select * from dbo.THONGTINTAIKHOAN";

                sqlCmd.Connection = sqlCon;

                SqlDataReader reader = sqlCmd.ExecuteReader();

                while (reader.Read())
                {
                    if (CaiDat.PreUsername == reader.GetString(5))
                    {
                        FullName = reader.GetString(0);
                        Year = reader.GetByte(2).ToString();
                        Email = reader.GetString(4);
                        Spec = reader.GetString(1);
                        Sys = reader.GetString(3);
                        break;
                    }
                }

                reader.Close();
                sqlCmd.Dispose();

                bool hasAvatar = false;

                SqlCommand sqlCmdAvatar = new SqlCommand();
                sqlCmdAvatar.CommandType = CommandType.Text;
                sqlCmdAvatar.CommandText = "select * from dbo.AVATAR";

                sqlCmdAvatar.Connection = sqlCon;

                SqlDataReader reader2 = sqlCmdAvatar.ExecuteReader();

                while (reader2.Read())
                {
                    if (CaiDat.PreUsername == reader2.GetString(0))
                    {
                        strAvatar = reader2.GetString(1);
                        hasAvatar = true;
                        break;
                    }
                }
                reader2.Close();
                sqlCmdAvatar.Dispose();

                if (!hasAvatar)
                {
                    SqlCommand sqlCmdInsert = new SqlCommand();
                    sqlCmdInsert.CommandType = CommandType.Text;
                    sqlCmdInsert.CommandText = "insert into dbo.AVATAR (TaiKhoan, strAVATAR) values (@TaiKhoan,@strAvatar)";

                    SqlParameter parAva = new SqlParameter("@strAvatar", SqlDbType.Text);
                    parAva.Value = string.Empty;
                    SqlParameter parTK = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
                    parTK.Value = CaiDat.PreUsername;

                    sqlCmdInsert.Parameters.Add(parAva);
                    sqlCmdInsert.Parameters.Add(parTK);

                    sqlCmdInsert.Connection = sqlCon;

                    sqlCmdInsert.ExecuteNonQuery();

                    sqlCmdInsert.Dispose();

                    strAvatar = string.Empty;
                }

                //string[] setting = System.IO.File.ReadAllLines(HangSo.txtFilePath);
                //strAvatar = setting[8];

                sqlCon.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi mạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BatDau.isThoat = true;
                Application.Exit();
            }
        }

        #region Change Account
        public static bool ChangeAccountInfo(string _fullName, int _year, string _email, string _spec, string _sys)
        {
            SqlConnection sqlCon = null;
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            try
            {
                SqlCommand sqlCmdUpdate = new SqlCommand();
                sqlCmdUpdate.CommandType = CommandType.Text;
                sqlCmdUpdate.CommandText = "update dbo.Thongtintaikhoan " +
                    "set HoVaTen=@HoTen, Nganh=@Nganh, KhoaHoc=@KhoaHoc, Email=@Email, HeDaoTao=@HeDaoTao " +
                    "where TaiKhoan=@TaiKhoan";

                SqlParameter parHoTen = new SqlParameter("@HoTen", SqlDbType.NVarChar);
                parHoTen.Value = _fullName;

                //SqlParameter parMSSV = new SqlParameter("@StudentID", SqlDbType.NVarChar);
                //parMSSV.Value = _studentID;

                SqlParameter parKhoa = new SqlParameter("@KhoaHoc", SqlDbType.TinyInt);
                parKhoa.Value = _year;

                SqlParameter parEmail = new SqlParameter("@Email", SqlDbType.VarChar);
                parEmail.Value = _email;

                SqlParameter parNganh = new SqlParameter("@Nganh", SqlDbType.NVarChar);
                parNganh.Value = _spec;

                SqlParameter parHe = new SqlParameter("@HeDaoTao", SqlDbType.NVarChar);
                parHe.Value = _sys;

                SqlParameter parTK = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
                parTK.Value = CaiDat.PreUsername;

                sqlCmdUpdate.Parameters.Add(parHoTen);
                sqlCmdUpdate.Parameters.Add(parNganh);
                sqlCmdUpdate.Parameters.Add(parKhoa);
                sqlCmdUpdate.Parameters.Add(parEmail);
                sqlCmdUpdate.Parameters.Add(parHe);
                sqlCmdUpdate.Parameters.Add(parTK);

                sqlCmdUpdate.Connection = sqlCon;

                sqlCmdUpdate.ExecuteNonQuery();

                sqlCmdUpdate.Dispose();

                sqlCon.Close();

                FullName = _fullName;
                Year = _year.ToString();
                Email = _email;
                Spec = _spec;
                Sys = _sys;

                return true;
            }
            catch
            {
                sqlCon.Close();

                return false;
            }
        }

        public static bool ChangePassword(string _hash)
        {
            SqlConnection sqlCon = null;
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            try
            {
                SqlCommand sqlCmdUpdate = new SqlCommand();
                sqlCmdUpdate.CommandType = CommandType.Text;
                sqlCmdUpdate.CommandText = "update dbo.Thongtintaikhoan " +
                    "set MatKhau=@MatKhau " +
                    "where TaiKhoan=@TaiKhoan";

                SqlParameter parMK = new SqlParameter("@MatKhau", SqlDbType.VarChar);
                parMK.Value = _hash;

                SqlParameter parTK = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
                parTK.Value = CaiDat.PreUsername;

                sqlCmdUpdate.Parameters.Add(parMK);
                sqlCmdUpdate.Parameters.Add(parTK);

                sqlCmdUpdate.Connection = sqlCon;

                sqlCmdUpdate.ExecuteNonQuery();

                sqlCmdUpdate.Dispose();

                sqlCon.Close();

                CaiDat.PreHashPassword = _hash;

                return true;
            }
            catch
            {
                sqlCon.Close();

                return false;
            }
        }

        public static bool ChangeAvatar(string _srtAva)
        {
            SqlConnection sqlCon = null;
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            try
            {
                SqlCommand sqlCmdUpdate = new SqlCommand();
                sqlCmdUpdate.CommandType = CommandType.Text;
                sqlCmdUpdate.CommandText = "update dbo.AVATAR " +
                    "set strAVATAR=@strAvatar " +
                    "where TaiKhoan=@TaiKhoan";

                SqlParameter parAva = new SqlParameter("@strAvatar", SqlDbType.Text);
                parAva.Value = _srtAva;
                SqlParameter parTK = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
                parTK.Value = CaiDat.PreUsername;

                sqlCmdUpdate.Parameters.Add(parAva);
                sqlCmdUpdate.Parameters.Add(parTK);

                sqlCmdUpdate.Connection = sqlCon;
                sqlCmdUpdate.ExecuteNonQuery();
                sqlCmdUpdate.Dispose();

                sqlCon.Close();

                strAvatar = _srtAva;

                return true;
            }
            catch
            {
                sqlCon.Close();

                return false;
            }
        }
        #endregion Change Account
    }
}


