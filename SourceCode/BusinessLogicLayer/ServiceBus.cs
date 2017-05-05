using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DataAccessLayer;
using System.Windows.Controls;

namespace BusinessLogicLayer
{
    public class ServiceBus
    {
        private ServiceBus() { }

        private static ServiceBus instance;

        public static ServiceBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceBus();
                return instance;
            }
        }
        public void View(ListView lv_Service)
        {
            Service.Instance.View(lv_Service);
        }
        public bool UserFilter(object item, List<String> listSearch, String searching, String keyWord)
        {
            String Name = (String)item.GetType().GetProperty("Name").GetValue(item, null);
            //long Price = (long)item.GetType().GetProperty("Price").GetValue(item, null);
            //String Sale = (String)item.GetType().GetProperty("Sale").GetValue(item, null);
            if (String.IsNullOrEmpty(keyWord))
                return true;
            //if (searching.Equals(listSearch[0]))
                return (Name.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            //if (searching.Equals(listSearch[1]))
                //return (Price.ToString().IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            //return (Sale.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);

        }
        public void Sort(CollectionView view, List<String> listSorting, String sorting)
        {
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
                    ("Price", System.ComponentModel.ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Price", System.ComponentModel.ListSortDirection.Descending));
            }
        }
        //public List<String> Edit(Button view)
        //{
        //    Service cus = view.DataContext as Staff;
        //    List<String> list = new List<string>();
        //    list.Add(cus.IDSta);
        //    list.Add(cus.Name);
        //    list.Add(cus.ID);
        //    list.Add(cus.Sex);
        //    list.Add(cus.DateOfBirth);
        //    list.Add(cus.Phone);
        //    list.Add(cus.Position);
        //    list.Add(cus.Salary.ToString());
        //    return list;
        //}
        //public List<String> Changed(ListView view, List<String> list)
        //{
        //    Staff cus = (Staff)view.Items.GetItemAt(int.Parse(list[0]));
        //    cus.IDSta = list[1].ToString();
        //    cus.Name = list[2].ToString();
        //    cus.ID = list[3].ToString();
        //    cus.Sex = list[4].ToString();
        //    cus.DateOfBirth = list[5].ToString();
        //    cus.Phone = list[6].ToString();
        //    cus.Position = list[7].ToString();
        //    cus.Salary = long.Parse(list[8].ToString());
        //    return list;
        //}
    }
}

