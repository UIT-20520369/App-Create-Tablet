using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchedule.Classes
{
    public class ItemThongBao : IEquatable<ItemThongBao>
    {
        public bool Equals(ItemThongBao other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return GiaTri.Equals(other.GiaTri) && DonVi.Equals(other.DonVi);
        }

        public override int GetHashCode()
        {
            int hashitemTBGiaTri = GiaTri == null ? 0 : GiaTri.GetHashCode();

            int hashitemTBDonVi = DonVi.GetHashCode();

            return hashitemTBGiaTri ^ hashitemTBDonVi;
        }
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
    }
}
