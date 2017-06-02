using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class BillDetailBUS
    {
        BillDetailDAL billDetailDAL = new BillDetailDAL();
        string idBillSelected = "";

        public BillDetailBUS() { }
        public BillDetailBUS(string idBill)
        {
            idBillSelected = idBill;
        }

        public List<BillDetailViewModel> GetListBillDetail
        {
            get
            {
                return billDetailDAL.GetBillDetail(idBillSelected);
            }
        }

        public decimal TotalPriceOfBill
        {
            get
            {
                return billDetailDAL.TotalPriceOfBill(idBillSelected);
            }
        }

        public void AddDetail(string idBill, string idService, int quantity)
        {
            billDetailDAL.AddDetail(idBill, idService, quantity);
        }
    }
}
