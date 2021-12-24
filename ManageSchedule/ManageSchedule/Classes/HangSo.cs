using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchedule
{
    public static class HangSo
    {
        //public static string strCon = @"Server=204.2.195.207,18708;Database=manageschedule;User=team4;Password=Team45678";
        public static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        public static string txtFilePath = string.Format("{0}\\Data\\setting.txt", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\")));

        #region PropertyOfMonthView

        public static int DayofWeek = 7;
        public static int DayofColumn = 6;

        public static int dateButtonWidth_MV = 143;
        public static int dateButtonHeight_MV = 93;
        public static int Margin_MV = 2;
        public static readonly string[] DayofWeek_vn = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
        public static readonly string[] Month_vn = { "Tháng một", "Tháng hai", "Tháng ba", "Tháng tư", "Tháng năm", "Tháng sáu", "Tháng bảy", "Tháng tám", "Tháng chín", "Tháng mười", "Tháng mười một", "Tháng mười hai" };

        #endregion PropertyOfMonthView

        public static void SqlSetDateFormat()
        {
            SqlConnection sqlCon = new SqlConnection(strCon);
            sqlCon.Open();
            SqlCommand sqlSet = new SqlCommand("set dateformat dmy", sqlCon);

            sqlSet.ExecuteNonQuery();

            sqlSet.Dispose();
            sqlCon.Close();
        }
    }
}
