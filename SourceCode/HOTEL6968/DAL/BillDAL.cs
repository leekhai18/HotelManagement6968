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
            this.TenKhachHang = hd.KHACH_HANG.TenKhachHang;
            this.CMND = hd.KHACH_HANG.CMND;
            this.MaNhanVienXuatHD = hd.MaNhanVienXuatHD;
            this.MaPhong = hd.MaPhong;
            this.TenPhong = hd.PHONG.TenPhong;
            this.ThoiGianDat = hd.ThoiGianDat;
            this.ThoiGianDatString = ThoiGianDat.ToString("dd/MM/yyyy");
            this.ThoiGianTra = hd.ThoiGianTra;
            this.ThoiGianTraString = (ThoiGianTra == null) ? "" : ((DateTime)ThoiGianTra).ToString("dd/MM/yyyy");
            this.TongGiaDichVu = hd.TongGiaDichVu;
            this.TongGiaDichVuString = (this.TongGiaDichVu != null) ? ((Decimal)hd.TongGiaDichVu).ToString("0,0") : "0";
            this.TongGiaPhong = hd.TongGiaPhong;
            this.TongGiaPhongString = (this.TongGiaPhong != null) ? ((Decimal)hd.TongGiaPhong).ToString("0,0") : "0";
            this.TongTien = hd.TongTien;
            this.TongTienString = (this.TongTien != null) ? ((Decimal)hd.TongTien).ToString("0,0") : "0";
            this.GiaPhong1Ngay = hd.GiaPhong1Ngay;
            this.GiaPhong1NgayString = (this.GiaPhong1Ngay != null) ? ((Decimal)hd.GiaPhong1Ngay).ToString("0,0") : "0";
        }

        public string SoHoaDon { get; set; }
        public string MaNhanVienXuatHD { get; set; }
        public string MaKhachHang { get; set; }
        public string CMND { get; set; }
        public string TenKhachHang { get; set; }
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public System.DateTime ThoiGianDat { get; set; }
        public string ThoiGianDatString { get; set; }
        public Nullable<System.DateTime> ThoiGianTra { get; set; }
        public string ThoiGianTraString { get; set; }
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
        public void InitBill(string idCustomer, string idRoom, Decimal rateRoomPerDay, DateTime bookingDay)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                string idBill = (db.HOA_DON.Count() + 1).ToString();

                db.HOA_DON.Add(new HOA_DON() { SoHoaDon = idBill, MaKhachHang = idCustomer, MaPhong = idRoom, GiaPhong1Ngay = rateRoomPerDay, ThoiGianDat = bookingDay });

                db.SaveChanges();
            }
        }

        public List<BillViewModel> GetListBill()
        {
            List<BillViewModel> list = new List<BillViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var hd in db.HOA_DON)
                {
                    list.Add(new BillViewModel(hd));
                }
            }

            return list;
        }

        public BillViewModel GetBill(string idRoom)
        {
            var bill = GetListBill().Where(p => p.MaPhong == idRoom).OrderByDescending(p => p.SoHoaDon).FirstOrDefault();

            return bill;
        }

        public string GetIdBill(string idRoom)
        {   
            return (idRoom == null) ? "" : GetBill(idRoom).SoHoaDon;
        }

        public void CompleteBill(string idRoom, DateTime payingDate, decimal roomRate, decimal serviceRate, decimal totalRates)
        {
            string soHD = GetIdBill(idRoom);

            using (var db = new QuanLyKhachSanEntities())
            {
                var bill = db.HOA_DON.Where(p => p.SoHoaDon == soHD).FirstOrDefault();

                bill.ThoiGianTra = payingDate;
                bill.TongGiaDichVu = serviceRate;
                bill.TongTien = totalRates;
                bill.TongGiaPhong = roomRate;

                db.SaveChanges();
            }
        }
    }
}
