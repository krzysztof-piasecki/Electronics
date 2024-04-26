using Microsoft.EntityFrameworkCore;
using Piasecki.Electronics.DAO.MODEL;

namespace Piasecki.Electronics.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<GPU> Gpus { get; set; }
        public DbSet<DisplayMonitor> DisplayMonitors { get; set; }
    }
}