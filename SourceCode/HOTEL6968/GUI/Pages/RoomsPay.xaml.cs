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
        BillDetailBUS billDetailBUS;
        RoomBUS roomBUS = new RoomBUS();
        BillBUS billBUS = new BillBUS();
        string idRoom = "";
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
            idRoom = (roomBUS.idRoomSelected == "") ? "" : roomBUS.idRoomSelected;
            billDetailBUS = new BillDetailBUS(idRoom);

            dataGridBillDetails.DataContext = null;
            dataGridBillDetails.DataContext = billDetailBUS;

            this.DataContext = null;
            this.DataContext = billBUS.GetBill(idRoom);

            roomRatePerDay = (billBUS.GetBill(idRoom) == null) ? 0 : (decimal)billBUS.GetBill(idRoom).GiaPhong1Ngay;
            totalServiceRate = billDetailBUS.TotalPriceOfBill;

            isRealChangeDatePicker = true;
            labelTotalRateRoom.Content = "00";
            labelTotalRateService.Content = totalServiceRate.ToString("0,0");
            labelTotalPay.Content = labelTotalRateService.Content + " VND";

            datePickerPaying.DataContext = null;
            datePickerPaying.DataContext = new FormsViewModel();
        }


        bool isRealChangeDatePicker = true;
        private void datePickerPaying_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datePickerPaying.SelectedDate <= datePickerBooking.SelectedDate)
            {
                isRealChangeDatePicker = false;

                var resultDialog = ModernDialog.ShowMessage("Not valid", "Warning!", MessageBoxButton.OK);
                if (resultDialog == MessageBoxResult.OK)
                {
                    datePickerPaying.DataContext = null;
                    datePickerPaying.DataContext = new FormsViewModel();

                    isRealChangeDatePicker = true;

                    // UPDATE rate is displayed
                    totalRoomRate = 0;
                    labelTotalRateRoom.Content = totalRoomRate.ToString("0,0");

                    labelTotalPay.Content = (totalRoomRate + totalServiceRate).ToString("0,0") + " VND";
                }
            }
            else if (isRealChangeDatePicker == true)
            {
                isRealChangeDatePicker = true;

                // UPDATE rate is displayed
                totalRoomRate = (datePickerPaying.SelectedDate - datePickerBooking.SelectedDate).Value.Days * roomRatePerDay;
                labelTotalRateRoom.Content = totalRoomRate.ToString("0,0");

                labelTotalPay.Content = (totalRoomRate + totalServiceRate).ToString("0,0") + " VND";
            }
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerPaying.SelectedDate != null)
            {
                isRealChangeDatePicker = false;

                var resultDialog = ModernDialog.ShowMessage("You have successfully", "Success", MessageBoxButton.OK);

                if (resultDialog == MessageBoxResult.OK)
                {
                    datePickerPaying.DataContext = null;
                    datePickerPaying.DataContext = new FormsViewModel();

                    NavigationCommands.GoToPage.Execute("/GUI/Pages/RoomsManage.xaml", this);

                    roomBUS.ChangeStatusRoom(idRoom);
                }
            }
            else
            {
                ModernDialog.ShowMessage("Please select paying date", "Warning!", MessageBoxButton.OK);
            }
        }
    }
}
