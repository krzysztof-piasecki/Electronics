using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;

namespace Piasecki.Electronics.BL;

public class GPUService
{
    private readonly Repository _repository;

    public GPUService()
    {
        var dbContextFactory = new DbContextFactory();
        var appDbContext = dbContextFactory.CreateDbContext(new string[0]);
        
        _repository = new Repository(appDbContext);
    }
    public async Task<IEnumerable<GPU>> GetAllGPUAsync()
    {
        return await _repository.GetAll<GPU>();
    }
    public async Task AddGPUAsync(GPU gpu)
    {
        await _repository.Add(gpu);
    }
    public async Task UpdateGPUAsync(GPU gpu)
    {
        await _repository.Update(gpu);
    }
    public async Task GetGPUByGuid(Guid guid)
    {
        await _repository.GetById<GPU>(guid);
    }
    public async Task DeleteGPUAsync(GPU gpu)
    {
        await _repository.Delete<GPU>(gpu.Id);
    }
}