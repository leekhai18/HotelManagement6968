using FirstFloor.ModernUI.Presentation;
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

namespace HOTEL6968.GUI.Pages
{
    /// <summary>
    /// Interaction logic for RoomsAdd.xaml
    /// </summary>
    public partial class RoomsAdd : UserControl
    {
        RoomBUS roomBUS = new RoomBUS();

        public RoomsAdd()
        {
            InitializeComponent();
        }

        private void cmbKindOfRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomBUS.cmbKindOfRoomInRoomAdd_SelectionChanged(cmbKindOfRoom, imageKindOfRoom);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
