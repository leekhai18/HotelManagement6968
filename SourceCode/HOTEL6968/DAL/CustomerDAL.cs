using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.DAL
{
    public class CustomerViewModel
    {
        public CustomerViewModel() { }

        public CustomerViewModel(KHACH_HANG kh)
        {
            this.MaKhachHang = kh.MaKhachHang;
            this.TenKhachHang = kh.TenKhachHang;
            this.CMND = kh.CMND;
            this.NgaySinh = kh.NgaySinh;
            this.NgaySinhString = ((DateTime)kh.NgaySinh).ToString("dd/MM/yyy");
            this.SDT = kh.SDT;
            this.MaLoaiKhachHang = kh.MaLoaiKhachHang;
            this.TenLoaiKhachHang = kh.LOAI_KHACH_HANG.TenLoaiKhachHang;

            if (kh.MaLoaiKhachHang == "LKH02")
                IsVip = true;
            else
                IsVip = false;
        }

        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string NgaySinhString { get; set; }
        public string MaLoaiKhachHang { get; set; }
        public string TenLoaiKhachHang { get; set; }
        public bool IsVip { get; set; }
    }

    public class CustomerDAL
    {
        public List<CustomerViewModel> GetListKhachHang()
        {
            List<CustomerViewModel> listKhachHang = new List<CustomerViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var kh in db.KHACH_HANG)
                {
                    listKhachHang.Add(new CustomerViewModel(kh));
                }
            }

            return listKhachHang;
        }

        public void AddNewCustomer(string id, string name, string identityCard, string phoneNum, DateTime birthday, string kindofCus)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.KHACH_HANG.Add(new KHACH_HANG() { MaKhachHang = id, TenKhachHang = name, CMND = identityCard, SDT = phoneNum, NgaySinh = birthday, MaLoaiKhachHang = kindofCus });

                db.SaveChanges();
            }
        }

        public CustomerViewModel GetCustomerWithIdentityCard(string identityCard)
        {
            List<CustomerViewModel> listCus = GetListKhachHang();

            var cus = listCus.Where(p => p.CMND == identityCard).FirstOrDefault();           

            return cus;
        }
    }
}
