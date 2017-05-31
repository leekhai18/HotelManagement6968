using FirstFloor.ModernUI.Presentation;
using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Content
{
    class FormsViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private string fullName;
        private string identityCard;
        private string idCustomer;
        private string charges;
        private string comboboxText;
        private string idService;
        private string idStaff;

        public string IdCustomer
        {
            get
            {
                using (var db = new QuanLyKhachSanEntities())
                {
                    int idNumCus = db.KHACH_HANG.Count() + 1;

                    this.idCustomer = "KH" + idNumCus.ToString().PadLeft(4, '0');

                    return this.idCustomer;
                }
            }
            set
            {

            }
        }

        public string IdStaff
        {
            get
            {
                using (var db = new QuanLyKhachSanEntities())
                {
                    int id = db.NHAN_VIEN.Count() + 1;

                    this.idStaff = "NV" + id.ToString().PadLeft(3, '0');

                    return this.idStaff;
                }
            }
            set
            {

            }
        }

        public string IdService
        {
            get
            {
                using (var db = new QuanLyKhachSanEntities())
                {
                    int idNumSer = db.DICH_VU.Count() + 1;

                    this.idService = "DV" + idNumSer.ToString().PadLeft(3, '0');

                    return this.idService;
                }
            }
            set
            {

            }
        }

        public string FullName
        {
            get { return this.fullName; }
            set
            {
                if (this.fullName != value)
                {
                    this.fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string IdentityCard
        {
            get { return this.identityCard; }
            set
            {
                if (this.identityCard != value)
                {
                    this.identityCard = value;
                    OnPropertyChanged("IdentityCard");
                }
            }
        }

        public string Charges
        {
            get { return this.charges; }
            set
            {
                if (this.charges != value)
                {
                    this.charges = value;
                    OnPropertyChanged("Charges");
                }
            }
        }

        public string ComboboxText
        {
            get { return this.comboboxText; }
            set
            {
                if (this.comboboxText != value)
                {
                    this.comboboxText = value;
                    OnPropertyChanged("ComboboxText");
                }
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FullName")
                {
                    return string.IsNullOrEmpty(this.fullName) ? "Required value" : null;
                }
                if (columnName == "IdentityCard")
                {
                    return string.IsNullOrEmpty(this.identityCard) ? "Required value" : null;
                }
                if (columnName == "Charges")
                {
                    return string.IsNullOrEmpty(this.charges) ? "Required value" : null;
                }
                if (columnName == "ComboboxText")
                {
                    return string.IsNullOrEmpty(this.comboboxText) ? "Required value" : null;
                }

                return null;
            }
        }
    }
}