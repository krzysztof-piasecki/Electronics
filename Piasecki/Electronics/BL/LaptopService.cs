using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;
using Piasecki.Electronics.UI.ViewsModels;

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

    public async Task AddLaptopAsync(LaptopViewModel laptopViewModel)
    {
        var product = new Product()
        {
            Name = laptopViewModel.Name,
            Type = ProductType.Laptop,
            Laptops = new Laptop()
            {
                CPU = laptopViewModel.CPU,
                GPU = laptopViewModel.GPU,
                Brand = laptopViewModel.Brand,
                Price = laptopViewModel.Price
            }
        };

        await _repository.Add(product);
    }

    public async Task UpdateLaptopAsync(LaptopViewModel laptopViewModel)
    {
        if (laptopViewModel.Id is null)
            throw new ArgumentNullException(nameof(laptopViewModel.Id));

        var laptop = await _repository.GetById<Laptop>(laptopViewModel.Id.Value, p => p.Product);

        if (laptop is null)
            throw new InvalidOperationException("Laptop not found");

        laptop.Product.Name = laptopViewModel.Name;

        await _repository.Update(laptop);
    }

    public async Task<Laptop> GetLaptopByGuid(Guid guid)
    {
        return await _repository.GetById<Laptop>(guid);
    }

    public async Task DeleteLaptopAsync(Laptop laptop)
    {
        await _repository.Delete<Laptop>(laptop.Id);
    }
}