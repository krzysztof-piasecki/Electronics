using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.REPOSITORIES
{
    public class DisplayMonitorRepository
    {
        private readonly AppDbContext _dbContext;

        public DisplayMonitorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddDisplayMonitor(DisplayMonitor displayMonitor)
        {
            _dbContext.DisplayMonitors.Add(displayMonitor);
            _dbContext.SaveChanges();
        }


        public List<DisplayMonitor> GetAllDisplayMonitors()
        {
            return _dbContext.DisplayMonitors.ToList();
        }

        public DisplayMonitor? GetDisplayMonitorByName(string name)
        {
            return _dbContext.DisplayMonitors.FirstOrDefault(p => p.Name == name);
        }
        
        public void DeleteMonitor(DisplayMonitor displayMonitor)
        {
            var displayMonitorToDelete = _dbContext.DisplayMonitors.FirstOrDefault(p => p.Name == displayMonitor.Name);
            _dbContext.DisplayMonitors.Remove(displayMonitorToDelete ?? throw new InvalidOperationException("DisplayMonitor not found"));
            _dbContext.SaveChanges();
        }

        public void UpdateDisplayMonitor(DisplayMonitor updatedDisplayMonitor)
        {
            var displayMonitorToUpdate = _dbContext.DisplayMonitors.FirstOrDefault(p => p.Name == updatedDisplayMonitor.Name);
            if (displayMonitorToUpdate == null) return;

            displayMonitorToUpdate.Price = updatedDisplayMonitor.Price;
            displayMonitorToUpdate.Diagonal = updatedDisplayMonitor.Diagonal;
            _dbContext.SaveChanges();
        }

    }
}