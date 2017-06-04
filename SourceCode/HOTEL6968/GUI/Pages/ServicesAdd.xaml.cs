using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968.BUS;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for ServicesAdd.xaml
    /// </summary>
    public partial class ServicesAdd : UserControl
    {
        ServiceBUS serviceBUS = new ServiceBUS();

        public ServicesAdd()
        {
            InitializeComponent();
        }

        private void ServicesAdd_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtFullName);
        }


        //
        string imageSourceAdded = "";

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "" && txtFullName.Text != "" && txtCharges.Text != "" && cmbKindOfService.Text != "" && txtImageSource.Text != "")
            {
                var resultDialog = ModernDialog.ShowMessage("Bạn có chắn chắc muốn thêm " + txtFullName.Text, "Xác nhận", MessageBoxButton.YesNo);

                if (resultDialog == MessageBoxResult.Yes)
                {
                    //Transform name ----> id
                    string idKind = "";
                    switch (cmbKindOfService.Text)
                    {
                        case "Food":
                            {
                                idKind = "LDV01";
                                break;
                            }
                        case "Game":
                            {
                                idKind = "LDV03";
                                break;
                            }
                        case "Rest":
                            {
                                idKind = "LDV02";
                                break;
                            }
                        default:
                            break;
                    }

                    serviceBUS.AddNewService(txtId.Text, txtFullName.Text, idKind, txtCharges.Text, txtInfomation.Text, imageSourceAdded);

                    ModernDialog.ShowMessage("Bạn đã thêm thành công", "Thành công", MessageBoxButton.OK);

                    RefreshForm();
                }
            }
            else
            {
                ModernDialog.ShowMessage("Xin điền đầy đủ các trường dữ liệu", "Thông báo", MessageBoxButton.OK);
            }
        }

        void RefreshForm()
        {
            //txtId.Text = "";
            Form.DataContext = null;
            Form.DataContext = new FormsViewModel();

            txtFullName.Text = "";
            cmbKindOfService.Text = "";
            txtCharges.Text = "";
            txtInfomation.Text = "";
            txtImageSource.Text = "";

        }

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imageService.Source = new BitmapImage(new Uri(op.FileName));
                txtImageSource.Text = imageService.Source.ToString();

                string name = System.IO.Path.GetFileName(op.FileName);
                string destinationPath = GetDestinationPath(name, "GUI\\Assets\\Services");
                imageSourceAdded = destinationPath;

                File.Copy(op.FileName, destinationPath, true);
            }
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);
            return appStartPath;
        }
    }
}
