using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataAccessLayer
{
    public class Room
    {
        HotelEntities db = new HotelEntities();
        private Room() { }

        private static Room instance;
        public static Room Instance
        {
            get
            {
                if (instance == null)
                    instance = new Room();
                return instance;
            }
        }


        public void View(ListView lv_Room)
        {
            var query = from room in db.PHONGs
                        select new { ID = room.MaPhong, Kind = room.LOAI_PHONG.TenLoaiPhong, Price=room.LOAI_PHONG.GiaPhong, Status = room.TinhTrang, Image=room.LOAI_PHONG.NguonAnh };
            lv_Room.ItemsSource = query.ToList();
        }
        public void Book(string ID)
        {
            db.PHONGs.Find(ID).TinhTrang = "Đã Thuê";
            
            db.SaveChanges();
        }
        public void Edit()
        {

        }
    }
}
