using API_Lab4.Data;
using Microsoft.EntityFrameworkCore;

namespace API_Lab4.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _Context;
        private DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _Context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return null;
            }

            _dbSet.Remove(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }

        public async  Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }
    }
}
