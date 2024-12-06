using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1lan2
{
    internal class Program
    {
        static List<KhachHang> DanhSach = new List<KhachHang>();
        static void Main(string[] args)
        {

            bool exit = false;
            do
            {
                Console.WriteLine("Menu cua CT:");
                Console.WriteLine("1.Nhap thong tin:");
                Console.WriteLine("2.Hien thi danh sach:");
                Console.WriteLine("3.Sua:");
                Console.WriteLine("4.Thoat:");
                Console.WriteLine("5.tim max:");
                Console.WriteLine("6.Sap xep:");
                Console.WriteLine("Nhap lua chon cua ban:");
                string Luachon = Console.ReadLine();
                switch (Luachon)
                {
                    case "1":
                        nhapthongtin();
                        break;
                    case "2":
                        hienthidanhsach();
                        break;
                    case "3":
                        sua();
                        break;
                    case "4":
                        exit = true;
                        break;
                    case "5":
                        timmax();
                        break;
                    case "6":
                        sapxep();
                        break;
                    default:
                        Console.WriteLine("Nhap loi, vui long nhap lai!");
                        break;
                }
            }
            while (!exit);
        }
        private static void nhapthongtin()
        {
            Console.WriteLine("1.Khach hang thuong");
            Console.WriteLine("2.Khach hang vip");
            Console.WriteLine("Nhap lua chon:");
            string LuaChon = Console.ReadLine();
            switch (LuaChon)
            {
                case "1":
                    KhachHang KH = new KhachHang();
                    Console.WriteLine("Nhap ma khach hang:");
                    KH.makhachhang = Console.ReadLine();
                    if (DanhSach.Contains(KH))
                    {
                        Console.WriteLine("Da co khach hang trong danh sach");
                        Console.WriteLine("Nhan enter de quay lai!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Nhap ngay sinh (dd-MM-yyyy):");
                        KH.ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                        Console.WriteLine("Nhap gioi tinh (true: Nam, false: Nữ):");
                        KH.gioitinh = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap so luong mua:");
                        KH.soluongmua = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap don gia:");
                        KH.dongia = float.Parse(Console.ReadLine());
                        DanhSach.Add(KH);
                    }
                    break;
                case "2":
                    KhachHangVip KHV = new KhachHangVip();
                    Console.WriteLine("Nhap ma khach hang vip:");
                    KHV.makhachhang = Console.ReadLine();
                    if (DanhSach.Contains(KHV))
                    {
                        Console.WriteLine("Da co khach hang trong danh sach");
                        Console.WriteLine("Nhan phim enter de quay lai!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Nhap ngay sinh (dd-MM-yyyy):");                      
                        KHV.ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                        Console.WriteLine("Nhap gioi tinh (true: Nam, false: Nữ):");
                        KHV.gioitinh = bool.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap so luong mua:");
                        KHV.soluongmua = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap don gia:");
                        KHV.dongia = float.Parse(Console.ReadLine());
                        DanhSach.Add(KHV);
                    }
                    break;
                default:
                    Console.WriteLine("Khong hop le!");
                    break;
            }
        }
        public static void hienthidanhsach()
        {
            Console.WriteLine("{0, -15}{1, -15}{2, -15}{3,-15}{4, -15}{5, -15}{6,-15}", "ma khach hang", "ngay sinh","gioi tinh", "so luong mua", "don gia", "tong tien", "giam gia");
            foreach (KhachHang so in DanhSach)
            {
                Console.WriteLine(so.ToString());
            }
        }
        private static void sua()
        {
            Console.WriteLine("Nhap ma khach hang muon sua:");
            string makhachhang = Console.ReadLine();
            KhachHang khcansua = DanhSach.FirstOrDefault(x => x.makhachhang == makhachhang);

            if (khcansua == null)
            {
                Console.WriteLine("Khong tim thay ma kh: " + makhachhang);
                return;
            }
            if (khcansua is KhachHang KH)
            {
                Console.WriteLine("Sua thong tin khach hang: ");
                Console.WriteLine("Nhap ma kh moi:");
                KH.makhachhang = Console.ReadLine();
                Console.WriteLine("Nhap ngay sinh moi (dd-MM-yyyy):");
                KH.ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                Console.WriteLine("Nhap so luong mua moi:");
                KH.soluongmua = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap don gia moi:");
                KH.dongia = float.Parse(Console.ReadLine());
            }
            if (khcansua is KhachHangVip KHV)
            {
                Console.WriteLine("Sua thong tin khach hang: ");
                Console.WriteLine("Nhap ma kh moi:");
                KHV.makhachhang = Console.ReadLine();
                Console.WriteLine("Nhap ngay sinh moi (dd-MM-yyyy):");
                KHV.ngaysinh = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                Console.WriteLine("Nhap so luong mua moi:");
                KHV.soluongmua = int.Parse(Console.ReadLine());
                Console.WriteLine("Nhap don gia moi:");
                KHV.dongia = float.Parse(Console.ReadLine());
            }
            Console.WriteLine("Cap nhat thong tin thanh cong!");
        }
        private static void sapxep()
        {
            // Sắp xếp danh sách theo mã khách hàng tăng dần, sau đó theo đơn giá giảm dần, và cuối cùng theo số lượng mua giảm dần
            DanhSach = DanhSach
                .OrderBy(x => x.makhachhang) // Sắp xếp theo mã khách hàng tăng dần
                .ThenByDescending(x => x.dongia) // Sau đó theo đơn giá giảm dần
                .ThenByDescending(x => x.soluongmua) // Sau đó theo số lượng mua giảm dần
                .ToList();

            Console.WriteLine("Danh sách đã được sắp xếp thành công!");
            hienthidanhsach();
        }

        private static void timmax()
        {
            if (DanhSach.Count == 0)
            {
                Console.WriteLine("Danh sách khách hàng trống.");
                return;
            }

            // Tìm số lượng mua lớn nhất
            int maxSoLuong = DanhSach.Max(kh => kh.soluongmua);

            // Lọc tất cả khách hàng có số lượng mua bằng số lượng lớn nhất
            var khachHangMax = DanhSach.Where(kh => kh.soluongmua == maxSoLuong).ToList();

            Console.WriteLine("Danh sách các khách hàng có số lượng mua cao nhất:");
            Console.WriteLine("{0, -15}{1, -15}{2, -15}{3, -15}{4, -15}{5, -10}",
                "Mã KH", "Ngày sinh", "Số lượng", "Đơn giá", "Tổng tiền", "Giới tính");

            foreach (var kh in khachHangMax)
            {
                if (kh is KhachHangVip khVip) // Kiểm tra nếu là khách hàng VIP
                {
                    Console.WriteLine("{0, -15}{1, -15:dd-MM-yyyy}{2, -15}{3, -15}{4, -15}{5, -10}",
                        khVip.makhachhang,
                        khVip.ngaysinh,
                        khVip.soluongmua,
                        khVip.dongia,
                        khVip.tongtien(),
                        khVip.gioitinh ? "Nam" : "Nữ");
                }
                else // Khách hàng thường
                {
                    Console.WriteLine("{0, -15}{1, -15:dd-MM-yyyy}{2, -15}{3, -15}{4, -15}{5, -10}",
                        kh.makhachhang,
                        kh.ngaysinh,
                        kh.soluongmua,
                        kh.dongia,
                        kh.tongtien(),
                        kh.gioitinh ? "Nam" : "Nữ");
                }
            }
        }


    }
}
