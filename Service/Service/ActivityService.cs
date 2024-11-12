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
    public class ActivityService : GenericService<Activity>, IActivityService
    {
        public ActivityService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task Add(Activity entity)
        {
            try
            {
                var isExisted = await GetRepository.ActivityRepository.GetById(entity.ActivityId);
                if (isExisted != null)
                {
                    throw new Exception("User already exists.");
                }
                await GetRepository.ActivityRepository.CreateAsync(entity);
            } catch(Exception)
            {
                throw;
            }
                
        }

        public override Task Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<ICollection<Activity>>? GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<Activity>? GetById(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Pagination<Activity>> GetPagination(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task Update(Activity entity)
        {
            throw new NotImplementedException();
        }
    }
}
