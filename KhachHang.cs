using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1lan2
{
    internal class KhachHang
    {
        private string _makhachhang;
        private DateTime _ngaysinh;
        private bool _gioitinh;
        private int _soluongmua;
        private float _dongia;

        public string makhachhang {  get { return _makhachhang; } set { _makhachhang = value; } }
        public DateTime ngaysinh { get { return _ngaysinh;} set { _ngaysinh = value; } }
        public bool gioitinh { get { return _gioitinh; } set { _gioitinh = value; } }
        public int soluongmua { get {  return _soluongmua; } set { _soluongmua = value;} }
        public float dongia {  get { return _dongia; } set { _dongia = value; } }

        public KhachHang() { }
        public KhachHang(string makhachhang, DateTime ngaysinh, int soluongmua, float dongia)
        {
            this.makhachhang = makhachhang;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.soluongmua = soluongmua;
            this.dongia = dongia;
        }   
        public double tongtien()
        {
            return soluongmua * dongia;
        }
        public override bool Equals(object obj)
        {
            KhachHang KH = obj as KhachHang;
            return (this.makhachhang.Equals(KH.makhachhang));
        }
        public virtual string ToString()
        {
            string gt = gioitinh ? "Nam" : "Nữ";
            return string.Format("{0, -15}{1, -15:dd-MM-yyyy}{2, -15}{3,-15}{4, -15}{5,-15}", makhachhang, ngaysinh,gt, soluongmua, dongia, tongtien());
        }
    }
}
