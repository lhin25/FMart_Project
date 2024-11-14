using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface ICustomerService : IGenericService<Customer>
    {
        public Task<Customer> GetByPhoneNumber(string phoneNumber);
    }
}
