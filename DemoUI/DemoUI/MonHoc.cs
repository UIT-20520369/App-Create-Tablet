using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUI
{
    class MonHoc
    {
        public string maMonHoc { get; set; }
        public string maLopHoc { get; set; }
        public string tenMonHoc { get; set; }
        public int soTinChi { get; set; }
        public int thu { get; set; }
        public string tiet { get; set; }
        public string heDaoTao { get; set; }

        public MonHoc(string maMon, string maLop, string ten, int tinchi, int dayOfWeek, string lesson, string hDT)
        {
            maMonHoc = maMon;
            maLopHoc = maLop;
            tenMonHoc = ten;
            soTinChi = tinchi;
            thu = dayOfWeek;
            tiet = lesson;
            heDaoTao = hDT;
        }

        public MonHoc(MonHoc tempMonhoc)
        {
            this.maMonHoc = tempMonhoc.maMonHoc;
            this.maLopHoc = tempMonhoc.maLopHoc;
            this.tenMonHoc = tempMonhoc.tenMonHoc;
            this.soTinChi = tempMonhoc.soTinChi;
            this.thu = tempMonhoc.thu;
            this.tiet = tempMonhoc.tiet;
            this.heDaoTao = tempMonhoc.heDaoTao;
        }
    }
}
