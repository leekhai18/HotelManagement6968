using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class RuleBUS
    {
        RoomDAL roomDAL = new RoomDAL();

        public void UpdateRateRoom(string idKindOfRoom, decimal rate)
        {
            roomDAL.UpdateRateRoom(idKindOfRoom, rate);
        }

        public string RateRoom(string idKindOfRoom)
        {
            return roomDAL.RateRoom(idKindOfRoom).ToString("0,0");
        }

        public void UpdateSurchage(string surchageNumber, string surchageForeign)
        {
            roomDAL.UpdateSurchage(surchageNumber, surchageForeign);
        }

        public string SurchageNumber
        {
            get
            {
                return roomDAL.SurchageNumber();
            }
        }

        public string SurchageForeign
        {
            get
            {
                return roomDAL.SurchageForeign();
            }
        }

    }
}
