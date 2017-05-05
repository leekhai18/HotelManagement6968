using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DataAccessLayer;
using System.Windows.Data;

namespace BusinessLogicLayer
{
    public class RoomBus
    {
        private RoomBus() { }

        private static RoomBus instance;

        public static RoomBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new RoomBus();
                return instance;
            }
        }
        public void View(ListView lv_Room)
        {
            Room.Instance.View(lv_Room);
        }
        public bool UserFilter(object item, List<String> listSearch, String searching, String keyWord)
        {
            String ID = (String)item.GetType().GetProperty("ID").GetValue(item,null);
            String Kind = (String)item.GetType().GetProperty("Kind").GetValue(item, null);
            String Status = (String)item.GetType().GetProperty("Status").GetValue(item, null);
            if (String.IsNullOrEmpty(keyWord))
                return true;
            if (searching.Equals(listSearch[0]))
                return (ID.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            if (searching.Equals(listSearch[1]))
                return (Kind.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);
            return (Status.IndexOf(keyWord, StringComparison.OrdinalIgnoreCase) >= 0);

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
        public void Book(string ID)
        {
            Room.Instance.Book(ID);
        }

        //public List<string> Edit(Button view)
        //{
        //    String Image = (String)view.DataContext.GetType().GetProperty("Image").GetValue(view.DataContext, null);
        //    String ID = (String)view.DataContext.GetType().GetProperty("ID").GetValue(view.DataContext, null);
        //    String Price = (String)view.DataContext.GetType().GetProperty("Price").GetValue(view.DataContext, null);
        //    String Kind = (String)view.DataContext.GetType().GetProperty("Kind").GetValue(view.DataContext, null);
        //    String Status = (String)view.DataContext.GetType().GetProperty("Status").GetValue(view.DataContext, null);
        //    List<String> list = new List<string>();
        //    list.Add(Image);
        //    list.Add(ID);
        //    list.Add(Price);
        //    list.Add(Kind);
        //    list.Add(Status);
        //    return list;
        //}
        
    }
}
