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

        public MonHoc(string idSub, string idClass, string nameSub)
        {
            maMonHoc = idSub;
            maLopHoc = idClass;
            tenMonHoc = nameSub;
        }

        public MonHoc(MonHoc tempMonhoc)
        {
            this.maMonHoc = tempMonhoc.maMonHoc;
            this.maLopHoc = tempMonhoc.maLopHoc;
            this.tenMonHoc = tempMonhoc.tenMonHoc;
        }
    }
}
