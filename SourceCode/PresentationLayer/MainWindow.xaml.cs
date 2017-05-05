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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void goToFood(object sender, RoutedEventArgs e)
        {
            Food food = new Food();
            this.Close();
            food.Show();
        }

        private void GoTologin(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
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
        private void TouchDownSta(object sender, MouseButtonEventArgs e)
        {
            btn_sta.Style = this.Resources["RoundCorner0"] as Style;
        }

        private void TouchUpSta(object sender, MouseButtonEventArgs e)
        {
            btn_sta.Style = this.Resources["RoundCorner"] as Style;
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void Move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Touch(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                btn_sta.Style = this.Resources["RoundCorner"] as Style;
                btn_cus.Style = this.Resources["RoundCorner1"] as Style;
            }
        }

        private void TouchDownCus(object sender, MouseButtonEventArgs e)
        {
            btn_cus.Style = this.Resources["RoundCorner2"] as Style;
        }

        private void TouchUpCus(object sender, MouseButtonEventArgs e)
        {
            btn_cus.Style = this.Resources["RoundCorner1"] as Style;
            Food food = new Food();
            this.Close();
            food.Show();
        }
    }
}
