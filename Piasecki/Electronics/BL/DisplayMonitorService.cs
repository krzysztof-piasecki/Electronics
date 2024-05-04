using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;

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
    public async Task AddDisplayMonitorAsync(DisplayMonitor display)
    {
        await _repository.Add(display);
    }
    public async Task UpdateDisplayMonitorAsync(DisplayMonitor display)
    {
        await _repository.Update(display);
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