using FirstFloor.ModernUI.Windows.Controls;
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

namespace HOTEL6968.GUI.Pages
{
    /// <summary>
    /// Interaction logic for CustomersAdd.xaml
    /// </summary>
    public partial class CustomersAdd : UserControl
    {
        CustomerBUS customerBUS = new CustomerBUS();

        public CustomersAdd()
        {
            InitializeComponent();     
        }

        private void CustomersAdd_loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this.txtFullName);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtFullName.Text != "" && txtIdCustomer.Text != "" && txtIdentityCard.Text != "" && datepickDateBirth.Text != "" && checkboxAgree.IsChecked == true)
            {
                var resultDialog = ModernDialog.ShowMessage("Are you sure that you want to add " + txtFullName.Text, "Verify", MessageBoxButton.YesNo);

                if (resultDialog == MessageBoxResult.Yes)
                {
                    customerBUS.AddNewCustomer(txtIdCustomer.Text, txtFullName.Text, txtIdentityCard.Text, txtPhoneNumber.Text, (DateTime.Parse(datepickDateBirth.Text)));

                    ModernDialog.ShowMessage("You have successfully added", "Success", MessageBoxButton.OK);
                }
            }
            else
            {
                ModernDialog.ShowMessage("Please fill in all required fields", "Notify", MessageBoxButton.OK);
            }
        }
    }
}
