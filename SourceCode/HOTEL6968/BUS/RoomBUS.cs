using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HOTEL6968.BUS
{
    public class RoomBUS
    {
        public string kindOfRoom = "";
        public int statusOfRoom = -1;

        RoomDAL roomDAL = new RoomDAL();
        public List<RoomViewModel> ListRooms
        {
            get
            {
                return roomDAL.GetListRooms();
            }
        }

        public bool SearchFilter(object obj, string textChange)
        {
            if (String.IsNullOrEmpty(textChange))
                return true;
            else
                return ((obj as RoomViewModel).TenPhong.IndexOf(textChange, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void Filter(ListView lvRoom, string kindOfRoom, int statusOfRoom)
        {
            if (kindOfRoom == "" && statusOfRoom == -1)
            {
                lvRoom.Items.Filter = (obj) => true;
            }
            else if (kindOfRoom != "" && statusOfRoom == -1)
            {
                lvRoom.Items.Filter = (obj) => (((RoomViewModel)obj).MaLoaiPhong == kindOfRoom);
            }
            else if (kindOfRoom == "" && statusOfRoom != -1)
            {
                lvRoom.Items.Filter = (obj) => (((RoomViewModel)obj).MaTinhTrang == statusOfRoom);
            }
            else
            {
                lvRoom.Items.Filter = (obj) => (((RoomViewModel)obj).MaTinhTrang == statusOfRoom && ((RoomViewModel)obj).MaLoaiPhong == kindOfRoom);
            }
        }

        private string imageSource;

        public void cmbKindOfRoomInRoomAdd_SelectionChanged(ComboBox cmbKindOfRoom, Image imageKindOfRoom)
        {
            switch (cmbKindOfRoom.SelectedIndex.ToString())
            {
                case "0": //Standard
                    {
                        imageSource = roomDAL.FindImageSource("STD");
                        imageKindOfRoom.Source = new BitmapImage(new Uri ("pack://application:,,,/HOTEL6968;component" + imageSource));
                        break;
                    }
                case "1": //Suite
                    {
                        imageSource = roomDAL.FindImageSource("SUI");
                        imageKindOfRoom.Source = new BitmapImage(new Uri("pack://application:,,,/HOTEL6968;component" + imageSource));
                        break;
                    }
                case "2": //Superior
                    {
                        imageSource = roomDAL.FindImageSource("SUP");
                        imageKindOfRoom.Source = new BitmapImage(new Uri("pack://application:,,,/HOTEL6968;component" + imageSource));
                        break;
                    }
                case "3": //VIP
                    {
                        imageSource = roomDAL.FindImageSource("VIP");
                        imageKindOfRoom.Source = new BitmapImage(new Uri("pack://application:,,,/HOTEL6968;component" + imageSource));
                        break;
                    }
                default:
                    break;
            }
        }

        public void AddNewRoom(string id, string name, string idKind, string information)
        {
            roomDAL.AddNewRoom(id, name, idKind, information);
        }

        #region Booking room
        CustomerDAL cusDAL = new CustomerDAL();

        public CustomerViewModel GetCustomerWithIdentityCard(string identityCard)
        {
            return cusDAL.GetCustomerWithIdentityCard(identityCard);
        }
#endregion

    }
}
