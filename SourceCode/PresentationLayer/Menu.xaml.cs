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
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private string name;
        public Menu(string Message): this()
        {
            name = Message;
            addControl();
        }
        public Menu()
        {
            InitializeComponent();
        }
        public void addControl() {
            if (name.Equals("khoa"))
                gri_manager.Visibility = Visibility.Hidden;
            else
                gri_staff.Visibility = Visibility.Hidden;
            img_profile.Source = new BitmapImage(new Uri("C:\\Users\\Diep Dang Khoa\\Downloads\\Compressed\\HotelManagement6968-master\\SourceCode\\PresentationLayer\\Assets\\ahihi.jpg"));
        }

        private void goToCustomerMa(object sender, RoutedEventArgs e)
        {
            Customer cusMa = new Customer(name);
            cusMa.Show();
            this.Close();
        }
    }
}
