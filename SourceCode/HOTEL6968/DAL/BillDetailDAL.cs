using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.DAL
{
    public class BillDetailViewModel
    {
        public BillDetailViewModel() { }
        public BillDetailViewModel(CTHD cthd)
        {
            this.SoHoaDon = cthd.SoHoaDon;
            this.MaDichVu = cthd.MaDichVu;
            this.SoLuong = cthd.SoLuong;
            this.TenDichVu = cthd.DICH_VU.TenDichVu;
            this.DonGia = cthd.DICH_VU.GiaDichVu;
            this.DonGiaString = DonGia.ToString("0,0");
        }

        public string SoHoaDon { get; set; }
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public decimal DonGia { get; set; }
        public string DonGiaString { get; set; }
        public Nullable<int> SoLuong { get; set; }
    }

    public class BillDetailDAL
    {
        public List<BillDetailViewModel> GetAllBillDetail()
        {
            List<BillDetailViewModel> list = new List<BillDetailViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                var allBillDetail = db.CTHDs.ToList();

                for (int i = 0; i < allBillDetail.Count; i++)
                {
                    list.Add(new BillDetailViewModel(allBillDetail[i]));
                }
            }

            return list;
        }

        public List<BillDetailViewModel> GetBillDetail(string idBill)
        {
            return GetAllBillDetail().Where(p => p.SoHoaDon == idBill).ToList();
        }

        public decimal TotalPriceOfBill(string idBill)
        {
            var billDetail = GetBillDetail(idBill);
            decimal totalPrice = 0;

            foreach (var detail in billDetail)
            {
                totalPrice += detail.DonGia * (int)detail.SoLuong;
            }

            return totalPrice;
        }

        public void AddDetail(string idBill, string idService, int quantity)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.CTHDs.Add(new CTHD() { SoHoaDon = idBill, MaDichVu = idService, SoLuong = quantity });
                db.SaveChanges();
            }
        }
    }
}
