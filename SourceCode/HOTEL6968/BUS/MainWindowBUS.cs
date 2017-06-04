using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class MainWindowBUS
    {
        // Authority
        MenuGroup menuGroup = new MenuGroup();

        public void Init()
        {
            MainWindow mainWd = MainWindow.mainWindow;

            int count = mainWd.MenuLinkGroups.Count;
            while (count > 0)
            {
                mainWd.MenuLinkGroups.RemoveAt(count - 1);
                count--;
            }

            if (mainWd.MenuLinkGroups.Count < 1)
            {
                // Add Rooms Group
                List<Link> listLink = new List<Link>();
                listLink.Add(new Link() { DisplayName = "Chào mừng", Source = new Uri("GUI/Pages/SelectAuthority.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Giới thiệu", listLink.Count, listLink);

                mainWd.ContentSource = new Uri("GUI/Pages/SelectAuthority.xaml", UriKind.Relative);
            }
        }
    }
}
