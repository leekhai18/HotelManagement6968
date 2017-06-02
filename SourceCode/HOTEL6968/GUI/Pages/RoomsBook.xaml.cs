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
    /// Interaction logic for RoomsBook.xaml
    /// </summary>
    /// 
     public partial class RoomsBook : UserControl, IContent
    {
        RoomBUS roomBUS = new RoomBUS();
        CustomerBUS customerBUS = new CustomerBUS();
        BillBUS billBUS = new BillBUS();

        public RoomsBook()
        {
            InitializeComponent();
        }

        public RoomsBook Instance
        {
            get
            {
                return this;
            }
        }

        #region OnNavigateTo
        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Fragment))
            {
                roomBUS.idRoomSelected = e.Fragment;

                this.DataContext = roomBUS.GetRoomWithId(roomBUS.idRoomSelected);
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

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullName.Text != "" && txtIdCustomer.Text != "" && txtIdentityCard.Text != "" && datepickDateBirth.Text != "" && checkboxAgree.IsChecked == true
                   && cmbIdRoom.SelectedItem != null && cmbNumOfPeo.SelectedItem != null && datePickerBook.Text != "")
            {
                var resultDialog = ModernDialog.ShowMessage("Are you sure that " + txtFullName.Text + " want to book " + txtRoomName.Text, "Verify", MessageBoxButton.YesNo);

                if (resultDialog == MessageBoxResult.Yes)
                {
                    string kindCus = (RadioKindCus.IsChecked == false) ? "LKH02" : "LKH01";

                    //Check update or add Customer
                    if (Convert.ToInt32(txtIdCustomer.Text.Substring(txtIdCustomer.Text.Length - 4)) < customerBUS.LenghtListCustomer)
                        customerBUS.UpdateInfoCustomer(txtIdCustomer.Text, txtFullName.Text, txtIdentityCard.Text, txtPhoneNumber.Text, (DateTime.Parse(datepickDateBirth.Text)), kindCus);
                    else
                        customerBUS.AddNewCustomer(txtIdCustomer.Text, txtFullName.Text, txtIdentityCard.Text, txtPhoneNumber.Text, (DateTime.Parse(datepickDateBirth.Text)), kindCus);

                    //Initialization Bill
                    billBUS.InitBill(txtIdCustomer.Text, cmbIdRoom.SelectedItem.ToString(), Convert.ToDecimal(txtTotalRoomRate.Text), (DateTime)datePickerBook.SelectedDate);

                    //Change status room
                    roomBUS.ChangeStatusRoom(cmbIdRoom.SelectedItem.ToString());

                    ModernDialog.ShowMessage("You have successfully", "Success", MessageBoxButton.OK);

                    RefreshForm();
                }
            }
            else
            {
                ModernDialog.ShowMessage("Please fill in all required fields", "Notify", MessageBoxButton.OK);
            }
        }

        void RefreshForm()
        {
            MainWindow mainWd = MainWindow.mainWindow;
            mainWd.ContentSource = new Uri("GUI/Pages/RoomsBook.xaml", UriKind.Relative);
        }

        private void RoomsBook_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtIdentityCard);

            FormsViewModel dataContextForm = new FormsViewModel();
            cmbNumOfPeo.DataContext = dataContextForm;
            datePickerBook.DataContext = dataContextForm;
            cmbIdRoom.DataContext = roomBUS;
            cmbIdRoom.SelectedIndex = cmbIdRoom.Items.IndexOf(roomBUS.idRoomSelected);
        }

        private void cmbIdRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = null;
            this.DataContext = roomBUS.GetRoomWithId(cmbIdRoom.SelectedItem.ToString());

            FormsViewModel dataContextForm = new FormsViewModel();
            cmbNumOfPeo.DataContext = dataContextForm;
            datePickerBook.DataContext = dataContextForm;
            checkboxHasForeigner.IsChecked = false;

            UpdateSurcharge(rates = 0);
        }

        //Suport variable
        bool isFound = false;
        private void txtIdentityCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isFound)
            {
                RefreshFormCustomer();
                isFound = false;
            }

            var cus =  roomBUS.GetCustomerWithIdentityCard(txtIdentityCard.Text);
            if (cus != null)
            {
                txtIdCustomer.Text = cus.MaKhachHang;
                txtFullName.Text = cus.TenKhachHang;
                txtPhoneNumber.Text = cus.SDT;
                datepickDateBirth.SelectedDate = cus.NgaySinh;

                if (cus.IsVip)
                    radioKindVIP.IsChecked = true;

                isFound = true;
            }
        }

        void RefreshFormCustomer()
        {
            txtIdCustomer.DataContext = null;
            txtIdCustomer.DataContext = new FormsViewModel();

            txtFullName.Text = "";
            txtPhoneNumber.Text = "";
            datepickDateBirth.SelectedDate = null;
            RadioKindCus.IsChecked = true;
        }

        private void txtBaseRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtTotalRoomRate.Text = txtBaseRate.Text;
        }

#region Surcharge and total rate
        float rates = 0;
        void UpdateSurcharge(float rate)
        {
            txtSurcharge.Text = (Convert.ToDouble(txtBaseRate.Text) * rate).ToString("0,0");

            txtTotalRoomRate.Text = (Convert.ToDouble(txtBaseRate.Text) + Convert.ToDouble(txtSurcharge.Text)).ToString("0,0");
        }

        private void cmbNumOfPeo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbNumOfPeo.SelectedIndex > 1)
            {
                if (checkboxHasForeigner.IsChecked == false)
                    rates = 0.25f;
                else
                    rates = 0.75f;
            }
            else
            {
                if (checkboxHasForeigner.IsChecked == false)
                    rates = 0;
                else
                    rates = 0.5f;
            }

            UpdateSurcharge(rates);
        }

        private void checkboxHasForeigner_Click(object sender, RoutedEventArgs e)
        {
            if (checkboxHasForeigner.IsChecked == true)
                rates = rates + 0.5f;
            else
                rates = (rates > 0.5f) ? (rates - 0.5f) : 0;

            UpdateSurcharge(rates);
        }

        #endregion

    }
}
