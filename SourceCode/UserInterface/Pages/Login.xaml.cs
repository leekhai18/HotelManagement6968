using FirstFloor.ModernUI.App.Content;
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

namespace UserInterface.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.MenuLinkGroups.Count < 2)
            {
                MenuGroup.Add(MainWindow.mainWindow, "Rooms", "List", "Pages/Rooms.xaml");
                MenuGroup.Add(MainWindow.mainWindow, "Services", "List", "Pages/Services.xaml");
                MenuGroup.Add(MainWindow.mainWindow, "Staffs", "List", "Pages/Staffs.xaml");
                MenuGroup.Add(MainWindow.mainWindow, "Customers", "List", "Pages/Customers.xaml");

                MenuGroup.Remove(MainWindow.mainWindow, 0, "Pages/Setting.xaml");
            }
        }
    }
}
