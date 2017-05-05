using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class SelectAuthorityBUS
    {
        MenuGroup menuGroup = new MenuGroup();

        public void btnCustomer_Click()
        {
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
                listLink.Add(new Link() { DisplayName = "Add", Source = new Uri("GUI/Pages/Services.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Services", listLink.Count, listLink);
            }
        }
    }
}
