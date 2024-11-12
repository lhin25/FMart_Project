using DataAccess.Models;
using DataAccess.Repository;
using DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class StaffService : GenericService<Staff>, IStaffService
    {
        public StaffService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task Add(Staff entity)
        {
            try
            {
                var existedStaff = await GetRepository.StaffRepository.GetAllAsync(filter: s => s.Email == entity.Email);
                if (existedStaff != null)
                {
                    throw new Exception("Account already exists.");
                }
                await GetRepository.StaffRepository.CreateAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Task Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override async Task<ICollection<Staff>>? GetAll()
        {
            var staffs = await GetRepository.StaffRepository.GetAllAsync();
            return staffs;
        }

        public override async Task<Staff?> GetById(object? id)
        {
            return await GetRepository.StaffRepository.GetById(id);
        }

        public override Task<Pagination<Staff>> GetPagination(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Staff> Login(string email, string password)
        {
            var _staff = await GetRepository.StaffRepository.Login(email, password);
            return _staff;
        }

        public override Task Update(Staff entity)
        {
            throw new NotImplementedException();
        }
    }
}
