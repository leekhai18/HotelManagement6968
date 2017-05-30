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

#region StaffManager
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

        #endregion

        #region StaffAdd
        public void AddNewStaff(string id, string name, string identityCard, string address, string email, string gender, string idPos, DateTime birthday, string phoneNumber, string imageSource)
        {
            using (var db = new QuanLyKhachSanEntities())
            {
                db.NHAN_VIEN.Add(new NHAN_VIEN() { MaNhanVien = id, TenNhanVien = name, CMND = identityCard, DiaChi = address, Email = email, GioiTinh = gender, MaChucVu = idPos,
                                                    NgaySinh = birthday, SDT = phoneNumber, NguonAnh = imageSource });

                db.SaveChanges();
            }
        }
        #endregion
    }
}
