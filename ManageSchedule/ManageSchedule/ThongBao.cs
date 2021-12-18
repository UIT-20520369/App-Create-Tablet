using ManageSchedule.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule
{
    public partial class ThongBao : UserControl
    {
        private ItemThongBao itemTB;
        public ItemThongBao ItemTB
        {
            get { return itemTB; }
            set { itemTB = value; }
        }
        private event EventHandler delete;
        public event EventHandler Delete
        {
            add { delete += value; }
            remove { delete -= value; }
        }

        public ThongBao()
        {
            InitializeComponent();
            itemTB = new ItemThongBao()
            { GiaTri = Convert.ToInt32(numValue.Value), DonVi = cbUnit.Text };
        }

        public ThongBao(ItemThongBao item)
        {
            InitializeComponent();
            ItemTB = item;
            numValue.Value = ItemTB.GiaTri;
            cbUnit.Text = ItemTB.DonVi;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Dispose();
            if (delete != null)
                delete(this, new EventArgs());
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemTB.DonVi = cbUnit.SelectedItem.ToString();
        }

        private void numValue_ValueChanged(object sender, EventArgs e)
        {
            itemTB.GiaTri = Convert.ToInt32(numValue.Value);
        }
    }
}
