using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class StaffBUS
    {
        StaffDAL staffDAL = new StaffDAL();

        public List<StaffViewModel> ListStaffs
        {
            get
            {
                return staffDAL.GetListStaffs();
            }
        }

        public bool SearchFilter(object obj, string textChange)
        {
            if (String.IsNullOrEmpty(textChange))
                return true;
            else
                return ((obj as StaffViewModel).TenNhanVien.IndexOf(textChange, StringComparison.OrdinalIgnoreCase) >= 0
                    || (obj as StaffViewModel).MaNhanVien.IndexOf(textChange, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
