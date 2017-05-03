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
using HOTEL6968.BUS;
using HOTEL6968.DAL;

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : UserControl
    {
        RoomBUS roomBUS = new RoomBUS();
        public Rooms()
        {
            InitializeComponent();
            this.DataContext = roomBUS;

            // Bug fix late
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvRoom.Items);
            view.Filter = SearchFilter;
        }

        private bool SearchFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                return true;
            else
                return ((obj as RoomViewModel).TenPhong.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
