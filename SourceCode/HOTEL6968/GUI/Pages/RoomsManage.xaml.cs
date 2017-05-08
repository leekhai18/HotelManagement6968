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
    /// Interaction logic for RoomsManage.xaml
    /// </summary>
    public partial class RoomsManage : UserControl
    {
        RoomBUS roomBUS = new RoomBUS();
        public RoomsManage()
        {
            InitializeComponent();
            this.DataContext = roomBUS;
   
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvRoom.Items);
            view.Filter = SearchFilter;
        }

        private void RoomsManage_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataContext();
        }

        private void RefreshDataContext()
        {
            this.DataContext = null;
            this.DataContext = roomBUS;
        }

        private bool SearchFilter(object obj)
        {
            return roomBUS.SearchFilter(obj, txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvRoom.ItemsSource).Refresh();
        }

        private void cmbKindOfRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomBUS.cmbKindOfRoom_SelectionChanged(lvRoom, cmbKindOfRoom);
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomBUS.cmbStatus_SelectionChanged(lvRoom, cmbStatus);
        }
    }
}
