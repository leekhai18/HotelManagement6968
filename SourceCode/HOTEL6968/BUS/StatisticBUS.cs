using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class StatisticBUS
    {
        BillDAL billDAL = new BillDAL();
        int mm;
        int yyyy;

        public StatisticBUS() { mm = 0; }
        public StatisticBUS(int month, int year)
        {
            mm = month;
            yyyy = year;
        }

        public List<BillViewModel> TransactionHistory
        {
            get
            {
                if (mm == 0)
                    return billDAL.GetListBill().Where(p => p.TongTien != null).ToList();

                return billDAL.GetListBill().Where(p => p.TongTien != null && p.ThoiGianTra.Value.Month == mm && p.ThoiGianTra.Value.Year == yyyy).ToList();
            }
        }

        public string GetRevenueService
        {
            get
            {
                decimal revenue = 0;

                for (int i = 0; i < TransactionHistory.Count; i++)
                {
                    revenue += (decimal)TransactionHistory[i].TongGiaDichVu;
                }

                return revenue.ToString("0,0");
            }
        }

        public string GetRevenueRoom
        {
            get
            {
                decimal revenue = 0;

                for (int i = 0; i < TransactionHistory.Count; i++)
                {
                    revenue += (decimal)TransactionHistory[i].TongGiaPhong;
                }

                return revenue.ToString("0,0");
            }
        }

        public string GetTotalRevenue
        {
            get
            {
                decimal revenue = 0;

                for (int i = 0; i < TransactionHistory.Count; i++)
                {
                    revenue += (decimal)TransactionHistory[i].TongTien;
                }

                return revenue.ToString("0,0");
            }
        }
    }
}
