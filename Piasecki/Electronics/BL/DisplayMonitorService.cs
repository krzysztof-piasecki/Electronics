using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki.Electronics.BL;

public class DisplayMonitorService
{
    private readonly Repository _repository;

    public DisplayMonitorService()
    {
        var dbContextFactory = new DbContextFactory();
        var appDbContext = dbContextFactory.CreateDbContext(new string[0]);

        _repository = new Repository(appDbContext);
    }

    public async Task<IEnumerable<DisplayMonitor>> GetAllDisplayMonitorAsync()
    {
        return await _repository.GetAll<DisplayMonitor>();
    }

    public async Task AddDisplayMonitorAsync(DisplayMonitorViewModel displayMonitorViewModel)
    {
        var product = new Product()
        {
            Name = displayMonitorViewModel.Name,
            Type = ProductType.DisplayMonitor,
            DisplayMonitors = new DisplayMonitor()
            {
                Diagonal = displayMonitorViewModel.Diagonal,
                Price = displayMonitorViewModel.Price
            }
        };

        await _repository.Add(product);
    }

    public async Task UpdateDisplayMonitorAsync(DisplayMonitorViewModel displayMonitorViewModel)
    {
        if (displayMonitorViewModel.Id is null)
            throw new ArgumentNullException(nameof(displayMonitorViewModel.Id));

        var displayMonitor =
            await _repository.GetById<DisplayMonitor>(displayMonitorViewModel.Id.Value, p => p.Product);

        if (displayMonitor is null)
            throw new InvalidOperationException("DisplayMonitor not found");

        displayMonitor.Product.Name = displayMonitorViewModel.Name;

        await _repository.Update(displayMonitor);
    }

    public async Task GetDisplayMonitorByGuid(Guid guid)
    {
        await _repository.GetById<DisplayMonitor>(guid);
    }

    public async Task DeleteDisplayMonitorAsync(DisplayMonitor displayMonitor)
    {
        await _repository.Delete<DisplayMonitor>(displayMonitor.Id);
    }
}