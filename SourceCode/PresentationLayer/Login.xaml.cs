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
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
        public string name;
        private void login(object sender, RoutedEventArgs e)
        {
            name = txt_name.Text.ToString();
            if (name.Equals("khoa") || name.Equals("ahihi") && txt_password.Password.ToString().Equals("1"))
            {
                Menu menu = new Menu(name);
                this.Close();
                menu.Show();
            }
            else if (name.Equals("") || txt_password.Password.ToString().Equals(""))
            {
                lb_report.Content = "Bạn chưa nhập tài khoản hoặc mật khẩu";
                lb_report.Visibility = Visibility.Visible;
            }
            else
            {
                lb_report.Content = "Sai tài khoản hoặc mật khẩu";
                lb_report.Visibility = Visibility.Visible;
            }

        }
    }
}
