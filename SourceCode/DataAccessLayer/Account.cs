using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Account
    {
        private Account() { }

        private static Account instance;
        public static Account Instance
        {
            get
            {
                if (instance == null)
                    instance = new Account();
                return instance;
            }
        }


        public bool TestAccount(string ID, string Password)
        {
            HotelEntities db = new HotelEntities();
            var query = from a in db.TAI_KHOAN
                        select a;
            List<TAI_KHOAN> acc = new List<TAI_KHOAN>();
            acc = query.ToList<TAI_KHOAN>();
            for(int i=0;i<acc.Count;i++)
            {
                if (acc[i].MaNhanVien.Equals(ID) && acc[i].MatKhau.Equals(Password))
                    return true;
            }
            return false;
        }
        public bool TestBenefit(string ID)
        {
            HotelEntities db = new HotelEntities();
            var query = from a in db.NHAN_VIEN
                        where a.MaNhanVien.Equals(ID)
                        select a;
            List<NHAN_VIEN> acc = new List<NHAN_VIEN>();
            acc = query.ToList<NHAN_VIEN>();
            if (acc[0].MaChucVu.Equals("CV03"))
                return true;
            return false;
        }
    }
}
