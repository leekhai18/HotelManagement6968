using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;
using System.Globalization;

namespace HOTEL6968.DAL
{
    public class StaffViewModel : NotifyPropertyChanged
    {
        public StaffViewModel() { }

        public StaffViewModel(NHAN_VIEN nv)
        {
            this.MaNhanVien = nv.MaNhanVien;
            this.TenNhanVien = nv.TenNhanVien;
            this.GioiTinh = "Giới tính:      " + nv.GioiTinh;
            this.NgaySinh = nv.NgaySinh;
            this.NgaySinhString = "Ngày sinh:   " + ((DateTime)nv.NgaySinh).ToString("dd/MM/yyy");
            this.CMND = "CMND:        " + nv.CMND;
            this.DiaChi = "Địa chỉ:        " + nv.DiaChi;
            this.SDT = "SDT:            " + nv.SDT;
            this.MaChucVu = nv.MaChucVu;
            this.Email = "Email:          " + nv.Email;
            this.Luong = nv.Luong;
            this.NguonAnh = nv.NguonAnh;
            this.TenChucVu = "Chức vụ:      " + nv.CHUC_VU.TenChucVu;

            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
        }

        private void OnAppearanceManagerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ThemeSource" || e.PropertyName == "AccentColor")
            {
                OnPropertyChanged("CurrentWindowColor");
            }
        }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string NgaySinhString { get; set; }
        public string CMND { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string MaChucVu { get; set; }
        public string Email { get; set; }
        public Nullable<decimal> Luong { get; set; }
        public string NguonAnh { get; set; }
        public string TenChucVu { get; set; }

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

    public class StaffDAL
    {
        public List<StaffViewModel> GetListStaffs()
        {
            List<StaffViewModel> listStaffs = new List<StaffViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var nv in db.NHAN_VIEN)
                {
                    listStaffs.Add(new StaffViewModel(nv));
                }
            }

            return listStaffs;
        }

        public void AddNewStaff(string id, string name, string identityCard, string address, string email, string gender, string idPos, DateTime birthday, string phoneNumber, string imageSource)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.NHAN_VIEN.Add(new NHAN_VIEN()
                {
                    MaNhanVien = id,
                    TenNhanVien = name,
                    CMND = identityCard,
                    DiaChi = address,
                    Email = email,
                    GioiTinh = gender,
                    MaChucVu = idPos,
                    NgaySinh = birthday,
                    SDT = phoneNumber,
                    NguonAnh = imageSource
                });

                db.SaveChanges();
            }
        }
    }
}
