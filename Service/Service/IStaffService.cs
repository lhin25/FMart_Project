using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public interface IStaffService : IGenericService<Staff>
    {
        public Task<Staff> Login(string email, string password);
    }
}
