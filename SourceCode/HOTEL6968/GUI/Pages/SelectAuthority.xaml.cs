﻿using FirstFloor.ModernUI.App.Content;
using HOTEL6968;
using HOTEL6968.BUS;
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

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for SelectAuthority.xaml
    /// </summary>
    public partial class SelectAuthority : UserControl
    {
        SelectAuthorityBUS selectAuthorityBUS = new SelectAuthorityBUS();

        public SelectAuthority()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            selectAuthorityBUS.btnCustomer_Click();
        }
    }
}
