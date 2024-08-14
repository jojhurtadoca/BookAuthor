using BookManagement.data.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookManagement.data.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        protected readonly ILogger<Repository<T>> _logger;

        public Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting entity with id {Id}", id);
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error adding entity");
                return null;
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception e) {
                _logger.LogError(e, "Error Updating entity");
                return null;
            }

        }

        public async Task<Boolean> Delete(int id)
        {
            try
            {
                T entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error deleting entity with id {Id}", id);
                return false;
            }

        }
    }
}
