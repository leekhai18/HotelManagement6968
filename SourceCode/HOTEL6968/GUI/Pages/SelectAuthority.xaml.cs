using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using HOTEL6968;
using HOTEL6968.BUS;
using System;
using System.Collections;
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

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for SelectAuthority.xaml
    /// </summary>
    public partial class SelectAuthority : UserControl
    {
        MainWindowBUS mainBUS = new MainWindowBUS();

        public SelectAuthority()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            MenuGroup menuGroup = new MenuGroup();

            var mainWd = MainWindow.mainWindow;

            if (mainWd.MenuLinkGroups.Count > 2)
            {
                mainWd.ContentSource = new Uri("GUI/Pages/ServicesManage.xaml", UriKind.Relative);
            }
            else
            {
                menuGroup.Remove(mainWd, 0, "GUI/Pages/ServicesManage.xaml");

                // Add Services Group
                List<Link> listLink = new List<Link>();
                listLink.Add(new Link() { DisplayName = "Manage", Source = new Uri("GUI/Pages/ServicesManage.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Services", listLink.Count, listLink);
            }

            MainWindow.isCheck = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.isCheck == true)
            {
                mainBUS.Init();

                MainWindow.isCheck = false;
            }
        }
    }
}
