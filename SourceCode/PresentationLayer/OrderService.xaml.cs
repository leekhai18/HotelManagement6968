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
    /// Interaction logic for OrderService.xaml
    /// </summary>
    public partial class OrderService : Window
    {
        public OrderService()
        {
            InitializeComponent();
        }

        private void TouchDownSubmit(object sender, MouseButtonEventArgs e)
        {
            btn_submit.Style = this.Resources["Submit2"] as Style;
        }

        private void TouchUpSubmit(object sender, MouseButtonEventArgs e)
        {
            btn_submit.Style = this.Resources["Submit1"] as Style;
        }

        private void TouchDownCancel(object sender, MouseButtonEventArgs e)
        {
            btn_cancel.Style = this.Resources["Cancel2"] as Style;
        }

        private void TouchUpCancel(object sender, MouseButtonEventArgs e)
        {
            btn_cancel.Style = this.Resources["Cancel1"] as Style;
            this.Close();
        }
    }
}
