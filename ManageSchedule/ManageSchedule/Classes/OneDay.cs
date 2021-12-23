using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchedule.Classes
{
    public class OneDay : IComparable<OneDay>
    {
        public int CompareTo(OneDay obj)
        {
            return this.day.CompareTo(obj.Day);
        }
        private List<OneEvent> listOfDay;
        public List<OneEvent> ListOfDay
        {
            get { return listOfDay; }
            set { listOfDay = value; }
        }

        private DateTime day;
        public DateTime Day
        {
            get { return day; }
            set { day = value; }
        }

        public OneDay(DateTime day, bool isGetNotify = false)
        {
            listOfDay = new List<OneEvent>();
            this.day = day;
            if (isGetNotify)
            {
                GetNotify();
            }
        }



        public void UploadData(ref SqlConnection sqlCon)
        {
            HangSo.SqlSetDateFormat();
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlSelect = new SqlCommand("select * from dbo.SUKIEN where USERNAME = @username and NGAY >= @ngay1 and NGAY <= @ngay2 order by NGAY asc", sqlCon);
            sqlSelect.Parameters.Add("@username", SqlDbType.VarChar);
            sqlSelect.Parameters["@username"].Value = CaiDat.GetPreUsername();

            sqlSelect.Parameters.Add("@ngay1", SqlDbType.DateTime);
            sqlSelect.Parameters["@ngay1"].Value = new DateTime(Day.Year, Day.Month, Day.Day, 0, 0, 0);
            sqlSelect.Parameters.Add("@ngay2", SqlDbType.DateTime);
            sqlSelect.Parameters["@ngay2"].Value = new DateTime(Day.Year, Day.Month, Day.Day, 23, 59, 59);

            var reader = sqlSelect.ExecuteReader();
            while (reader.Read())
            {
                OneEvent one = new OneEvent();
                one.ID = reader.GetInt32(1);
                one.TieuDe = reader.GetString(2);
                one.Ngay = reader.GetDateTime(3);
                if (reader.GetValue(4) != DBNull.Value)
                {
                    one.ToiNgay = reader.GetDateTime(4);
                }
                if (reader.GetValue(5) != DBNull.Value)
                {
                    one.MonHoc = reader.GetString(5);
                }
                if (reader.GetValue(6) != DBNull.Value)
                {
                    one.MoTa = reader.GetString(6);
                }
                listOfDay.Add(one);
            }
            reader.Close();
            sqlSelect.Dispose();

            UploadThongBao(ref sqlCon);
            sqlCon.Close();
        }

        public void UploadThongBao(ref SqlConnection sqlCon)
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(HangSo.strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sql = new SqlCommand("select * from dbo.THONGBAO where IDSK = @id", sqlCon);
            sql.Parameters.Add("@id", SqlDbType.Int);
            int count = ListOfDay.Count;
            for (int i = 0; i < count; i++)
            {
                sql.Parameters["@id"].Value = ListOfDay[i].ID;
                var _reader = sql.ExecuteReader();
                while (_reader.Read())
                {
                    ItemThongBao item = new ItemThongBao();
                    item.GiaTri = _reader.GetInt32(2);
                    item.DonVi = _reader.GetString(3).Trim();
                    ListOfDay[i].ListTB.Add(item);
                }
                listOfDay[i].ListTB.Sort();
                _reader.Close();
            }
            sql.Dispose();
        }

        private void GetNotify()
        {
            HangSo.SqlSetDateFormat();
            SqlConnection sqlCon = new SqlConnection(HangSo.strCon);
            sqlCon.Open();
            SqlCommand sqlSet = new SqlCommand("select IDSK, THOIGIAN from dbo.THONGBAO where USERNAME = @user AND THOIGIAN >= @thoigianbd AND THOIGIAN <= @thoigiankt", sqlCon);
            sqlSet.Parameters.Add("@user", SqlDbType.VarChar);
            sqlSet.Parameters["@user"].Value = CaiDat.GetPreUsername();
            sqlSet.Parameters.Add("@thoigianbd", SqlDbType.DateTime);
            sqlSet.Parameters["@thoigianbd"].Value = new DateTime(day.Year, day.Month, day.Day, 0, 0, 0);
            sqlSet.Parameters.Add("@thoigiankt", SqlDbType.DateTime);
            sqlSet.Parameters["@thoigiankt"].Value = new DateTime(day.Year, day.Month, day.Day, 23, 59, 59);

            var reader = sqlSet.ExecuteReader();
            int id = -1;
            while (reader.Read())
            {
                DateTime date = reader.GetDateTime(1);
                ItemThongBao itemTB = new ItemThongBao() { ThoiGian = date };
                if (id != reader.GetInt32(0))
                {
                    id = reader.GetInt32(0);
                    OneEvent one = new OneEvent() { ID = id };
                    one.ListTB.Add(itemTB);
                    listOfDay.Add(one);
                }
                else
                {
                    int count = listOfDay.Count;
                    listOfDay[count - 1].ListTB.Add(itemTB);
                }
            }
            reader.Close();
            sqlSet.Dispose();

            int countList = ListOfDay.Count;
            SqlCommand sqlSK = new SqlCommand("select * from dbo.SUKIEN where IDSK=@id", sqlCon);
            sqlSK.Parameters.Add("@id", SqlDbType.Int);
            for (int i = 0; i < countList; i++)
            {
                OneEvent one = listOfDay[i];
                sqlSK.Parameters["@id"].Value = one.ID;
                var reader1 = sqlSK.ExecuteReader();
                while (reader1.Read())
                {
                    one.TieuDe = reader1.GetString(2);
                    one.Ngay = reader1.GetDateTime(3);
                    if (reader1.GetValue(4) != DBNull.Value)
                    {
                        one.ToiNgay = reader1.GetDateTime(4);
                    }
                    if (reader1.GetValue(5) != DBNull.Value)
                    {
                        one.MonHoc = reader1.GetString(5);
                    }
                    if (reader1.GetValue(6) != DBNull.Value)
                    {
                        one.MoTa = reader1.GetString(6);
                    }

                }
                reader1.Close();
            }
            sqlSK.Dispose();
        }
    }
}