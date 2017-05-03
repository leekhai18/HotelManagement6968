using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HOTEL6968.BUS
{
    public class RoomBUS
    {
        string kindOfRoom = "";
        int statusOfRoom = -1;

        RoomDAL roomDAL = new RoomDAL();

        public List<RoomViewModel> ListPhong
        {
            get
            {
                return roomDAL.GetListPhong();
            }
        }

        public void cmbKindOfRoom_SelectionChanged(ListView lvRoom, ComboBox cmbKindOfRoom)
        {
            switch (cmbKindOfRoom.SelectedIndex.ToString())
            {
                case "0": //Standard
                    {
                        kindOfRoom = "STD";
                        break;
                    }
                case "1": //Suite
                    {
                        kindOfRoom = "SUI";
                        break;
                    }
                case "2": //Superior
                    {
                        kindOfRoom = "SUP";
                        break;
                    }
                case "3": //VIP
                    {
                        kindOfRoom = "VIP";
                        break;
                    }
                case "4": //All...
                    {
                        kindOfRoom = "";
                        break;
                    }
                default:
                    break;
            }

            this.Filter(lvRoom, kindOfRoom, statusOfRoom);
        }

        public void cmbStatus_SelectionChanged(ListView lvRoom, ComboBox cmbStatus)
        {
            switch (cmbStatus.SelectedIndex.ToString())
            {
                case "0": //Hired = 2
                    {
                        statusOfRoom = 2;
                        break;
                    }
                case "1": //Empty = 1
                    {
                        statusOfRoom = 1;
                        break;
                    }
                case "2": //Fixing = 3
                    {
                        statusOfRoom = 3;
                        break;
                    }
                default:
                    break;
            }

            this.Filter(lvRoom, kindOfRoom, statusOfRoom);
        }

        private void Filter(ListView lvRoom, string kindOfRoom, int statusOfRoom)
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
    }
}
