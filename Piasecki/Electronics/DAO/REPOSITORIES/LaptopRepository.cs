using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.REPOSITORIES
{
    public class LaptopRepository
    {
        private readonly AppDbContext _dbContext;

        public LaptopRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddLaptop(Laptop laptop)
        {
            _dbContext.Laptops.Add(laptop);
            _dbContext.SaveChanges();
        }


        public List<Laptop> GetAllLaptops()
        {
            return _dbContext.Laptops.ToList();
        }

        public Laptop? GetLaptopByName(string name)
        {
            return _dbContext.Laptops.FirstOrDefault(p => p.Name == name);
        }
        
        public void DeleteMonitor(Laptop laptop)
        {
            var laptopToDelete = _dbContext.Laptops.FirstOrDefault(p => p.Name == laptop.Name);
            _dbContext.Laptops.Remove(laptopToDelete ?? throw new InvalidOperationException("Laptop not found"));
            _dbContext.SaveChanges();
        }

        public void UpdateLaptop(Laptop updatedLaptop)
        {
            var laptopToUpdate = _dbContext.Laptops.FirstOrDefault(p => p.Name == updatedLaptop.Name);
            if (laptopToUpdate == null) return;

            laptopToUpdate.Name = updatedLaptop.Name;
            laptopToUpdate.Price = updatedLaptop.Price;
            laptopToUpdate.GPU = updatedLaptop.GPU;
            laptopToUpdate.CPU = updatedLaptop.CPU;
            _dbContext.SaveChanges();
        }

    }
}