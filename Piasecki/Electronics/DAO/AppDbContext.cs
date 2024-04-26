using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Piasecki.Electronics.DAO.MODEL;

namespace Piasecki.Electronics.DAO
{
    public class AppDbContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<GPU> Gpus { get; set; }
        public DbSet<DisplayMonitor> DisplayMonitors { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
    
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql("server=localhost;port=3306;database=electronics_schema;user=root;password=admin", new MySqlServerVersion("8.0.21"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}