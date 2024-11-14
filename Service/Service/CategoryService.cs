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
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IGetRepository getRepository) : base(getRepository) { }

        public override async Task<bool> Add(Category entity)
        {
            try
            {
                var cate = await GetRepository.CategoryRepository.GetAsync(filter: cte => cte.CategoryName == entity.CategoryName);
                if (cate != null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.CategoryRepository.CreateAsync(entity);
                    return true;
                }
            } catch (Exception)
            {
                throw new Exception("An error has occured.");
            }
        }

        public override async Task<bool> Delete(object? id)
        {
            try
            {
                var cate = await GetRepository.CategoryRepository.GetAsync(filter: cte => cte.CategoryId == (int)id);
                if (cate == null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.CategoryRepository.DeleteAsync(cate);
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("An error has occured.");
            }
        }

        public override async Task<Category> Get(Expression<Func<Category, bool>> filter, string? includeProperties = null)
        {
            var customer = await GetRepository.CategoryRepository.GetAsync(filter, includeProperties);
            return customer;
        }

        public override async Task<IEnumerable<Category>>? GetAll()
        {
            var categories = await GetRepository.CategoryRepository.GetAllAsync();
            return categories;
        }

        public override async Task<Pagination<Category>> GetPagination(int pageIndex, int pageSize)
        {
            var listCategories = await GetAll();
            return await GetRepository.CategoryRepository.ToPagination(listCategories, pageIndex, pageSize);
        }

        public override async Task<bool> Update(Category entity)
        {
            try
            {
                var cate = await GetRepository.CategoryRepository.GetAsync(filter: cte => cte.CategoryId == entity.CategoryId);
                if (cate == null)
                {
                    return false;
                }
                else
                {
                    await GetRepository.CategoryRepository.UpdateAsync(cate);
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
