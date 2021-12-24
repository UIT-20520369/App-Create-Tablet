using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchedule.Classes
{
    public class OneEvent : IComparable<OneEvent>
    {
        public int CompareTo(OneEvent obj)
        {
            return this.ngay.CompareTo(obj.Ngay);
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string tieuDe;
        public string TieuDe
        {
            get { return tieuDe; }
            set { tieuDe = value; }
        }

        private DateTime ngay;
        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        private string monHoc;
        public string MonHoc
        {
            get { return monHoc; }
            set { monHoc = value; }
        }

        private string moTa;
        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        private DateTime toiNgay;
        public DateTime ToiNgay
        {
            get { return toiNgay; }
            set { toiNgay = value; }
        }

        private List<ItemThongBao> listTB;
        public List<ItemThongBao> ListTB
        {
            get { return listTB; }
            set { listTB = value; }
        }

        public OneEvent()
        {
            listTB = new List<ItemThongBao>();
            id = -1;
        }

        public void Delete()
        {
            if (id == -1)
            {
                return;
            }

            SqlConnection sqlCon = new SqlConnection(HangSo.strCon);
            sqlCon.Open();

            SqlCommand sqlDel = new SqlCommand("delete from dbo.THONGBAO where IDSK = @id", sqlCon);
            sqlDel.Parameters.Add("@id", SqlDbType.Int);
            sqlDel.Parameters["@id"].Value = ID;
            sqlDel.ExecuteNonQuery();

            sqlDel.CommandText = "delete from dbo.SUKIEN  where IDSK = @id";
            sqlDel.ExecuteNonQuery();
            sqlDel.Dispose();
            sqlCon.Close();
        }
    }
}
