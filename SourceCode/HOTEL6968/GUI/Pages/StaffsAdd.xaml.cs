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
    /// Interaction logic for StaffsAdd.xaml
    /// </summary>
    public partial class StaffsAdd : UserControl
    {
        StaffBUS staffBUS = new StaffBUS();
        AccountBUS accountBUS = new AccountBUS();

        public StaffsAdd()
        {
            InitializeComponent();
        }

        private void ServicesAdd_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtFullName);
        }

        //
        string imageSourceAdded = "";

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imageStaff.Source = new BitmapImage(new Uri(op.FileName));
                txtImageSource.Text = imageStaff.Source.ToString();

                string name = System.IO.Path.GetFileName(op.FileName);
                string destinationPath = GetDestinationPath(name, "GUI\\Assets\\Staffs");
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


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "" && txtFullName.Text != "" && txtIdentityCard.Text != "" && checkboxAgree.IsChecked == true)
            {
                var resultDialog = ModernDialog.ShowMessage("Are you sure that you want to add " + txtFullName.Text, "Verify", MessageBoxButton.YesNo);

                if (resultDialog == MessageBoxResult.Yes)
                {
                    //Transform name ----> id
                    string idPos = "";
                    switch (cmbPosition.Text)
                    {
                        case "Receptionists":
                            {
                                idPos = "CV01";
                                break;
                            }
                        case "Manager":
                            {
                                idPos = "CV03";
                                break;
                            }
                        case "Other":
                            {
                                idPos = "CV02";
                                break;
                            }
                        default:
                            break;
                    }

                    string gen = (RadioGendeMale.IsChecked == true) ? "Nam" : "Nữ";

                    staffBUS.AddNewStaff(txtId.Text, txtFullName.Text, txtIdentityCard.Text, txtAddress.Text, txtEmail.Text, gen, idPos, DateTime.Parse(datepickDateBirth.Text), txtPhoneNum.Text, imageSourceAdded);
                    accountBUS.Create(txtId.Text, "123");

                    ModernDialog.ShowMessage("You have successfully added", "Success", MessageBoxButton.OK);

                    RefreshForm();
                }
            }
            else
            {
                ModernDialog.ShowMessage("Please fill in all required fields", "Notify", MessageBoxButton.OK);
            }
        }

        void RefreshForm()
        {
            //txtId.Text = "";
            Form.DataContext = null;
            Form.DataContext = new FormsViewModel();

            txtFullName.Text = "";
            txtIdentityCard.Text = "";
            datepickDateBirth.Text = "";
            cmbPosition.Text = "";
            txtImageSource.Text = "";
            txtPhoneNum.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            checkboxAgree.IsChecked = false;
        }
    }
}
