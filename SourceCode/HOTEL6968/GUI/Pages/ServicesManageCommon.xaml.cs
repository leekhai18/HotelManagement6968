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
    public partial class ServicesManageCommon : UserControl
    {
        ServiceBUS serviceBUS = new ServiceBUS();

        public ServicesManageCommon()
        {
            InitializeComponent();
            this.DataContext = serviceBUS;

            // Bug fix late
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvServices.Items);
            view.Filter = SearchFilter;
        }

        private bool SearchFilter(object obj)
        {
            if ((obj as ServiceViewModel).MaLoaiDichVu == serviceBUS.maLoaiDichVu)
            {
                if (String.IsNullOrEmpty(txtSearch.Text))
                    return true;
                else
                    return ((obj as ServiceViewModel).TenDichVu.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            return false;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvServices.ItemsSource).Refresh();
        }
    }
}
