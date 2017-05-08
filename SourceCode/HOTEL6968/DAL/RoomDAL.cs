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
            this.MaTinhTrang = phong.MaTinhTrang;
            this.GhiChu = phong.GhiChu;
            this.GiaPhongString = ((Decimal)phong.LOAI_PHONG.GiaPhong).ToString("0,0") + " VND";
            this.GiaPhong = phong.LOAI_PHONG.GiaPhong;

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
        public Nullable<short> MaTinhTrang { get; set; }
        public string GhiChu { get; set; }
        public string GiaPhongString { get; set; }
        public Nullable<Decimal> GiaPhong { get; set; }

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
    }
}
