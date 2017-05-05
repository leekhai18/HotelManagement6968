using HOTEL6968.BUS;
using HOTEL6968.DAL;
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

namespace HOTEL6968.GUI.Pages
{
    /// <summary>
    /// Interaction logic for ServicesManage.xaml
    /// </summary>
    public partial class ServicesManage : UserControl
    {
        ServiceBUS serviceBUS = new ServiceBUS();

        public ServicesManage()
        {
            InitializeComponent();
        }

        private void ServicesManageTab_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement link = e.OriginalSource as FrameworkElement;

            if (link != null && link.ToString() == "System.Windows.Controls.TextBlock")
            {
                string text = (link as TextBlock).Text;

                switch (text)
                {
                    case "FOODS":
                        {
                            serviceBUS.maLoaiDichVu = "LDV01";
                            break;
                        }
                    case "GAMES":
                        {
                            serviceBUS.maLoaiDichVu = "LDV02";
                            Console.Write(serviceBUS.maLoaiDichVu);
                            break;
                        }
                    case "RESTS":
                        {
                            serviceBUS.maLoaiDichVu = "LDV03";
                            break;
                        }

                    default:
                        break;
                }
            }
        }
    }
}
