﻿using HOTEL6968.BUS;
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
    /// Interaction logic for StaffsManage.xaml
    /// </summary>
    public partial class StaffsManage : UserControl
    {
        StaffBUS staffBUS = new StaffBUS();

        public StaffsManage()
        {
            InitializeComponent();
            this.DataContext = staffBUS;

            // Bug fix late
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvStaffs.Items);
            view.Filter = SearchFilter;
        }

        private void StaffsManage_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataContext();
        }

        private void RefreshDataContext()
        {
            this.DataContext = null;
            this.DataContext = staffBUS;
        }

        private bool SearchFilter(object obj)
        {
            return staffBUS.SearchFilter(obj, txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvStaffs.ItemsSource).Refresh();
        }
    }
}
