using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;

namespace HOTEL6968.DAL
{
    public class RoomViewModel : NotifyPropertyChanged
    {
        public RoomViewModel(){}

        public RoomViewModel(PHONG phong)
        {
            this.NguonAnh = phong.LOAI_PHONG.NguonAnh;
            this.TenPhong = phong.TenPhong;
            this.MaPhong = phong.MaPhong;
            this.MaLoaiPhong = phong.MaLoaiPhong;
            this.TenLoaiPhong = phong.LOAI_PHONG.TenLoaiPhong;
            this.MaTinhTrang = phong.MaTinhTrang;
            this.GhiChu = phong.GhiChu;
            this.GiaPhongString = ((Decimal)phong.LOAI_PHONG.GiaPhong).ToString("0,0");
            this.GiaPhong = phong.LOAI_PHONG.GiaPhong;

            if (this.MaTinhTrang == 2)
                this.Status = "Trả phòng";
            else
                this.Status = "Đặt ngay";



            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
        }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                OnPropertyChanged("CurrentWindowColor");
            }
        }

        public string NguonAnh { get; set; }
        public string TenPhong { get; set; }
        public string MaPhong { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public Nullable<short> MaTinhTrang { get; set; }
        public string GhiChu { get; set; }
        public string GiaPhongString { get; set; }
        public Nullable<Decimal> GiaPhong { get; set; }
        public string Status { get; set; }

        public Color CurrentWindowColor
        {
            get
            {
                var color = AppearanceManager.Current.AccentColor;
                color.A = 30;
                return color;
            }
        }
    }

    public class RoomDAL
    {   
        public List<RoomViewModel> GetListRooms()
        {
            List<RoomViewModel> listRooms = new List<RoomViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var phong in db.PHONGs)
                {
                    listRooms.Add(new RoomViewModel(phong));
                }
            }

            return listRooms;
        }

        public string FindImageSource(string idKindOfRoom)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var imageSource = db.LOAI_PHONG.Find(idKindOfRoom).NguonAnh;
                return imageSource;
            }
        }

        public void AddNewRoom(string id, string name, string idKind, string information)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.PHONGs.Add(new PHONG() { MaPhong = id, TenPhong = name, MaLoaiPhong = idKind, GhiChu = information, MaTinhTrang = 1 });

                db.SaveChanges();
            }
        }

        public RoomViewModel GetRoomWithId(string idRoom)
        {
            List<RoomViewModel> listRoom = GetListRooms();

            RoomViewModel room = listRoom.Where(p => p.MaPhong == idRoom).FirstOrDefault();

            return room;
        }

        public List<string> GetListIdRoomAvailable()
        {
            List<RoomViewModel> listRoom = GetListRooms();

            List<RoomViewModel> listRoomAvailable = listRoom.Where(p => p.MaTinhTrang == 1).ToList();

            List<string> listIdRoomAvailable = new List<string>();

            for (int i = 0; i < listRoomAvailable.Count; i++)
            {
                listIdRoomAvailable.Add(listRoomAvailable[i].MaPhong);
            }

            return listIdRoomAvailable;
        }

        public List<string> GetListIdRoomHided()
        {
            List<RoomViewModel> listRoom = GetListRooms();

            List<RoomViewModel> listRoomHided = listRoom.Where(p => p.MaTinhTrang == 2).ToList();

            List<string> listIdRoomHided = new List<string>();

            for (int i = 0; i < listRoomHided.Count; i++)
            {
                listIdRoomHided.Add(listRoomHided[i].MaPhong);
            }

            return listIdRoomHided;
        }


        public void ChangeStatusRoom(string idRoom)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var room = db.PHONGs.Where(p => p.MaPhong == idRoom).FirstOrDefault();

                if (room.MaTinhTrang == 1)
                    room.MaTinhTrang = 2;
                else if (room.MaTinhTrang == 2)
                    room.MaTinhTrang = 1;

                db.SaveChanges();
            }
        }

        public void UpdateRateRoom(string idKindOfRoom, decimal rate)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var kindRoom = db.LOAI_PHONG.Where(p => p.MaLoaiPhong == idKindOfRoom).FirstOrDefault();

                kindRoom.GiaPhong = rate;

                db.SaveChanges();
            }
        }

        public void UpdateSurchage(string surchageNumber, string surchageForeign)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                var number = db.THAM_SO.Where(p => p.TenThamSo == "PhuThuSoLuongKhach").FirstOrDefault();
                number.GiaTriThamSo = surchageNumber;

                var foreign = db.THAM_SO.Where(p => p.TenThamSo == "PhuThuKhachNuocNgoai").FirstOrDefault();
                foreign.GiaTriThamSo = surchageForeign;

                db.SaveChanges();
            }
        }

        public decimal RateRoom(string idKindOfRoom)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                return (decimal)db.LOAI_PHONG.Where(p => p.MaLoaiPhong == idKindOfRoom).FirstOrDefault().GiaPhong;
            }
        }

        public string SurchageNumber()
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                return db.THAM_SO.Where(p => p.TenThamSo == "PhuThuSoLuongKhach").FirstOrDefault().GiaTriThamSo;
            }
        }

        public string SurchageForeign()
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                return db.THAM_SO.Where(p => p.TenThamSo == "PhuThuKhachNuocNgoai").FirstOrDefault().GiaTriThamSo;
            }
        }
    }
}
