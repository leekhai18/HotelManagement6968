﻿using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
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


        private void RoomsAdd_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtId);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullName.Text != "" && txtId.Text != "" && cmbKindOfRoom.Text != "")
            {
                var resultDialog = ModernDialog.ShowMessage("Bạn có chắc chắn muốn thêm " + txtFullName.Text, "Xác nhận", MessageBoxButton.YesNo);

                if (resultDialog == MessageBoxResult.Yes)
                {
                    //Transform name ----> id
                    string idKind = "";
                    switch (cmbKindOfRoom.Text)
                    {
                        case "Standard":
                            {
                                idKind = "STD";
                                break;
                            }
                        case "Suite":
                            {
                                idKind = "SUI";
                                break;
                            }
                        case "Superior":
                            {
                                idKind = "SUP";
                                break;
                            }
                        case "VIP":
                            {
                                idKind = "VIP";
                                break;
                            }

                        default:
                            break;
                    }

                    roomBUS.AddNewRoom(txtId.Text, txtFullName.Text, idKind , txtInfomation.Text);

                    ModernDialog.ShowMessage("Bạn đã thêm thành công", "Thành công", MessageBoxButton.OK);
                }
            }
            else
            {
                ModernDialog.ShowMessage("Xin điền đầy đủ các trường dữ liệu", "Thông báo", MessageBoxButton.OK);
            }
        }

        private void cmbKindOfRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomBUS.cmbKindOfRoomInRoomAdd_SelectionChanged(cmbKindOfRoom, imageKindOfRoom);
        }
    }
}
