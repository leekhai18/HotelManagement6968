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
using BusinessLogicLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for BookRoom.xaml
    /// </summary>
    public partial class BookRoom : Window
    {
        string ID;
        List<String> list;
        ListView lv_Room;
        public BookRoom(string Message) : this()
        {
            ID = Message;
        }
        public BookRoom()
        {
            InitializeComponent();
        }
        private void book()
        {
            //list.Add(txt_IdCus.Text);
            //list.Add(txt_name.Text);
            //list.Add(txt_id.Text);
            //if (rad_male.IsChecked==true)
            //    list.Add("Nam");
            //else
            //    list.Add("Nữ");
            //list.Add(txt_dateOfBirth.Text);
            //list.Add(txt_room.Text);
            //list.Add(txt_dateIn.Text);
            //list.Add(txt_dateOut.Text);
            //list.Add(txt_bill.Text);
            //list.Add(txt_phone.Text);
            //list.Add(txt_Note.Text);
            RoomBus.Instance.Book(ID);
            CustomerBus.Instance.Add(list);
            this.Close();
        }
        private void TouchDownBook(object sender, MouseButtonEventArgs e)
        {
            btn_save.Style = this.Resources["Save2"] as Style;
        }

        private void TouchUpBook(object sender, MouseButtonEventArgs e)
        {
            btn_save.Style = this.Resources["Save1"] as Style;
            book();
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
