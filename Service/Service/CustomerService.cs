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
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        public CustomerService(IGetRepository getRepository) : base(getRepository) { }

        public override Task Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override async Task<ICollection<Customer>>? GetAll(Expression<Func<Customer, bool>>? filter = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null, string includeProperties = "")
        {
            var customers = await GetRepository.CustomerRepository.GetAllAsync(filter, orderBy, includeProperties);
            return customers;
        }

        public override async Task<Customer>? GetById(object? id)
        {
            var customer = await GetRepository.CustomerRepository.GetById(id);
            return customer;
        }

        public override Task<Pagination<Customer>> GetPagination(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
