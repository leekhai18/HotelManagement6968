using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace HOTEL6968.BUS
{
    public class ServiceBUS : NotifyPropertyChanged
    {
        ServiceDAL serviceDAL = new ServiceDAL();

        public List<ServiceViewModel> ListFoods
        {
            get
            {
                return serviceDAL.GetListFoods();
            }
        }

        public List<ServiceViewModel> ListGames
        {
            get
            {
                return serviceDAL.GetListGames();
            }
        }

        public List<ServiceViewModel> ListRests
        {
            get
            {
                return serviceDAL.GetListRests();
            }
        }

        public bool SearchFilter(object obj, string textChange)
        {
            if (String.IsNullOrEmpty(textChange))
                return true;
            else
                return ((obj as ServiceViewModel).TenDichVu.IndexOf(textChange, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static String GetDestinationPath(string filename, string foldername)
        {
            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            appStartPath = String.Format(appStartPath + "\\{0}\\" + filename, foldername);

            return appStartPath;
        }

        //public void AddNewService(string id, string name, string idKind, string charges, string information, string imageSource)
        //{
        //    string imageName = System.IO.Path.GetFileName(filepath);
        //    string destinationPath = GetDestinationPath(imageName, "YourFolderName");

        //    File.Copy(filepath, destinationPath, true);

        //    using (var db = new QuanLyKhachSanEntities())
        //    {
        //        db.DICH_VU.Add(new DICH_VU() { MaDichVu = id, TenDichVu = name, MaLoaiDichVu = idKind, GiaDichVu = charges, GhiChu = information, NguonAnh = imageSource, MaTinhTrang = 4 });

        //        db.SaveChanges();
        //    }
        //}
    }
}
