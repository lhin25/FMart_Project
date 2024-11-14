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
    public class SupplierService : GenericService<Supplier>, ISupplierService
    {
        public SupplierService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task<bool> Add(Supplier entity)
        {
            try
            {
                var isExisted = await GetRepository.SupplierRepository.GetById(entity.SupplierId);
                if (isExisted != null)
                {
                    return false;
                }
                await GetRepository.SupplierRepository.CreateAsync(entity);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("An error has occured.");
            }
        }

        public override Task<bool> Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Supplier> Get(Expression<Func<Supplier, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Supplier>>? GetAll()
        {
            var suppliers = await GetRepository.SupplierRepository.GetAllAsync();
            return suppliers;
        }

        public override async Task<Pagination<Supplier>> GetPagination(int pageIndex, int pageSize)
        {
            var listSuppliers = await GetAll();
            return await GetRepository.SupplierRepository.ToPagination(listSuppliers, pageIndex, pageSize);
        }

        public override async Task<bool> Update(Supplier entity)
        {
            try
            {
                var cate = await GetRepository.SupplierRepository.GetAsync(filter: cte => cte.SupplierId == entity.SupplierId);
                if (cate == null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.SupplierRepository.UpdateAsync(cate);
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("An error has occured.");
            }
        }
    }
}
