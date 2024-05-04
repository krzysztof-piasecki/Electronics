using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;

namespace Piasecki.Electronics.BL;

public class LaptopService
{
    private readonly Repository _repository;

    public LaptopService()
    {
        var dbContextFactory = new DbContextFactory();
        var appDbContext = dbContextFactory.CreateDbContext(new string[0]);
        
        _repository = new Repository(appDbContext);
    }
    public async Task<IEnumerable<Laptop>> GetAllLaptopAsync()
    {
        return await _repository.GetAll<Laptop>();
    }
    public async Task AddLaptopAsync(Laptop laptop)
    {
        await _repository.Add(laptop);
    }
    public async Task UpdateLaptopAsync(Laptop laptop)
    {
        await _repository.Update(laptop);
    }
    public async Task GetLaptopByGuid(Guid guid)
    {
        await _repository.GetById<Laptop>(guid);
    }
    public async Task DeleteLaptopAsync(Laptop laptop)
    {
        await _repository.Delete<Laptop>(laptop.Id);
    }
}