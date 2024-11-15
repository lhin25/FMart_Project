﻿using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class InvoiceService : GenericService<Invoice>, IInvoiceService
    {
        public InvoiceService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task<bool> Add(Invoice entity)
        {
            try
            {
                await GetRepository.InvoiceRepository.CreateAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override Task<bool> Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Invoice> Get(Expression<Func<Invoice, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Invoice>>? GetAll()
        {
            var invoices = await GetRepository.InvoiceRepository.GetAllAsync(includeProperties: "Customer,Staff");
            return invoices;
        }

        public async Task<int> GetNumberInvoices()
        {
            return await GetRepository.InvoiceRepository.GetNumberInvoices();
        }

        public override async Task<Pagination<Invoice>> GetPagination(int pageIndex, int pageSize)
        {
            var listInvoices = await GetAll();
            return await GetRepository.InvoiceRepository.ToPagination(listInvoices, pageIndex, pageSize);
        }

        public decimal GetProfit()
        {
            return GetRepository.InvoiceRepository.GetProfit();
        }

        public decimal GetRevenue()
        {
            return GetRepository.InvoiceRepository.GetRevenue();
        }

        public override Task<bool> Update(Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
