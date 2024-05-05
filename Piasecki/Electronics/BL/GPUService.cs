using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;
using Piasecki.Electronics.UI.ViewsModels;

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

    public async Task AddGPUAsync(GPUViewModel gpuViewModel)
    {
        var product = new Product()
        {
            Name = gpuViewModel.Name,
            Type = ProductType.GPU,
            GPUs = new GPU()
            {
                VRam = gpuViewModel.VRam,
                Price = gpuViewModel.Price
            }
        };

        await _repository.Add(product);
    }

    public async Task UpdateGPUAsync(GPUViewModel gpuViewModel)
    {
        if (gpuViewModel.Id is null)
            throw new ArgumentNullException(nameof(gpuViewModel.Id));

        var gpu = await _repository.GetById<GPU>(gpuViewModel.Id.Value, p => p.Product);

        if (gpu is null)
            throw new InvalidOperationException("GPU not found");

        gpu.Product.Name = gpuViewModel.Name;

        await _repository.Update(gpu);
    }

    public async Task<GPU> GetGPUByGuid(Guid guid)
    {
        return await _repository.GetById<GPU>(guid);
    }

    public async Task DeleteGPUAsync(GPU gpu)
    {
        await _repository.Delete<GPU>(gpu.Id);
    }
}