﻿using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968.BUS;
using HOTEL6968.DAL;
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
    /// Interaction logic for ServicesManageFoods.xaml
    /// </summary>
    public partial class ServicesManageFoods : UserControl
    {
        ServiceBUS serviceBUS = new ServiceBUS();

        public ServicesManageFoods()
        {
            InitializeComponent();
            this.DataContext = serviceBUS;

            // Bug fix late
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvFoods.Items);
            view.Filter = SearchFilter;
        }

        private void ServicesManageFoods_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataContext();
        }

        private void RefreshDataContext()
        {
            this.DataContext = null;
            this.DataContext = serviceBUS;
        }

        private bool SearchFilter(object obj)
        {
            return serviceBUS.SearchFilter(obj, txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvFoods.ItemsSource).Refresh();
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            string idService = (string)button.DataContext.GetType().GetProperty("MaDichVu").GetValue(button.DataContext, null);

            if (button.Content.Equals("Đặt ngay"))
            {
                serviceBUS.CreateBookingServiceWindow(idService);
            }
            else
            {
                ModernDialog.ShowMessage("Please! Select the service you want to operate", "Warning", MessageBoxButton.OK);
            }
        }
    }
}
