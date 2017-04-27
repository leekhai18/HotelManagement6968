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
            var mainW = MainWindow.mainWindow;

            if (mainW.MenuLinkGroups.Count > 2)
            {
                mainW.ContentSource = new Uri("Pages/Services.xaml", UriKind.Relative);
            }
            else
            {
                MenuGroup.Remove(mainW, 0, "Pages/Services.xaml");
                MenuGroup.Add(mainW, "Services", "List", "Pages/Services.xaml");
            }
        }
    }
}
