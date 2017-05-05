using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataAccessLayer
{
    public class Customer
    {
        HotelEntities db = new HotelEntities();
        private Customer() { }

        private static Customer instance;
        public static Customer Instance
        {
            get
            {
                if (instance == null)
                    instance = new Customer();
                return instance;
            }
        }


        public void View(ListView lv_Cus)
        {
            var query = from cus in db.KHACH_HANG
                        select new { IDCus = cus.MaKhachHang, Name = cus.TenKhachHang, ID = cus.CMND, DateOfBirth=cus.NgaySinh, Phone=cus.SDT };
            lv_Cus.ItemsSource = query.ToList();
        }
        public void Edit()
        {

        }
        public void Add(List<string> list)
        {

        }

    }
}
