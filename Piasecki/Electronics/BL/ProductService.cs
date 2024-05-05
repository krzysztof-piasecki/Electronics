using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;

namespace Piasecki.Electronics.BL;

public class ProductService
{
    private readonly Repository _repository;

    public ProductService()
    {
        var dbContextFactory = new DbContextFactory();
        var appDbContext = dbContextFactory.CreateDbContext(new string[0]);

        _repository = new Repository(appDbContext);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _repository.GetAll<Product>();
    }
}