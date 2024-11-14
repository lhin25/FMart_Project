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
    public class StaffService : GenericService<Staff>, IStaffService
    {
        public StaffService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task<bool> Add(Staff entity)
        {
            try
            {
                var existedStaff = await GetRepository.StaffRepository.GetAllAsync(filter: s => s.Email == entity.Email);
                if (existedStaff != null)
                {
                    return false;
                }
                await GetRepository.StaffRepository.CreateAsync(entity);
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

        public override Task<Staff> Get(Expression<Func<Staff, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Staff>>? GetAll()
        {
            var staffs = await GetRepository.StaffRepository.GetAllAsync(includeProperties: "Role");
            return staffs;
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

        public override async Task<bool> Update(Staff entity)
        {
            try
            {
                var cate = await GetRepository.StaffRepository.GetAsync(filter: cte => cte.StaffId == entity.StaffId);
                if (cate == null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.StaffRepository.UpdateAsync(cate);
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
