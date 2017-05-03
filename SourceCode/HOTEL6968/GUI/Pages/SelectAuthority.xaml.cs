using FirstFloor.ModernUI.App.Content;
using HOTEL6968;
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
    /// Interaction logic for SelectAuthority.xaml
    /// </summary>
    public partial class SelectAuthority : UserControl
    {
        public SelectAuthority()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            var mainWd = MainWindow.mainWindow;

            if (mainWd.MenuLinkGroups.Count > 2)
            {
                mainWd.ContentSource = new Uri("GUI/Pages/Services.xaml", UriKind.Relative);
            }
            else
            {
                MenuGroup.Remove(mainWd, 0, "GUI/Pages/Services.xaml");

                // Add Services Group
                List<string> listLinkName = new List<string>();
                listLinkName.Add("Foods");
                listLinkName.Add("Games");
                listLinkName.Add("Rests");
                MenuGroup.Add(mainWd, "Services", listLinkName.Count, listLinkName, "GUI/Pages/Services.xaml");
            }
        }
    }
}
