using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968.BUS;
using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
    /// Interaction logic for StatisticsManage.xaml
    /// </summary>
    public partial class StatisticsManage : UserControl
    {
        StatisticBUS statisticBUS = new StatisticBUS();

        public StatisticsManage()
        {
            InitializeComponent();
            this.DataContext = statisticBUS;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(dataGridHistory.Items);
            view.Filter = SearchFilter;
        }

        private void StatisticsManage_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDataContext();
        }

        private void RefreshDataContext()
        {
            this.DataContext = null;
            this.DataContext = statisticBUS;
        }

        private bool SearchFilter(object obj)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                return true;
            else
                return ((obj as BillViewModel).TenKhachHang.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0
                    || (obj as BillViewModel).CMND.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0
                    || (obj as BillViewModel).MaPhong.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dataGridHistory.ItemsSource).Refresh();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (cmbMonth.Text != "" && txtYear.Text != "")
            {
                this.DataContext = null;
                this.DataContext = new StatisticBUS(Convert.ToInt16(cmbMonth.Text.ToString()), Convert.ToInt16(txtYear.Text));

                if (resultFillter.Visibility == Visibility.Hidden)
                {
                    resultFillter.Visibility = Visibility.Visible;
                }
            }
            else
            {
                ModernDialog.ShowMessage("Chọn tháng và năm", "Thông báo", MessageBoxButton.OK);
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            if (resultFillter.Visibility == Visibility.Visible)
            {
                resultFillter.Visibility = Visibility.Hidden;
            }

            // Create the print dialog object and set options
            PrintDialog pDialog = new PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            // Display the dialog. This returns true if the user presses the Print button.
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                //XpsDocument xpsDocument = new XpsDocument("C:\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
                //FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                //pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            }
        }
    }
}
