using System;
using System.Collections.Generic;
using System.Drawing;
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
using BusinessLogicLayer;


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
        public string pass;
        private void login(object sender, RoutedEventArgs e)
        {
            if (AccountBus.Instance.TestAccount(txt_name.Text.ToString(),txt_password.Password.ToString()))
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
        private void MaximizeClick(object sender, RoutedEventArgs e)
        {
            if (App.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                App.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else if (App.Current.MainWindow.WindowState == WindowState.Normal)
            {
                App.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void lostFocus(object sender, RoutedEventArgs e)
        {
            if (!txt_password.Password.ToString().Equals(""))
                txt_password.Background = System.Windows.Media.Brushes.Black;
        }
        private void TouchDownCancel(object sender, MouseButtonEventArgs e)
        {
            btn_cancel.Style = this.Resources["RoundCorner2"] as Style;
        }

        private void TouchUpCancel(object sender, MouseButtonEventArgs e)
        {
            btn_cancel.Style = this.Resources["RoundCorner1"] as Style;
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
        private void Touch(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                btn_login.Style = this.Resources["RoundCorner"] as Style;
                btn_cancel.Style = this.Resources["RoundCorner1"] as Style;
            }
        }


        private void TouchUpLogin(object sender, MouseButtonEventArgs e)
        {
            btn_login.Style = this.Resources["RoundCorner"] as Style;
            name = txt_name.Text.ToString();
            pass = txt_password.Password.ToString();
            if (AccountBus.Instance.TestAccount(txt_name.Text.ToString(), txt_password.Password.ToString()))
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

        private void TouchDownLogin(object sender, MouseButtonEventArgs e)
        {
            btn_login.Style = this.Resources["RoundCorner0"] as Style;
        }
    }
}
