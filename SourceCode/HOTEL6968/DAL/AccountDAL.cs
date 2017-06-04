using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.DAL
{
    public class AccountDAL
    {
        public void Create(string id, string pass)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.TAI_KHOAN.Add(new TAI_KHOAN() { MaNhanVien = id, MatKhau = pass });

                db.SaveChanges();
            }
        }

        public bool IsAvailable(string id, string pass)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                foreach (var acc in db.TAI_KHOAN)
                {
                    if (id == acc.MaNhanVien)
                        if (pass == acc.MatKhau)
                            return true;
                }
            }

            return false;
        }
    }
}
