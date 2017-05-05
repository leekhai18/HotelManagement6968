using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataAccessLayer
{
    public class Service
    {
        HotelEntities db = new HotelEntities();
        public Service() { }

        public static Service instance;
        public static Service Instance
        {
            get
            {
                if (instance == null)
                    instance = new Service();
                return instance;
            }
        }


        public void View(ListView lv_Service)
        {
            var query = from service in db.DICH_VU
                        select new { Name=service.TenDichVu,Price=service.GiaDichVu,Status=service.TinhTrang,Image=service.NguonAnh };
            lv_Service.ItemsSource = query.ToList();
        }
        public void Edit()
        {

        }
    }
}
