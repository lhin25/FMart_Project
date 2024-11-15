﻿using DataAccess.Models;
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
    public class ActivityService : GenericService<Activity>, IActivityService
    {
        public ActivityService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task<bool> Add(Activity entity)
        {
            try
            {
                var isExisted = await GetRepository.ActivityRepository.GetById(entity.ActivityId);
                if (isExisted != null)
                {
                    return false;
                }
                await GetRepository.ActivityRepository.CreateAsync(entity);
                return true;
            } catch(Exception)
            {
                throw new Exception("An error has occured.");
            }
                
        }

        public override Task<bool> Delete(object? id)
        {
            throw new NotImplementedException();
        }

        public override Task<Activity> Get(Expression<Func<Activity, bool>> filter, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Activity>>? GetAll()
        {
            var activities = await GetRepository.ActivityRepository.GetAllAsync(includeProperties: "Staff");
            return activities;
        }

        public override async Task<Pagination<Activity>> GetPagination(int pageIndex, int pageSize)
        {
            var listActivities = await GetAll();
            return await GetRepository.ActivityRepository.ToPagination(listActivities, pageIndex, pageSize);
        }

        public override Task<bool> Update(Activity entity)
        {
            throw new NotImplementedException();
        }
    }
}
