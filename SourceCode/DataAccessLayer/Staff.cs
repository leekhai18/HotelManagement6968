using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataAccessLayer
{
    public class Staff
    {
        private Staff() { }

        private static Staff instance;
        public static Staff Instance
        {
            get
            {
                if (instance == null)
                    instance = new Staff();
                return instance;
            }
        }


        public void View(ListView lv_Staff)
        {
            HotelEntities db = new HotelEntities();
            var query = from sta in db.NHAN_VIEN
                        select new { IDSta = sta.MaNhanVien, Name = sta.TenNhanVien, Position = sta.CHUC_VU.TenChucVu, Salary = sta.Luong, Image = sta.NguonAnh };
            lv_Staff.ItemsSource = query.ToList();
        }
        public void Edit()
        {

        }
    }
}
