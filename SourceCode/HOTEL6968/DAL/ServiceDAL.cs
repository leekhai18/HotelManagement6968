using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFloor.ModernUI.Presentation;
using System.ComponentModel;
using System.Windows.Media;

namespace HOTEL6968.DAL
{
    public class ServiceViewModel : NotifyPropertyChanged
    {
        public ServiceViewModel()
        {
        }

        public ServiceViewModel(DICH_VU dichVu)
        {
            this.TenDichVu = dichVu.TenDichVu;
            this.MaLoaiDichVu = dichVu.MaLoaiDichVu;
            this.GiaDichVu = dichVu.GiaDichVu;
            this.GiaDichVuString = ((Decimal)dichVu.GiaDichVu).ToString("0,0") + " VND";
            this.GhiChu = dichVu.GhiChu;
            this.NguonAnh = dichVu.NguonAnh;
            this.MaTinhTrang = dichVu.MaTinhTrang;

            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
        }

        public string TenDichVu { get; set; }
        public string MaLoaiDichVu { get; set; }
        public decimal GiaDichVu { get; set; }
        public string GiaDichVuString { get; set; }
        public string GhiChu { get; set; }
        public string NguonAnh { get; set; }
        public Nullable<short> MaTinhTrang { get; set; }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                OnPropertyChanged("CurrentWindowColor");
            }
        }

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

    public class ServiceDAL
    {
        public List<ServiceViewModel> GetListDichVu()
        {
            List<ServiceViewModel> listDichVu = new List<ServiceViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var dichVu in db.DICH_VU)
                {
                    listDichVu.Add(new ServiceViewModel(dichVu));
                }
            }

            return listDichVu;
        }
    }
}
