﻿using System;
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
            this.MaDichVu = dichVu.MaDichVu;
            this.TenDichVu = dichVu.TenDichVu;
            this.MaLoaiDichVu = dichVu.MaLoaiDichVu;
            this.GiaDichVu = dichVu.GiaDichVu;
            this.GiaDichVuString = ((Decimal)dichVu.GiaDichVu).ToString("0,0") + " VND";
            this.GhiChu = dichVu.GhiChu;
            this.NguonAnh = dichVu.NguonAnh;
            this.MaTinhTrang = dichVu.MaTinhTrang;

            AppearanceManager.Current.PropertyChanged += OnAppearanceManagerPropertyChanged;
        }

        public string MaDichVu { get; set; }
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
        public List<ServiceViewModel> GetListService()
        {
            List<ServiceViewModel> list = new List<ServiceViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var dichVu in db.DICH_VU)
                {
                    list.Add(new ServiceViewModel(dichVu));
                }
            }

            return list;
        }

        public List<ServiceViewModel> GetListFoods()
        {
            List<ServiceViewModel> listFoods = new List<ServiceViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var dichVu in db.DICH_VU)
                {
                    if (dichVu.MaLoaiDichVu == "LDV01")
                        listFoods.Add(new ServiceViewModel(dichVu));
                }
            }

            return listFoods;
        }

        public List<ServiceViewModel> GetListGames()
        {
            List<ServiceViewModel> listGames = new List<ServiceViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var dichVu in db.DICH_VU)
                {
                    if (dichVu.MaLoaiDichVu == "LDV03")
                        listGames.Add(new ServiceViewModel(dichVu));
                }
            }

            return listGames;
        }

        public List<ServiceViewModel> GetListRests()
        {
            List<ServiceViewModel> listRests = new List<ServiceViewModel>();

            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var dichVu in db.DICH_VU)
                {
                    if (dichVu.MaLoaiDichVu == "LDV02")
                        listRests.Add(new ServiceViewModel(dichVu));
                }
            }

            return listRests;
        }

        public void AddNewService(string id, string name, string idKind, string charges, string information, string imageSource)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.DICH_VU.Add(new DICH_VU() { MaDichVu = id, TenDichVu = name, MaLoaiDichVu = idKind, GiaDichVu = Convert.ToDecimal(charges), GhiChu = information, NguonAnh = imageSource, MaTinhTrang = 4 });

                db.SaveChanges();
            }
        }

        public ServiceViewModel GetServiceWithId(string idService)
        {
            var service = GetListService().Where(p => p.MaDichVu == idService).FirstOrDefault();

            return service;
        }
    }
}
