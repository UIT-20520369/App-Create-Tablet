using ManageSchedule.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSchedule.UserControls
{
    public partial class MotThongBao : UserControl
    {
        OneEvent ev;
        public MotThongBao(OneEvent e)
        {
            InitializeComponent();
            ev = e;
            labelTitle.Text = "Tiêu đề: " + e.TieuDe;
            if (e.MonHoc != string.Empty && e.MonHoc != null) 
                labelSubj.Text = "Môn học: " + e.MonHoc;
            else
                labelSubj.Text = "Môn học: Không";
            if (e.ToiNgay == new DateTime())
                labelTime.Text = "Thời gian: " + e.Ngay.ToString("dd/MM/yyyy HH:mm");
            else
                labelTime.Text = "Thời gian: " + e.Ngay.ToString("dd/MM/yyyy HH:mm") + " - "
                    + e.ToiNgay.ToString("dd/MM/yyyy HH:mm");
        }

        private void Form_Click(object sender, EventArgs e)
        {
            FormShowSuKien show = new FormShowSuKien(ev, true);
            show.ShowDialog();
        }


    }
}
