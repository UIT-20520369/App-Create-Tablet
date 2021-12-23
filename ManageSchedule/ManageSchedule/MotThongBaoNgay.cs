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

namespace ManageSchedule
{
    public partial class MotThongBaoNgay : UserControl
    {
        public MotThongBaoNgay(OneEvent e)
        {
            InitializeComponent();
            labelTitle.Text = "Tiêu đề: " + e.TieuDe;
            labelSubj.Text = "Môn học: " + e.MonHoc;
            if (e.ToiNgay == new DateTime())
                labelTime.Text = "Thời gian: " + e.Ngay.ToString("dd/MM/yyyy HH:mm");
            else
                labelTime.Text = "Thời gian: " + e.Ngay.ToString("dd/MM/yyyy HH:mm") + " - " 
                    + e.ToiNgay.ToString("dd/MM/yyyy HH:mm");
        }                
    }
}
