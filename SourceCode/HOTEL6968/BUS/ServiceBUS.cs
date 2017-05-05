using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace HOTEL6968.BUS
{
    public class ServiceBUS : NotifyPropertyChanged
    {
        ServiceDAL serviceDAL = new ServiceDAL();
        public string maLoaiDichVu = "LDV01";

        public List<ServiceViewModel> ListDichVu
        {
            get
            {
                return serviceDAL.GetListDichVu();
            }
        }

    }
}
