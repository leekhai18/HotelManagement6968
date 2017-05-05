using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Windows.Controls;
using System.Windows.Data;

namespace BusinessLogicLayer
{
    public class StaffBus
    {
        private StaffBus() { }

        private static StaffBus instance;

        public static StaffBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new StaffBus();
                return instance;
            }
        }
        public void View(ListView lv_Staff)
        {
            Staff.Instance.View(lv_Staff);
        }
        public bool UserFilter(object item, List<String> listSearch, String searching, String keyWord)
        {
            String IDSta = (String)item.GetType().GetProperty("IDSta").GetValue(item, null);
            String Name = (String)item.GetType().GetProperty("Name").GetValue(item, null);
            String Position = (String)item.GetType().GetProperty("Position").GetValue(item, null);
            if (String.IsNullOrEmpty(keyWord))
                return true;
            if (searching.Equals(listSearch[0]))
                return (IDSta.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            if (searching.Equals(listSearch[1]))
                return (Name.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            return (Position.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        public void Sort(CollectionView view, List<String> listSorting, String sorting)
        {
            if (sorting.Equals(listSorting[0]))
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("IDStaff", System.ComponentModel.ListSortDirection.Ascending));
            }
            else if (sorting.Equals(listSorting[1]))
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Salary", System.ComponentModel.ListSortDirection.Ascending));
            }
            else
            {
                view.SortDescriptions.RemoveAt(0);
                view.SortDescriptions.Add(new System.ComponentModel.SortDescription
                    ("Salary", System.ComponentModel.ListSortDirection.Descending));
            }
        }
        public List<String> Edit(Button view)
        {   //lấy từ db
            //String IDSta = (String)view.DataContext.GetType().GetProperty("Name").GetValue(view.DataContext, null);
            //String Name = (String)view.DataContext.GetType().GetProperty("Name").GetValue(view.DataContext, null);
            //String Name = (String)view.DataContext.GetType().GetProperty("Name").GetValue(view.DataContext, null);

            List<String> list = new List<string>();
            //list.Add(cus.IDSta);
            //list.Add(cus.Name);
            //list.Add(cus.ID);
            //list.Add(cus.Sex);
            //list.Add(cus.DateOfBirth);
            //list.Add(cus.Phone);
            //list.Add(cus.Position);
            //list.Add(cus.Salary.ToString());
            return list;
        }
        public List<String> Changed(ListView view, List<String> list)
        {
            Staff cus = (Staff)view.Items.GetItemAt(int.Parse(list[0]));
            //cus.IDSta = list[1].ToString();
            //cus.Name = list[2].ToString();
            //cus.ID = list[3].ToString();
            //cus.Sex = list[4].ToString();
            //cus.DateOfBirth = list[5].ToString();
            //cus.Phone = list[6].ToString();
            //cus.Position = list[7].ToString();
            //cus.Salary = long.Parse(list[8].ToString());
            return list;
        }
    }
}
