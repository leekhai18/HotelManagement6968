using FirstFloor.ModernUI.App.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class LoginBUS
    {
        public void btnLogin_Click()
        {
            MainWindow mainWd = MainWindow.mainWindow;

            if (mainWd.MenuLinkGroups.Count < 2)
            {
                // Add Rooms Group
                List<string> listLinkName = new List<string>();
                listLinkName.Add("Manage");
                listLinkName.Add("Add");
                MenuGroup.Add(mainWd, "Rooms", listLinkName.Count, listLinkName, "GUI/Pages/Rooms.xaml");

                // Add Services Group
                listLinkName.Clear();
                listLinkName.Add("Foods");
                listLinkName.Add("Games");
                listLinkName.Add("Rests");
                listLinkName.Add("Add");
                MenuGroup.Add(mainWd, "Services", listLinkName.Count, listLinkName, "GUI/Pages/Services.xaml");

                // Add Staffs Group
                listLinkName.Clear();
                listLinkName.Add("Manage");
                listLinkName.Add("Add");
                MenuGroup.Add(mainWd, "Staffs", listLinkName.Count, listLinkName, "GUI/Pages/Staffs.xaml");

                // Add Customers Group
                listLinkName.Clear();
                listLinkName.Add("Manage");
                MenuGroup.Add(mainWd, "Customers", listLinkName.Count, listLinkName, "GUI/Pages/Customers.xaml");

                MenuGroup.Remove(mainWd, 0, "GUI/Pages/Rooms.xaml");
            }
        }
    }
}
