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
    /// Interaction logic for StaffEditer.xaml
    /// </summary>
    public partial class StaffEditer : Window
    {
        List<String> item;
        public StaffEditer(List<String> Message) : this()
        {
            item = Message;
            txt_IDSta.Text = item[0].ToString();
            txt_name.Text = item[1].ToString();
            txt_id.Text = item[2].ToString();
            if (rad_male.Content.ToString().Equals(item[3]))
                rad_male.IsChecked = true;
            else
                rad_female.IsChecked = true;
            txt_dateOfBirth.Text = item[4].ToString();
            txt_phone.Text = item[5].ToString();
            txt_position.Text = item[6].ToString();
            txt_salary.Text = item[7].ToString();
        }
        public StaffEditer()
        {
            InitializeComponent();
        }

        private void save()
        {
            //item.RemoveRange(0, item.Count - 1);
            //item.Add(txt_IDSta.Text);
            //item.Add(txt_name.Text);
            //item.Add(txt_id.Text);
            //if (rad_male.IsChecked == true)
            //    item.Add(rad_male.Content.ToString());
            //else
            //    item.Add(rad_female.Content.ToString());
            //item.Add(txt_dateOfBirth.Text);
            //item.Add(txt_phone.Text);
            //item.Add(txt_position.Text);
            //item.Add(txt_salary.Text);
            //StaffManagement cus = new StaffManagement(item);
            //cus.Show();
            this.Close();
        }

        private void TouchDownSave(object sender, MouseButtonEventArgs e)
        {
            btn_save.Style = this.Resources["Save2"] as Style;
        }

        private void TouchUpSave(object sender, MouseButtonEventArgs e)
        {
            btn_save.Style = this.Resources["Save1"] as Style;
            save();
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

        private void Touch(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                btn_save.Style = this.Resources["Save1"] as Style;
                btn_cancel.Style = this.Resources["Cancel1"] as Style;
            }
        }
    }
}
