﻿using FirstFloor.ModernUI.Windows.Controls;
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
        public ServicesAdd()
        {
            InitializeComponent();
        }

        private void ServicesAdd_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtFullName);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text != "" && txtFullName.Text != "" && txtCharges.Text != "" && cmbKindOfService.Text != "" && txtImageSource.Text != "")
            {
                var resultDialog = ModernDialog.ShowMessage("Are you sure that you want to add " + txtFullName.Text, "Verify", MessageBoxButton.YesNo);

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


                    ModernDialog.ShowMessage("You have successfully added", "Success", MessageBoxButton.OK);
                }
            }
            else
            {
                ModernDialog.ShowMessage("Please fill in all required fields", "Notify", MessageBoxButton.OK);
            }
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
