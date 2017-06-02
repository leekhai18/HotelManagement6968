using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.DAL
{
    public class BillViewModel
    {
        public BillViewModel() { }
        public BillViewModel(HOA_DON hd)
        {
            this.SoHoaDon = hd.SoHoaDon;
            this.MaKhachHang = hd.MaKhachHang;
            this.MaNhanVienXuatHD = hd.MaNhanVienXuatHD;
            this.MaPhong = hd.MaPhong;
            this.ThoiGianDat = hd.ThoiGianDat;
            this.ThoiGianTra = hd.ThoiGianTra;
            this.TongGiaDichVu = hd.TongGiaDichVu;
            this.TongGiaDichVuString = ((Decimal)hd.TongGiaDichVu).ToString("0,0");
            this.TongGiaPhong = hd.TongGiaPhong;
            this.TongGiaPhongString = ((Decimal)hd.TongGiaPhong).ToString("0,0");
            this.TongTien = hd.TongTien;
            this.TongTienString = ((Decimal)hd.TongTien).ToString("0,0");
            this.GiaPhong1Ngay = hd.GiaPhong1Ngay;
            this.GiaPhong1NgayString = ((Decimal)hd.GiaPhong1Ngay).ToString("0,0");
        }

        public string SoHoaDon { get; set; }
        public string MaNhanVienXuatHD { get; set; }
        public string MaKhachHang { get; set; }
        public string MaPhong { get; set; }
        public System.DateTime ThoiGianDat { get; set; }
        public Nullable<System.DateTime> ThoiGianTra { get; set; }
        public Nullable<decimal> TongGiaPhong { get; set; }
        public Nullable<decimal> TongGiaDichVu { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public Nullable<decimal> GiaPhong1Ngay { get; set; }
        public string TongGiaPhongString { get; set; }
        public string TongGiaDichVuString { get; set; }
        public string TongTienString { get; set; }
        public string GiaPhong1NgayString { get; set; }
    }

    public class BillDAL
    {
        public void InitBill(string idCustomer , string idRoom, Decimal rateRoomPerDay, DateTime bookingDay)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                string idBill = (db.HOA_DON.Count() + 1).ToString();

                db.HOA_DON.Add(new HOA_DON() { SoHoaDon = idBill, MaKhachHang = idCustomer, MaPhong = idRoom, GiaPhong1Ngay = rateRoomPerDay, ThoiGianDat = bookingDay });

                db.SaveChanges();
            }
        }

        
    }
}
