using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RulesManage.xaml
    /// </summary>
    public partial class RulesManage : UserControl
    {
        RuleBUS ruleBUS = new RuleBUS();
        string idKind = "";

        public RulesManage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = null;
            this.DataContext = ruleBUS;
        }

        private void btnSaveDetailRoom_Click(object sender, RoutedEventArgs e)
        {
            var resultDialog = ModernDialog.ShowMessage("Bạn có chắn chắn muốn thay đổi giá phòng " + cmbKindOfRoom.Text, "Xác nhận", MessageBoxButton.OKCancel);

            if (resultDialog == MessageBoxResult.OK)
            {
                ruleBUS.UpdateRateRoom(idKind, Convert.ToDecimal(txtRate.Text));         
            }
        }

        private void cmbKindOfRoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbKindOfRoom.SelectedIndex)
            {
                case 0:
                    idKind = "STD";
                    break;
                case 1:
                    idKind = "SUI";
                    break;
                case 2:
                    idKind = "SUP";
                    break;
                case 3:
                    idKind = "VIP";
                    break;
                default:
                    break;
            }

            txtRate.Text = ruleBUS.RateRoom(idKind);
        }

        private void btnSaveDetailSurchageRoom_Click(object sender, RoutedEventArgs e)
        {
            var resultDialog = ModernDialog.ShowMessage("Bạn có chắn chắn muốn thay đổi phụ thu " + cmbKindOfRoom.Text, "Xác nhận", MessageBoxButton.OKCancel);

            if (resultDialog == MessageBoxResult.OK)
            {
                ruleBUS.UpdateSurchage(txtSurNumberCus.Text, txtSurForeign.Text);
            }
        }

        private void txtSurNumberCus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtSurNumberCus.Text.Contains(".") == true)
            {
                if (e.Text == ".")
                {
                    e.Handled = true;
                    return;
                }
            }

            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

            e.Handled = !regex.IsMatch(e.Text);
        }

        private void txtSurForeign_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (txtSurForeign.Text.Contains(".") == true)
            {
                if (e.Text == ".")
                    e.Handled = true;
            }
            else
            {
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");

                e.Handled = !regex.IsMatch(e.Text);
            }
        }

        private void txtRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
        }
    }
}
