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
        private static string FullName;
        //private static string StudentID;
        private static string Year;
        private static string Email;
        private static string Spec;
        private static string Sys;
        private static string strAvatar;

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
                    if (CaiDat.GetPreUsername() == reader.GetString(5))
                    {
                        FullName = reader.GetString(0);
                        //StudentID = "";
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
                    if (CaiDat.GetPreUsername() == reader2.GetString(0))
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
                    parTK.Value = CaiDat.GetPreUsername();

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

        #region Get Method
        public static string GetFullName()
        {
            return FullName;
        }
        //public static string GetID()
        //{
        //    return StudentID;
        //}
        public static string GetYear()
        {
            return Year;
        }
        public static string GetEmail()
        {
            return Email;
        }
        public static string GetSpec()
        {
            return Spec;
        }
        public static string GetSys()
        {
            return Sys;
        }
        public static string GetAvatar()
        {
            return strAvatar;
        }
        #endregion Get Method

        public static bool ChangeAccountInfo(string _fullName, /*string _studentID,*/ int _year, string _email, string _spec, string _sys)
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
                parTK.Value = CaiDat.GetPreUsername();

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

        public static void SetAvatar(string _strAva)
        {
            strAvatar = _strAva;
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
                parTK.Value = CaiDat.GetPreUsername();

                sqlCmdUpdate.Parameters.Add(parAva);
                sqlCmdUpdate.Parameters.Add(parTK);

                sqlCmdUpdate.Connection = sqlCon;
                sqlCmdUpdate.ExecuteNonQuery();            
                sqlCmdUpdate.Dispose();

                sqlCon.Close();

                strAvatar = _srtAva;

                MessageBox.Show("Thay đổi Avatar thành công!", "Thông báo", MessageBoxButtons.OK);

                return true;
            }
            catch (Exception e)
            {
                sqlCon.Close();

                MessageBox.Show(e.ToString());

                return false;
            }
        }
    }
}
