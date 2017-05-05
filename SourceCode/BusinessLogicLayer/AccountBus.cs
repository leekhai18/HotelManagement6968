using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AccountBus
    {
        private AccountBus() { }

        private static AccountBus instance;

        public static AccountBus Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountBus();
                return instance;
            }
        }
        public bool TestAccount(string ID, string Password)
        {
            return Account.Instance.TestAccount(ID,Password);
        }
        public bool TestBenefit(string ID)
        {
            return Account.Instance.TestBenefit(ID);
        }
    }
}
