using Microsoft.EntityFrameworkCore;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.REPOSITORIES
{
    public class Repository
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task Add<T>(T entity) where T : class
        {
            await _dbContext.Set<T>().AddAsync(entity); 
            
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task<List<T>> GetAll<T>() where T : class
        {
            
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById<T>(Guid id) where T : class, IEntity
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(p => p.Id == id);
        }
        
        public async Task Delete<T>(Guid id) where T : class, IEntity
        {
            var entityToDelete = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entityToDelete == null)
            {
                throw new InvalidOperationException("Entity not found");
            }
            _dbContext.Entry(entityToDelete).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : class, IEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}