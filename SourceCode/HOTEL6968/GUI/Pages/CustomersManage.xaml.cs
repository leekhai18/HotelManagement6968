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
    /// Interaction logic for CustomersManage.xaml
    /// </summary>
    public partial class CustomersManage : UserControl
    {
        CustomerBUS customerBUS = new CustomerBUS();
        public CustomersManage()
        {
            InitializeComponent();
            dataGridListCustomer.DataContext = customerBUS;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridListCustomer.Items);
            view.Filter = SearchFilter;
        }

        private void CustomersManage_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataContext();
        }

        private void RefreshDataContext()
        {
            dataGridListCustomer.DataContext = null;
            dataGridListCustomer.DataContext = customerBUS;
        }

        private bool SearchFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                return true;
            else
                return ((obj as CustomerViewModel).TenKhachHang.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0
                    || (obj as CustomerViewModel).MaKhachHang.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridListCustomer.ItemsSource).Refresh();
        }
    }
}
