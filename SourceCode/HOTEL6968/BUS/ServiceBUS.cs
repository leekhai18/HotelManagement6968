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
using System.Diagnostics;
using System.IO;
using HOTEL6968.GUI.Pages;

namespace HOTEL6968.BUS
{
    public class ServiceBUS : NotifyPropertyChanged
    {
        ServiceDAL serviceDAL = new ServiceDAL();

#region ServiceManager
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
        #endregion

        #region ServiceAdd
        public void AddNewService(string id, string name, string idKind, string charges, string information, string imageSource)
        {
            serviceDAL.AddNewService(id, name, idKind, charges, information, imageSource);
        }
        #endregion

#region Booking Services

        public ServiceViewModel GetServiceWithId(string idService)
        {
            return serviceDAL.GetServiceWithId(idService);
        }

        public void CreateBookingServiceWindow(string idService)
        {
            // create a blank modern window with lorem content
            // the BlankWindow ModernWindow styles is found in the mui assembly at Assets/ModernWindowStyles.xaml

            MainWindow.bookingServiceWindow = new ModernWindow
            {
                Style = (Style)App.Current.Resources["BlankWindow"],
                Title = "Booking Services",
                Content = new ServicesBook(idService),
                Width = 400,
                Height = 400,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            MainWindow.bookingServiceWindow.Show();
        }

        #endregion
    }
}
