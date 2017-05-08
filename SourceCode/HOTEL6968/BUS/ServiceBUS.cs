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

        public List<ServiceViewModel> ListFoods
        {
            get
            {
                return serviceDAL.GetListFoods();
            }
        }

        public List<ServiceViewModel> ListGames
        {
            get
            {
                return serviceDAL.GetListGames();
            }
        }

        public List<ServiceViewModel> ListRests
        {
            get
            {
                return serviceDAL.GetListRests();
            }
        }

        public bool SearchFilter(object obj, string textChange)
        {
            if (String.IsNullOrEmpty(textChange))
                return true;
            else
                return ((obj as ServiceViewModel).TenDichVu.IndexOf(textChange, StringComparison.OrdinalIgnoreCase) >= 0);
        }

    }
}
