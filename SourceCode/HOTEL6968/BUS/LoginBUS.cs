using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class LoginBUS
    {
        // Authority
        MenuGroup menuGroup = new MenuGroup();

        public void btnLogin_Click()
        {
            MainWindow mainWd = MainWindow.mainWindow;

            if (mainWd.MenuLinkGroups.Count < 2)
            {
                // Add Rooms Group
                List<Link> listLink = new List<Link>();
                listLink.Add(new Link() { DisplayName = "Quản lí", Source = new Uri("GUI/Pages/RoomsManage.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Đặt", Source = new Uri("GUI/Pages/RoomsBook.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Thêm", Source = new Uri("GUI/Pages/RoomsAdd.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Phòng", listLink.Count, listLink);

                // Add Services Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Quản lí", Source = new Uri("GUI/Pages/ServicesManage.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Thêm", Source = new Uri("GUI/Pages/ServicesAdd.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Dịch vụ", listLink.Count, listLink);

                // Add Staffs Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Quản lí", Source = new Uri("GUI/Pages/StaffsManage.xaml", UriKind.Relative) });
                listLink.Add(new Link() { DisplayName = "Thêm", Source = new Uri("GUI/Pages/StaffsAdd.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Nhân viên", listLink.Count, listLink);

                // Add Customers Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Quản lí", Source = new Uri("GUI/Pages/CustomersManage.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Khách hàng", listLink.Count, listLink);

                // Add Statistics Report Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Quản lí", Source = new Uri("GUI/Pages/StatisticsManage.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Thống kê", listLink.Count, listLink);

                // Add Rule Group
                listLink.Clear();
                listLink.Add(new Link() { DisplayName = "Quản lí", Source = new Uri("GUI/Pages/RulesManage.xaml", UriKind.Relative) });
                menuGroup.Add(mainWd, "Qui định", listLink.Count, listLink);

                menuGroup.Remove(mainWd, 0, "GUI/Pages/RoomsManage.xaml");
            }
        }
    }
}
