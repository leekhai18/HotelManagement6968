using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class BillBUS
    {
        BillDAL billDAL = new BillDAL();

        public void InitBill(string idCustomer, string idRoom, Decimal rateRoomPerDay, DateTime bookingDay)
        {
            billDAL.InitBill(idCustomer, idRoom, rateRoomPerDay, bookingDay);
        }
    }
}
