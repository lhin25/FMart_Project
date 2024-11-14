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
    public class RoleService : GenericService<Role>, IRoleService
    {
        public RoleService(IGetRepository getRepository) : base(getRepository) { }
        public override Task<bool> Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Role> Get(Expression<Func<Role, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Role>>? GetAll()
        {
            var roles = await GetRepository.RoleRepository.GetAllAsync();
            return roles;
        }

        public override Task<Pagination<Role>> GetPagination(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
