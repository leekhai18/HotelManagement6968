using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968;
using HOTEL6968.BUS;
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

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        LoginBUS loginBUS = new LoginBUS();
        AccountBUS accountBUS = new AccountBUS();

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (accountBUS.IsAvailable(txtUserName.Text, txtPassword.Password) == true)
            {
                loginBUS.btnLogin_Click();

                MainWindow.isCheck = true;
            }
            else
            {
                ModernDialog.ShowMessage("Tài khoản hoặc mật khẩu không đúng", "Lỗi đăng nhập", MessageBoxButton.OK);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            accountBUS.IsAvailable(txtUserName.Text, txtPassword.Password);
            txtPassword.Password = "";
            txtUserName.Text = "";
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Keyboard.Focus(txtPassword);
            }
        }
    }
}
