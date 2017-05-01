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

namespace GUI.Pages
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
            MainWindow mainWd = MainWindow.mainWindow;

            if (mainWd.MenuLinkGroups.Count < 2)
            {
                // Add Rooms Group
                List<string> listLinkName = new List<string>();
                //listLinkName.Add("Foods");
                //listLinkName.Add("Games");
                //listLinkName.Add("Rests");
                MenuGroup.Add(mainWd, "Rooms", listLinkName.Count, listLinkName, "Pages/Rooms.xaml");

                // Add Services Group
                listLinkName.Clear();
                listLinkName.Add("Foods");
                listLinkName.Add("Games");
                listLinkName.Add("Rests");
                MenuGroup.Add(mainWd, "Services", listLinkName.Count, listLinkName, "Pages/Services.xaml");

                // Add Staffs Group
                listLinkName.Clear();
                listLinkName.Add("Foods");
                listLinkName.Add("Games");
                listLinkName.Add("Rests");
                MenuGroup.Add(mainWd, "Staffs", listLinkName.Count, listLinkName, "Pages/Staffs.xaml");

                // Add Customers Group
                listLinkName.Clear();
                listLinkName.Add("Foods");
                listLinkName.Add("Games");
                listLinkName.Add("Rests");
                MenuGroup.Add(mainWd, "Customers", listLinkName.Count, listLinkName, "Pages/Customers.xaml");


                MenuGroup.Remove(mainWd, 0, "Pages/Setting.xaml");
            }
        }
    }
}
