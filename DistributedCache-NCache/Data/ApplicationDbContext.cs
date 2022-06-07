using DistributedCache_NCache.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributedCache_NCache.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
    }
}
