using DataAccess.Models;
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
    public class InvoiceDetailService : GenericService<InvoiceDetail>, IInvoiceDetailService
    {
        public InvoiceDetailService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task<bool> Add(InvoiceDetail entity)
        {
            try
            {
                await GetRepository.InvoiceDetailRepository.CreateAsync(entity);
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

        public override Task<InvoiceDetail> Get(Expression<Func<InvoiceDetail, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<InvoiceDetail>>? GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Pagination<InvoiceDetail>> GetPagination(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(InvoiceDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
