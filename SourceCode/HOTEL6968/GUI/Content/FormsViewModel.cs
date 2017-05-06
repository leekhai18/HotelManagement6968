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

                return null;
            }
        }
    }
}