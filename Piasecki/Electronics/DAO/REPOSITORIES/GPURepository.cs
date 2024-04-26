using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.REPOSITORIES
{
    public class GPURepository
    {
        private readonly AppDbContext _dbContext;

        public GPURepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddGPU(GPU gpu)
        {
            _dbContext.Gpus.Add(gpu);
            _dbContext.SaveChanges();
        }


        public List<GPU> GetAllGPUs()
        {
            return _dbContext.Gpus.ToList();
        }

        public GPU? GetGPUByName(string name)
        {
            return _dbContext.Gpus.FirstOrDefault(p => p.Name == name);
        }
        
        public void DeleteMonitor(GPU gpu)
        {
            var gpuToDelete = _dbContext.Gpus.FirstOrDefault(p => p.Name == gpu.Name);
            _dbContext.Gpus.Remove(gpuToDelete ?? throw new InvalidOperationException("GPU not found"));
            _dbContext.SaveChanges();
        }

        public void UpdateGPU(GPU updatedGPU)
        {
            var gpuToUpdate = _dbContext.Gpus.FirstOrDefault(p => p.Name == updatedGPU.Name);
            if (gpuToUpdate == null) return;

            gpuToUpdate.Name = updatedGPU.Name;
            gpuToUpdate.Price = updatedGPU.Price;
            gpuToUpdate.VRam = updatedGPU.VRam;
            _dbContext.SaveChanges();
        }

    }
}