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
    /// Interaction logic for Food.xaml
    /// </summary>
    public partial class Food : Window
    {
        CollectionView viewService;
        List<String> listSearchService, listSortingService;
        String searchingService;
        public Food()
        {
            InitializeComponent();

            ServiceBus.Instance.View(lv_Service);

            viewService = (CollectionView)CollectionViewSource.GetDefaultView(lv_Service.ItemsSource);
            viewService.Filter = UserFilterService;
            viewService.SortDescriptions.Add(new System.ComponentModel.SortDescription
                ("Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void changedService(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lv_Service.ItemsSource).Refresh();
        }
        private bool UserFilterService(object item)
        {
            return ServiceBus.Instance.UserFilter(item, listSearchService, searchingService, txt_filterService.Text);
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
            listSearchService = new List<string>() { "Tìm kiếm theo tên dịch vụ", "Tìm kiếm giá dịch vụ", "Theo khuyến mãi" };
            cb_searchService.ItemsSource = listSearchService;
            listSortingService = new List<string>() { "Sắp xếp theo tên dịch vụ", "Sắp xếp theo giá tăng dần", "Sắp xếp theo giá giảm dần" };
            cb_sortingService.ItemsSource = listSortingService;
        }
        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {

        }
        private void Move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TouchDownCancel(object sender, MouseButtonEventArgs e)
        {
            btn_cancel.Style = this.Resources["Cancel2"] as Style;
        }

        private void TouchUpCancel(object sender, MouseButtonEventArgs e)
        {
            btn_cancel.Style = this.Resources["Cancel1"] as Style;
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void MaximizeClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
