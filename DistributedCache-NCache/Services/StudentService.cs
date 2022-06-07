using DistributedCache_NCache.Data;
using Microsoft.EntityFrameworkCore;

namespace DistributedCache_NCache.Services
{
    public class StudentService<T> : IStudent<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<T>().FindAsync(keyValues);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
