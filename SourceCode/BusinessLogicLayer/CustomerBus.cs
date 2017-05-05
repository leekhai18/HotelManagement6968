using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CustomerBus
    {
        private CustomerBus() { }

        private static CustomerBus instance;

        public static CustomerBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerBus();
                return instance;
            }
        }
        public void View(ListView lv_Customer)
        {
            Customer.Instance.View(lv_Customer);
        }
        public bool UserFilter(object item, List<String> listSearch, String searching,String keyWord)
        {
            String IDCus = (String)item.GetType().GetProperty("IDCus").GetValue(item, null);
            String Name = (String)item.GetType().GetProperty("Name").GetValue(item, null);
            //String DateIn = (String)item.GetType().GetProperty("DateIn").GetValue(item, null);
            if (String.IsNullOrEmpty(keyWord))
                return true;
            if (searching.Equals(listSearch[0]))
                return (IDCus.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            //if (searching.Equals(listSearch[1]))
                return (Name.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            //return (DateIn.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
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
                    ("Bill", System.ComponentModel.ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Bill", System.ComponentModel.ListSortDirection.Descending));
            }
        }
        public List<String> Edit(ListView view)
        {
            String IDCus = (String)view.SelectedItems[0].GetType().GetProperty("IDCus").GetValue(view.SelectedItems[0], null);
            String Name = (String)view.SelectedItems[0].GetType().GetProperty("Name").GetValue(view.SelectedItems[0], null);
            String ID = (String)view.SelectedItems[0].GetType().GetProperty("ID").GetValue(view.SelectedItems[0], null);
            String Phone = (String)view.SelectedItems[0].GetType().GetProperty("Phone").GetValue(view.SelectedItems[0], null);
            Nullable<System.DateTime> DateOfBirth = (Nullable<System.DateTime>)view.SelectedItems[0].GetType().GetProperty("DateOfBirth").GetValue(view.SelectedItems[0], null);
            List<String> list=new List<string>();
            list.Add(IDCus);
            list.Add(Name);
            list.Add(ID);
            list.Add(Phone);
            list.Add(DateOfBirth.ToString());

            return list;
        }
        public List<String> Changed(ListView view, List<String> list)
        {
            Customer cus = (Customer)view.Items.GetItemAt(int.Parse(list[0]));
            
            return list;
        }
        public void Add(List<string> list)
        {
            Customer.Instance.Add(list);
        }
    }
}
