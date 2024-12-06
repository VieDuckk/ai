using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1lan2
{
    internal class KhachHangVip: KhachHang
    {
        public KhachHangVip() { }

        public KhachHangVip(string makhachhang, DateTime ngaysinh,bool gioitinh, int soluongmua, float dongia): base(makhachhang, ngaysinh, soluongmua, dongia)
        {

        }
        public double giamgia()
        {
            if (tongtien() <= 1000)
            {
                return base.tongtien() * 0.1;
            }
            else
            {
                return base.tongtien() * 0.2;
            }
        }


        public override string ToString()
        {
            string gt = gioitinh ? "Nam" : "Nữ";
            return string.Format("{0, -15}{1, -15:dd-MM-yyyy}{2, -15}{3, -15}{4, -15}{5, -15}{6, -15}",
                makhachhang, ngaysinh,gt, soluongmua, dongia, tongtien(), giamgia());
        }

    }
}
