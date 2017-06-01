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

namespace HOTEL6968.GUI.Pages
{
    /// <summary>
    /// Interaction logic for RoomsBook.xaml
    /// </summary>
    /// 
     public partial class RoomsBook : UserControl, IContent
    {
        RoomBUS roomBUS = new RoomBUS();

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
