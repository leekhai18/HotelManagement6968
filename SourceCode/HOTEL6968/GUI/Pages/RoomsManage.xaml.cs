using FirstFloor.ModernUI.Windows.Controls;
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
            switch (cmbKindOfRoom.SelectedIndex.ToString())
            {
                case "0": //Standard
                    {
                        roomBUS.kindOfRoom = "STD";
                        break;
                    }
                case "1": //Suite
                    {
                        roomBUS.kindOfRoom = "SUI";
                        break;
                    }
                case "2": //Superior
                    {
                        roomBUS.kindOfRoom = "SUP";
                        break;
                    }
                case "3": //VIP
                    {
                        roomBUS.kindOfRoom = "VIP";
                        break;
                    }
                case "4": //All...
                    {
                        roomBUS.kindOfRoom = "";
                        break;
                    }
                default:
                    break;
            }

            roomBUS.Filter(lvRoom, roomBUS.kindOfRoom, roomBUS.statusOfRoom);
        }

        private void cmbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbStatus.SelectedIndex.ToString())
            {
                case "0": //Hired = 2
                    {
                        roomBUS.statusOfRoom = 2;
                        break;
                    }
                case "1": //Empty = 1
                    {
                        roomBUS.statusOfRoom = 1;
                        break;
                    }
                default:
                    break;
            }

            roomBUS.Filter(lvRoom, roomBUS.kindOfRoom, roomBUS.statusOfRoom);
        }


        //
        bool isBooking = false;
        bool isSelected = false;
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if (isSelected)
            {
                if (isBooking)
                {
                    NavigationCommands.GoToPage.Execute("/GUI/Pages/RoomsBook.xaml#" + roomBUS.idRoomSelected, this);
                }
                else
                {
                    NavigationCommands.GoToPage.Execute("/GUI/Pages/RoomsPay.xaml#" + roomBUS.idRoomSelected, this);
                }
            }
            else
            {
                ModernDialog.ShowMessage("Please! Select the room you want to operate", "Warning", MessageBoxButton.OK);
            }
        }

        private void lvRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                isSelected = true;

                RoomViewModel roomSelected = (e.AddedItems[0] as RoomViewModel);

                if (roomSelected.MaTinhTrang == 1)
                {
                    roomBUS.idRoomSelected = (e.AddedItems[0] as RoomViewModel).MaPhong;
                    isBooking = true;
                }
                else
                {
                    roomBUS.idRoomSelected = (e.AddedItems[0] as RoomViewModel).MaPhong;
                    isBooking = false;
                }
            }
            else
            {
                isSelected = false;
            }
        }
    }
}
