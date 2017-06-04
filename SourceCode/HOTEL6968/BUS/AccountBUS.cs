using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class AccountBUS
    {
        AccountDAL accountDAL = new AccountDAL();

        public void Create(string id, string pass)
        {
            accountDAL.Create(id, pass);
        }

        public bool IsAvailable(string id, string pass)
        {
            return accountDAL.IsAvailable(id, pass);
        }
    }
}
