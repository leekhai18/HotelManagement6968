﻿using HOTEL6968.BUS;
using System;
using System.Collections.Generic;
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

namespace HOTEL6968.GUI.Pages
{
    /// <summary>
    /// Interaction logic for ServicesBook.xaml
    /// </summary>
    public partial class ServicesBook : UserControl
    {
        ServiceBUS serviceBUS = new ServiceBUS();
        RoomBUS roomBUS = new RoomBUS();
        decimal priceSevice = 0;
        string idServiceSelected = "";

        public ServicesBook()
        {
            InitializeComponent();
        }

        public ServicesBook(string idService)
        {
            InitializeComponent();
            idServiceSelected = idService;
        }

        private void btnIncrease_Click(object sender, RoutedEventArgs e)
        {
            txtValueQuantity.Text = (Convert.ToInt16(txtValueQuantity.Text) + 1).ToString();
        }

        private void btnDescrease_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt16(txtValueQuantity.Text) > 1)
                txtValueQuantity.Text = (Convert.ToInt16(txtValueQuantity.Text) - 1).ToString();
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.bookingServiceWindow.Close();
        }

        private void txtValueQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtTotalPrices.Text = (priceSevice * Convert.ToInt16(txtValueQuantity.Text)).ToString("0,0");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var dataContext = serviceBUS.GetServiceWithId(idServiceSelected);
            DataContext = dataContext;
            cmbIdRoom.DataContext = roomBUS;

            priceSevice = dataContext.GiaDichVu;
            txtValueQuantity.Text = "1";
        }
    }
}