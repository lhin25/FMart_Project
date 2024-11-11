
using Microsoft.EntityFrameworkCore;
using DataAccess.DataContext;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            var tEntity = _context.Entry(entity).Entity;
            if(tEntity != null)
            {
                _context.Remove(tEntity);
            }
            else
            {
                _dbSet.Attach(tEntity);
                _dbSet.Remove(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(object? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            var tEntity = _context.Entry(entity).Entity;
            if (tEntity != null)
            {
                _context.Update(tEntity);
            }
            else
            {
                _context.Attach(tEntity);
                _context.Update(tEntity);
            }
            await _context.SaveChangesAsync();
        }
    }
}
