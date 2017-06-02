using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Windows;
using HOTEL6968.BUS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Navigation;
using FirstFloor.ModernUI.Windows.Controls;


namespace HOTEL6968.GUI.Pages
{
    /// <summary>
    /// Interaction logic for RoomsPay.xaml
    /// </summary>
    public partial class RoomsPay : UserControl, IContent
    {
        BillDetailBUS billDetailBUS = new BillDetailBUS("2");
        RoomBUS roomBUS = new RoomBUS();
        BillBUS billBUS = new BillBUS();
        decimal roomRatePerDay = 0;
        decimal totalRoomRate = 0;
        decimal totalServiceRate = 0;

        public RoomsPay()
        {
            InitializeComponent();
        }

        #region OnNavigateTo
        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Fragment))
            {
                roomBUS.idRoomSelected = e.Fragment;
            }
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridBillDetails.DataContext = null;
            dataGridBillDetails.DataContext = billDetailBUS;

            this.DataContext = null;
            this.DataContext = billBUS.GetBill(roomBUS.idRoomSelected);

            roomRatePerDay = (decimal)billBUS.GetBill(roomBUS.idRoomSelected).GiaPhong1Ngay;
            totalServiceRate = billDetailBUS.TotalPriceOfBill;

            labelTotalRateService.Content = totalServiceRate.ToString("0,0");
            labelTotalPay.Content = labelTotalRateService.Content;
        }

        private void datePickerPaying_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePickerPaying.SelectedDate <= datePickerBooking.SelectedDate)
            {
                ModernDialog.ShowMessage("Not valid", "Warning!", MessageBoxButton.OK);
            }
            else
            {
                totalRoomRate = (datePickerPaying.SelectedDate - datePickerBooking.SelectedDate).Value.Days * roomRatePerDay;
                labelTotalRateRoom.Content = totalRoomRate.ToString("0,0");

                labelTotalPay.Content = (totalRoomRate + totalServiceRate).ToString("0,0");
            }
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            roomBUS.ChangeStatusRoom(roomBUS.idRoomSelected);
        }
    }
}
