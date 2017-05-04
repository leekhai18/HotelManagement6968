using FirstFloor.ModernUI.App.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class SelectAuthorityBUS
    {
        public void btnCustomer_Click()
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
