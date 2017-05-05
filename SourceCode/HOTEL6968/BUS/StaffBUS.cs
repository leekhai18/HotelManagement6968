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

        public List<StaffViewModel> ListNhanVien
        {
            get
            {
                return staffDAL.GetListNhanVien();
            }
        }
    }
}
