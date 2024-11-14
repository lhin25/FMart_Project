﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IInvoiceService : IGenericService<Invoice>
    {
        public Task<int> GetNumberInvoices();
        public decimal GetRevenue();
        public decimal GetProfit();
    }
}
