using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class LoginBUS
    {
        MenuGroup menuGroup = new MenuGroup();

        public void btnLogin_Click()
        {
            MainWindow mainWd = MainWindow.mainWindow;

            if (mainWd.MenuLinkGroups.Count < 2)
            {
                // Add Rooms Group
                List<Link> listLink = new List<Link>();
                listLink.Add(new Link() { DisplayName = "Manage", Source = new Uri("GUI/Pages/RoomsManage.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Add", Source = new Uri("GUI/Pages/Rooms.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Rooms", listLink.Count, listLink);

                // Add Services Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Manage", Source = new Uri("GUI/Pages/ServicesManage.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Add", Source = new Uri("GUI/Pages/Services.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Services", listLink.Count, listLink);

                // Add Staffs Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Manage", Source = new Uri("GUI/Pages/StaffsManage.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Add", Source = new Uri("GUI/Pages/Staffs.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Staffs", listLink.Count, listLink);

                // Add Customers Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Manage", Source = new Uri("GUI/Pages/CustomersManage.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Customers", listLink.Count, listLink);

                menuGroup.Remove(mainWd, 0, "GUI/Pages/RoomsManage.xaml");
            }
        }
    }
}
