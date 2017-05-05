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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        CollectionView viewRoom;
        List<String> listSearchRoom, listSortingRoom;
        String searchingRoom;

        CollectionView viewService;
        List<String> listSearchService, listSortingService;
        String searchingService;

        CollectionView view;
        List<String> listSearch, listSorting;
        String searching;

        CollectionView viewStaff;
        List<String> listSearchStaff, listSortingStaff;
        String searchingStaff;

        private string ID;
        public Menu(List<String> Message) : this()
        {
            StaffBus.Instance.Changed(lv_Staff, Message);
        }
        public Menu(string Message): this()
        {
            ID = Message;
            addControl();
        }
        public Menu()
        {
            InitializeComponent();
            if (ID != null)
                addControl();

            CustomerBus.Instance.View(lv_Customer);

            view = (CollectionView)CollectionViewSource.GetDefaultView(lv_Customer.ItemsSource);
            view.Filter = UserFilter;
            view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                ("Name", System.ComponentModel.ListSortDirection.Ascending));

            StaffBus.Instance.View(lv_Staff);

            viewStaff = (CollectionView)CollectionViewSource.GetDefaultView(lv_Staff.ItemsSource);
            viewStaff.Filter = UserFilterStaff;
            viewStaff.SortDescriptions.Add(new System.ComponentModel.SortDescription
                ("IDSta", System.ComponentModel.ListSortDirection.Ascending));

            ServiceBus.Instance.View(lv_Service);

            viewService = (CollectionView)CollectionViewSource.GetDefaultView(lv_Service.ItemsSource);
            viewService.Filter = UserFilterService;
            viewService.SortDescriptions.Add(new System.ComponentModel.SortDescription
                ("Name", System.ComponentModel.ListSortDirection.Ascending));

            RoomBus.Instance.View(lv_Room);

            viewRoom = (CollectionView)CollectionViewSource.GetDefaultView(lv_Room.ItemsSource);
            viewRoom.Filter = UserFilterRoom;
            viewRoom.SortDescriptions.Add(new System.ComponentModel.SortDescription
                ("IDRoom", System.ComponentModel.ListSortDirection.Ascending));

        }
        // Khởi tạo bố trí window theo phân quyền tài khoản
        public void addControl()
        {
            if (!AccountBus.Instance.TestBenefit(ID))
            {
                sta_Cus.Visibility = Visibility.Visible;
                sta_Room.Visibility = Visibility.Visible;
                sta_Ser.Visibility = Visibility.Visible;

                gri_room.Visibility = Visibility.Visible;
            }

            else
            {
                sta_staff.Visibility = Visibility.Visible;
                sta_rev.Visibility = Visibility.Visible;
                gri_rev.Visibility = Visibility.Visible;
            }
        }
        // khởi tạo các combobox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listSearch = new List<string>() { "Tìm kiếm theo mã khách hàng", "Tìm kiếm theo tên khách hàng", "Theo phòng" };
            cb_search.ItemsSource = listSearch;
            listSorting = new List<string>() { "Sắp xếp theo tên", "Sắp xếp theo hóa đơn tăng dần", "Sắp xếp theo hóa đơn giảm dần" };
            cb_sorting.ItemsSource = listSorting;

            listSearchStaff = new List<string>() { "Tìm kiếm theo mã nhân viên", "Tìm kiếm theo tên nhân viên", "Theo chức vụ" };
            cb_searchStaff.ItemsSource = listSearchStaff;
            listSortingStaff = new List<string>() { "Sắp xếp theo mã nhân viên", "Sắp xếp theo lương tăng dần", "Sắp xếp theo lương giảm dần" };
            cb_sortingStaff.ItemsSource = listSortingStaff;

            listSearchRoom = new List<string>() { "Tìm kiếm theo mã phòng", "Tìm kiếm loại phòng", "Theo tình trạng" };
            cb_searchRoom.ItemsSource = listSearchRoom;
            listSortingRoom = new List<string>() { "Sắp xếp theo mã phòng", "Sắp xếp theo giá tăng dần", "Sắp xếp theo giá giảm dần" };
            cb_sortingRoom.ItemsSource = listSortingRoom;

            listSearchService = new List<string>() { "Tìm kiếm theo tên dịch vụ", "Tìm kiếm giá dịch vụ", "Theo khuyến mãi" };
            cb_searchService.ItemsSource = listSearchService;
            listSortingService = new List<string>() { "Sắp xếp theo tên dịch vụ", "Sắp xếp theo giá tăng dần", "Sắp xếp theo giá giảm dần" };
            cb_sortingService.ItemsSource = listSortingService;
            gri_Cus.Visibility = Visibility.Hidden;

        }
        // viết các hàm cho 3 button đóng, thu phóng và ẩn cửa sổ
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

        // các hàm của grid phòng
        private bool UserFilterRoom(object item)
        {
            return RoomBus.Instance.UserFilter(item, listSearchRoom, searchingRoom, txt_filterRoom.Text);
        }
        private void TouchDownBookRoom(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            button.Style = this.Resources["Book2"] as Style;
        }

        private void TouchUpBookRoom(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            button.Style = this.Resources["Book1"] as Style;
            String ID = (String)button.DataContext.GetType().GetProperty("ID").GetValue(button.DataContext, null);
            BookRoom edit = new BookRoom(ID);
            edit.ShowDialog();
            RoomBus.Instance.View(lv_Room);
        }
        private void SelectionChangedRoom(object sender, SelectionChangedEventArgs e)
        {
            searchingRoom = cb_searchRoom.SelectedValue.ToString();
            viewRoom.Filter = UserFilterRoom;
        }
        private void selectionChanged1Room(object sender, SelectionChangedEventArgs e)
        {
            RoomBus.Instance.Sort(viewRoom, listSortingRoom, cb_sortingRoom.SelectedValue.ToString());
        }
        private void changedRoom(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_Room.ItemsSource).Refresh();
        }

        //Các hàm của grid dịch vụ
        private bool UserFilterService(object item)
        {
            return ServiceBus.Instance.UserFilter(item, listSearchService, searchingService, txt_filterService.Text);
        }
        
        private void changedService(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_Service.ItemsSource).Refresh();
        }

        private void SelectionChangedSer(object sender, SelectionChangedEventArgs e)
        {
            searchingService = cb_searchService.SelectedValue.ToString();
            viewService.Filter = UserFilterService;
        }

        private void selectionChanged1Ser(object sender, SelectionChangedEventArgs e)
        {
            ServiceBus.Instance.Sort(viewService, listSortingService, cb_sortingService.SelectedValue.ToString());
        }
        private void TouchDownOrder(object sender, MouseButtonEventArgs e)
        {
            btn_order.Style = this.Resources["Order2"] as Style;
        }

        private void TouchUpOrder(object sender, MouseButtonEventArgs e)
        {
            btn_order.Style = this.Resources["Order1"] as Style;
            OrderService order = new OrderService();
            order.ShowDialog();
        }
        // các hàm của grid nhân viên
        public bool UserFilterStaff(object item)
        {
            return StaffBus.Instance.UserFilter(item, listSearchStaff, searchingStaff, txt_filterStaff.Text);
        }
        private void EditStaff(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            List<String> item = StaffBus.Instance.Edit(button);
            StaffEditer edit = new StaffEditer(item);
            edit.Show();
            this.Close();
        }
        private void SelectionChangedStaff(object sender, SelectionChangedEventArgs e)
        {
            searchingStaff = cb_searchStaff.SelectedValue.ToString();
            viewStaff.Filter = UserFilterStaff;
        }
        private void selectionChanged1Staff(object sender, SelectionChangedEventArgs e)
        {
            StaffBus.Instance.Sort(viewStaff, listSortingStaff, cb_sortingStaff.SelectedValue.ToString());
        }
        private void changedStaff(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_Staff.ItemsSource).Refresh();
        }
        private void TouchDown2(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            button.Style = this.Resources["RoundCorner0"] as Style;
        }

        private void TouchUp2(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            button.Style = this.Resources["RoundCorner"] as Style;
            //List<String> item = StaffBus.Instance.Edit(button);
            StaffEditer edit = new StaffEditer();
            edit.ShowDialog();
        }
        //các hàm của grid tài khoản
        private void logOut(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        //các hàm của grid khách hàng
        public bool UserFilter(object item)
        {
            return CustomerBus.Instance.UserFilter(item, listSearch, searching, txt_filter.Text);
        }
        private void changed(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_Customer.ItemsSource).Refresh();
        }
        
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searching = cb_search.SelectedValue.ToString();
            view.Filter = UserFilter;
        }
        private void Edit(object sender, RoutedEventArgs e)
        {
            List<String> item = CustomerBus.Instance.Edit(lv_Customer);
            CustomerEditer edit = new CustomerEditer(item);
            edit.ShowDialog();
        }

        private new void TouchDown(object sender, MouseButtonEventArgs e)
        {
            btn_edit.Style = this.Resources["RoundCorner0"] as Style;
        }

        private new void TouchUp(object sender, MouseButtonEventArgs e)
        {
            btn_edit.Style = this.Resources["RoundCorner"] as Style;
            List<String> item = CustomerBus.Instance.Edit(lv_Customer);
            CustomerEditer edit = new CustomerEditer(item);
            edit.ShowDialog();
        }
        private void selectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            CustomerBus.Instance.Sort(view, listSorting, cb_sorting.SelectedValue.ToString());
        }
        //các hàm của button xem nhân viên trên thanh công cụ
        private void TouchDownSta(object sender, MouseButtonEventArgs e)
        {
            btn_staff.Style = this.Resources["Staff2"] as Style;
            lb_staff.Foreground = this.Resources["Blue"] as Brush;
        }

        private void TouchUpSta(object sender, MouseButtonEventArgs e)
        {
            chk_staff.Visibility = Visibility.Visible;
            chk_rev.Visibility = Visibility.Hidden;
            btn_rev.Style = this.Resources["Revenue1"] as Style;
            lb_rev.Foreground = Brushes.White;
            lb_User.Foreground = Brushes.White;
            sta_staff.Background = this.Resources["BlackSoft"] as Brush;
            sta_rev.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_User.Background = this.Resources["BlackSoftMore"] as Brush;
            gri_staff.Visibility = Visibility.Visible;
            gri_rev.Visibility = Visibility.Hidden;
            gri_user.Visibility = Visibility.Hidden;
            lb_staff.Visibility = Visibility.Collapsed;
            lb_rev.Visibility = Visibility.Collapsed;
            lb_User.Visibility = Visibility.Collapsed;
        }

        //các hàm của button xem phòng trên thanh công cụ

        private void TouchDownRoom(object sender, MouseButtonEventArgs e)
        {
            btn_Room.Style = this.Resources["Room2"] as Style;
            lb_Room.Foreground = this.Resources["Blue"] as Brush;
        }

        private void TouchUpRoom(object sender, MouseButtonEventArgs e)
        {
            chk_Cus.Visibility = Visibility.Hidden;
            chk_room.Visibility = Visibility.Visible;
            chk_Ser.Visibility = Visibility.Hidden;
            btn_Cus.Style = this.Resources["Customer1"] as Style;
            btn_Ser.Style = this.Resources["Service1"] as Style;
            lb_Cus.Foreground = Brushes.White;
            lb_Ser.Foreground = Brushes.White;
            lb_User.Foreground = Brushes.White;
            sta_Room.Background = this.Resources["BlackSoft"] as Brush;
            sta_Ser.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_Cus.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_User.Background = this.Resources["BlackSoftMore"] as Brush;
            gri_Cus.Visibility = Visibility.Hidden;
            gri_service.Visibility = Visibility.Hidden;
            gri_user.Visibility = Visibility.Hidden;
            gri_room.Visibility = Visibility.Visible;
            lb_Cus.Visibility = Visibility.Collapsed;
            lb_Ser.Visibility = Visibility.Collapsed;
            lb_Room.Visibility = Visibility.Collapsed;
            lb_User.Visibility = Visibility.Collapsed;
        }


        //các hàm của button xem chi tiết trên thanh công cụ
        private void TouchDownDetail(object sender, MouseButtonEventArgs e)
        {
            btn_detail.Style = this.Resources["Detail2"] as Style;
        }

        private void TouchUpDetail(object sender, MouseButtonEventArgs e)
        {
            btn_detail.Style = this.Resources["Detail1"] as Style;
            if (lb_Ser.Visibility == Visibility.Collapsed && sta_Ser.Visibility==Visibility.Visible)
            {
                lb_Cus.Visibility = Visibility.Visible;
                lb_Ser.Visibility = Visibility.Visible;
                lb_Room.Visibility = Visibility.Visible;
                lb_User.Visibility = Visibility.Visible;
            }
            else if(lb_Ser.Visibility != Visibility.Collapsed && sta_Ser.Visibility == Visibility.Visible)
            {
                lb_Cus.Visibility = Visibility.Collapsed;
                lb_Ser.Visibility = Visibility.Collapsed;
                lb_Room.Visibility = Visibility.Collapsed;
                lb_User.Visibility = Visibility.Collapsed;
            }
            else if(lb_rev.Visibility == Visibility.Collapsed && sta_Ser.Visibility != Visibility.Visible)
            {
                lb_rev.Visibility = Visibility.Visible;
                lb_staff.Visibility = Visibility.Visible;
                lb_User.Visibility = Visibility.Visible;
            }
            else
            {
                lb_rev.Visibility = Visibility.Collapsed;
                lb_staff.Visibility = Visibility.Collapsed;
                lb_User.Visibility = Visibility.Collapsed;
            }
        }
        //các hàm của button xem tài khoản trên thanh công cụ
        private void TouchDownUser(object sender, MouseButtonEventArgs e)
        {
            lb_User.Foreground = this.Resources["Blue"] as Brush;
        }
        private void TouchUpUser(object sender, MouseButtonEventArgs e)
        {
            sta_User.Background = this.Resources["BlackSoft"] as Brush;
            lb_User.Visibility = Visibility.Collapsed;
            gri_user.Visibility = Visibility.Visible;
            if (sta_Ser.Visibility == Visibility.Visible)
            {
                chk_Cus.Visibility = Visibility.Hidden;
                chk_room.Visibility = Visibility.Hidden;
                chk_Ser.Visibility = Visibility.Hidden;
                btn_Cus.Style = this.Resources["Customer1"] as Style;
                btn_Ser.Style = this.Resources["Service1"] as Style;
                btn_Room.Style = this.Resources["Room1"] as Style;
                lb_Cus.Foreground = Brushes.White;
                lb_Ser.Foreground = Brushes.White;
                lb_Room.Foreground = Brushes.White;
                sta_Room.Background = this.Resources["BlackSoftMore"] as Brush;
                sta_Ser.Background = this.Resources["BlackSoftMore"] as Brush;
                sta_Cus.Background = this.Resources["BlackSoftMore"] as Brush;
                gri_Cus.Visibility = Visibility.Hidden;
                gri_room.Visibility = Visibility.Hidden;
                gri_service.Visibility = Visibility.Hidden;
                lb_Cus.Visibility = Visibility.Collapsed;
                lb_Ser.Visibility = Visibility.Collapsed;
                lb_Room.Visibility = Visibility.Collapsed;
            }
            else
            {
                chk_rev.Visibility = Visibility.Hidden;
                chk_staff.Visibility = Visibility.Hidden;
                btn_rev.Style = this.Resources["Revenue1"] as Style;
                btn_staff.Style = this.Resources["Staff1"] as Style;
                lb_rev.Foreground = Brushes.White;
                lb_staff.Foreground = Brushes.White;
                sta_rev.Background = this.Resources["BlackSoftMore"] as Brush;
                sta_staff.Background = this.Resources["BlackSoftMore"] as Brush;
                gri_rev.Visibility = Visibility.Hidden;
                gri_staff.Visibility = Visibility.Hidden;
                lb_rev.Visibility = Visibility.Collapsed;
                lb_staff.Visibility = Visibility.Collapsed;
            }
        }
        //các hàm của button xem dịch vụ trên thanh công cụ

        private void TouchDownSer(object sender, MouseButtonEventArgs e)
        {
            btn_Ser.Style = this.Resources["Service2"] as Style;
            lb_Ser.Foreground = this.Resources["Blue"] as Brush;
        }

        private void TouchUpSer(object sender, MouseButtonEventArgs e)
        {
            chk_Cus.Visibility = Visibility.Hidden;
            chk_room.Visibility = Visibility.Hidden;
            chk_Ser.Visibility = Visibility.Visible;
            btn_Cus.Style = this.Resources["Customer1"] as Style;
            btn_Room.Style = this.Resources["Room1"] as Style;
            lb_Cus.Foreground = Brushes.White;
            lb_Room.Foreground = Brushes.White;
            lb_User.Foreground = Brushes.White;
            sta_Ser.Background = this.Resources["BlackSoft"] as Brush;
            sta_Cus.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_Room.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_User.Background = this.Resources["BlackSoftMore"] as Brush;
            gri_service.Visibility = Visibility.Visible;
            gri_Cus.Visibility = Visibility.Hidden;
            gri_room.Visibility = Visibility.Hidden;
            gri_user.Visibility = Visibility.Hidden;
            lb_Cus.Visibility = Visibility.Collapsed;
            lb_Ser.Visibility = Visibility.Collapsed;
            lb_Room.Visibility = Visibility.Collapsed;
            lb_User.Visibility = Visibility.Collapsed;
        }
        //các hàm của button xem doanh thu trên thanh công cụ
        private void TouchDownRev(object sender, MouseButtonEventArgs e)
        {
            btn_rev.Style = this.Resources["Revenue2"] as Style;
            lb_rev.Foreground = this.Resources["Blue"] as Brush;
        }

        private void TouchUpRev(object sender, MouseButtonEventArgs e)
        {
            chk_staff.Visibility = Visibility.Hidden;
            chk_rev.Visibility = Visibility.Visible;
            btn_staff.Style = this.Resources["Staff1"] as Style;
            lb_staff.Foreground = Brushes.White;
            lb_User.Foreground = Brushes.White;
            sta_rev.Background = this.Resources["BlackSoft"] as Brush;
            sta_staff.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_User.Background = this.Resources["BlackSoftMore"] as Brush;
            gri_staff.Visibility = Visibility.Hidden;
            gri_rev.Visibility = Visibility.Visible;
            gri_user.Visibility = Visibility.Hidden;
            lb_staff.Visibility = Visibility.Collapsed;
            lb_rev.Visibility = Visibility.Collapsed;
            lb_User.Visibility = Visibility.Collapsed;
        }
        

        //các hàm của button xem khách hàng trên thanh công cụ
        private void TouchDownCus(object sender, MouseButtonEventArgs e)
        {
            btn_Cus.Style = this.Resources["Customer2"] as Style;
            lb_Cus.Foreground = this.Resources["Blue"] as Brush;
        }

        private void TouchUpCus(object sender, MouseButtonEventArgs e)
        {
            chk_Cus.Visibility = Visibility.Visible;
            chk_room.Visibility = Visibility.Hidden;
            chk_Ser.Visibility = Visibility.Hidden;
            btn_Ser.Style = this.Resources["Service1"] as Style;
            btn_Room.Style = this.Resources["Room1"] as Style;
            lb_Ser.Foreground = Brushes.White;
            lb_Room.Foreground = Brushes.White;
            lb_User.Foreground = Brushes.White;
            sta_Cus.Background = this.Resources["BlackSoft"] as Brush;
            sta_Ser.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_Room.Background = this.Resources["BlackSoftMore"] as Brush;
            sta_User.Background = this.Resources["BlackSoftMore"] as Brush;
            gri_Cus.Visibility = Visibility.Visible;
            gri_service.Visibility = Visibility.Hidden;
            gri_room.Visibility = Visibility.Hidden;
            gri_user.Visibility = Visibility.Hidden;
            lb_Cus.Visibility = Visibility.Collapsed;
            lb_Ser.Visibility = Visibility.Collapsed;
            lb_Room.Visibility = Visibility.Collapsed;
            lb_User.Visibility = Visibility.Collapsed;
        }
        // các hàm của 2 thanh công cụ
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
                btn_detail.Style = this.Resources["Detail1"] as Style;
                btn_edit.Style = this.Resources["RoundCorner"] as Style;
                btn_order.Style = this.Resources["Order1"] as Style;
                if (lb_User.Visibility == Visibility.Hidden)
                {
                    lb_User.Foreground = Brushes.White;
                }
                if (sta_Ser.Visibility == Visibility.Visible)
                {
                    if (chk_Cus.Visibility == Visibility.Hidden)
                    {
                        btn_Cus.Style = this.Resources["Customer1"] as Style;
                        lb_Cus.Foreground = Brushes.White;
                    }
                    if (chk_room.Visibility == Visibility.Hidden)
                    {
                        btn_Room.Style = this.Resources["Room1"] as Style;
                        lb_Room.Foreground = Brushes.White;
                    }
                    if (chk_Ser.Visibility == Visibility.Hidden)
                    {
                        btn_Ser.Style = this.Resources["Service1"] as Style;
                        lb_Ser.Foreground = Brushes.White;
                    }
                }
                else
                {
                    if (chk_rev.Visibility == Visibility.Hidden)
                    {
                        btn_rev.Style = this.Resources["Revenue1"] as Style;
                        lb_rev.Foreground = Brushes.White;
                    }
                    if (chk_staff.Visibility == Visibility.Hidden)
                    {
                        btn_staff.Style = this.Resources["Staff1"] as Style;
                        lb_staff.Foreground = Brushes.White;
                    }
                }
            }
        }
    }
}
