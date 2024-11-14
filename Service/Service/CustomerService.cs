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

        public override async Task<bool> Add(Customer entity)
        {
            try
            {
                var customer = await GetRepository.CustomerRepository.GetAsync(filter: cte => cte.PhoneNumber == entity.PhoneNumber);
                if (customer != null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.CustomerRepository.CreateAsync(entity);
                    return true;
                }
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

        public override Task<Customer> Get(Expression<Func<Customer, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Customer>>? GetAll()
        {
            var customers = await GetRepository.CustomerRepository.GetAllAsync();
            return customers;
        }

        public async Task<Customer> GetByPhoneNumber(string phoneNumber)
        {
            var customer = await GetRepository.CustomerRepository.GetAsync(filter: i => i.PhoneNumber == phoneNumber);
            return customer;
        }

        public override async Task<Pagination<Customer>> GetPagination(int pageIndex, int pageSize)
        {
            var listCustomers = await GetAll();
            return await GetRepository.CustomerRepository.ToPagination(listCustomers, pageIndex, pageSize);
        }

        public async Task<int> GetTotalCustomers()
        {
            return await GetRepository.CustomerRepository.GetTotalCustomers();
        }

        public override async Task<bool> Update(Customer entity)
        {
            try
            {
                var cate = await GetRepository.CustomerRepository.GetAsync(filter: cte => cte.CustomerId == entity.CustomerId);
                if (cate == null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.CustomerRepository.UpdateAsync(cate);
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
