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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        CollectionView view;
        List<String> listSearch,listSorting;
        String search;
        String name;
        public Customer(string Message): this()
        {
            name = Message;
        }
        public Customer()
        {
            InitializeComponent();
            List<Customers> items = new List<Customers>();
            items.Add(new Customers() {
                IDCus = "01",
                Name = "Diệp Đăng Khoa",
                ID = "0987654321",
                DateOfBirth = "01/01/1997",
                Room = "A307",
                DateIn ="1/2/2017",
                DateOut ="2/1/2017",
                Bill = 1234523431,
                Phone ="0947829292",
                Note =""
            });
            items.Add(new Customers()
            {
                IDCus = "02",
                Name = "Nhìn cái éo gì",
                ID = "0987654321",
                DateOfBirth = "01/01/1997",
                Room = "C305",
                DateIn = "1/2/2017",
                DateOut = "2/1/2017",
                Bill = 999999999,
                Phone = "0947829292",
                Note = ""
            });
            lv_Customer.ItemsSource=items;

            view = (CollectionView)CollectionViewSource.GetDefaultView(lv_Customer.ItemsSource);
            view.Filter = UserFilter;
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                ("Name",System.ComponentModel.ListSortDirection.Ascending));
        }

        private void changed(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_Customer.ItemsSource).Refresh();
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txt_filter.Text))
                return true;
            if(search.Equals(listSearch[0]))
                return ((item as Customers).IDCus.IndexOf(txt_filter.Text,StringComparison.OrdinalIgnoreCase)>=0);
            if(search.Equals(listSearch[1]))
                return ((item as Customers).Name.IndexOf(txt_filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            return ((item as Customers).Room.IndexOf(txt_filter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listSearch = new List<string>() { "Tìm kiếm theo mã khách hàng", "Tìm kiếm theo tên khách hàng", "Theo phòng" };
            cb_search.ItemsSource = listSearch;
            listSorting= new List<string>() { "Sắp xếp theo tên", "Sắp xếp theo hóa đơn tăng dần", "Sắp xếp theo hóa đơn giảm dần" };
            cb_sorting.ItemsSource = listSorting;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            search = cb_search.SelectedValue.ToString();
            view.Filter = UserFilter;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu(name);
            menu.Show();
            this.Close();
        }

        private void selectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            String sorting = cb_sorting.SelectedValue.ToString();
            if (sorting.Equals(listSorting[0]))
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Name", System.ComponentModel.ListSortDirection.Ascending));
            }
            else if (sorting.Equals(listSorting[1]))
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Bill", System.ComponentModel.ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Bill", System.ComponentModel.ListSortDirection.Descending));
            }
        }
    }
    //tạo demo đối tượng demo thôi
    //lúc dùng dữ liệu thật cần tạo đối tượng bên project dataObjectTranslation
    //viết constructor,getter, setter ra đề phòng lỗi
    //viết các phương thức mượn, trả, đặt dịch vụ cho đối tượng khách hàng
    public class Customers
    {
        public string IDCus { get; set; }
        public string Name { get; set; }
        public string ID { get; set; }
        public string DateOfBirth { get; set; }
        public string Room{ get; set; }
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public long Bill { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}
