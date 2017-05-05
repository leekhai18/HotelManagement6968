﻿using HOTEL6968.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL6968.BUS
{
    public class CustomerBUS
    {
        CustomerDAL customerDAL = new CustomerDAL();

        public List<CustomerViewModel> ListKhachHang
        {
            get
            {
                return customerDAL.GetListKhachHang();
            }
        }
    }
}
