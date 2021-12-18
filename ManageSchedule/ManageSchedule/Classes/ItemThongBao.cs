using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchedule.Classes
{
    public class ItemThongBao : IEquatable<ItemThongBao>, IComparable<ItemThongBao>
    {
        public bool Equals(ItemThongBao other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return GiaTri.Equals(other.GiaTri) && DonVi.Equals(other.DonVi);
        }

        public override int GetHashCode()
        {
            int hashitemTBGiaTri = GiaTri == 0 ? 0 : GiaTri.GetHashCode();

            int hashitemTBDonVi = DonVi.GetHashCode();

            return hashitemTBGiaTri ^ hashitemTBDonVi;
        }

        public int CompareTo(ItemThongBao obj)
        {
            int this_index = Array.IndexOf(listDonVi, this.donVi);
            int obj_index = Array.IndexOf(listDonVi, obj.DonVi);
            int compare_DonVi = this_index.CompareTo(obj_index);
            if (compare_DonVi != 0)
            {
                return compare_DonVi;
            }
            else 
            {
                return this.giaTri.CompareTo(obj.GiaTri);
            }          
        }

        public static readonly string[] listDonVi = { "phút", "tiếng", "ngày", "tuần" };

        private int giaTri;
        public int GiaTri
        {
            get { return giaTri; }
            set { giaTri = value; }
        }

        private string donVi;
        public string DonVi
        {
            get { return donVi; }
            set { donVi = value; }
        }

        public ItemThongBao()
        {
        }

        public ItemThongBao(ItemThongBao obj)
        {
            this.GiaTri = obj.GiaTri;
            this.DonVi = obj.DonVi;
        }

        public DateTime ConvertToTime(DateTime date)
        {
            // ngày, tuần thì chỉ lấy ngày, không lấy giờ phút
            DateTime temp;
            switch (DonVi)
            {
                case "phút":
                    date = date.AddMinutes(-GiaTri);
                    break;
                case "tiếng":
                    date = date.AddHours(-GiaTri);
                    break;
                case "ngày":
                    temp = date.AddDays(-GiaTri);
                    date = new DateTime(temp.Year, temp.Month, temp.Day, 0, 0, 0);
                    break;
                case "tuần":
                    temp = date.AddDays(-(GiaTri * 7));
                    date = new DateTime(temp.Year, temp.Month, temp.Day, 0, 0, 0);
                    break;
            }         
            return date;
        }
    }
}
