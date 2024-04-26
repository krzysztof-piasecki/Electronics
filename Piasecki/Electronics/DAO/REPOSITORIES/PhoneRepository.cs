using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.REPOSITORIES
{
    public class PhoneRepository
    {
        private readonly AppDbContext _dbContext;

        public PhoneRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPhone(Phone phone)
        {
            _dbContext.Phones.Add(phone);
            _dbContext.SaveChanges();
        }


        public List<Phone> GetAllPhones()
        {
            return _dbContext.Phones.ToList();
        }

        public Phone? GetPhoneByName(string name)
        {
            return _dbContext.Phones.FirstOrDefault(p => p.Name == name);
        }
        
        public void DeleteMonitor(Phone phone)
        {
            var phoneToDelete = _dbContext.Phones.FirstOrDefault(p => p.Name == phone.Name);
            _dbContext.Phones.Remove(phoneToDelete ?? throw new InvalidOperationException("Phone not found"));
            _dbContext.SaveChanges();
        }

        public void UpdatePhone(Phone updatedPhone)
        {
            var phoneToUpdate = _dbContext.Phones.FirstOrDefault(p => p.Name == updatedPhone.Name);
            if (phoneToUpdate == null) return;

            phoneToUpdate.Name = updatedPhone.Name;
            phoneToUpdate.Price = updatedPhone.Price;
            phoneToUpdate.Camera = updatedPhone.Camera;
            _dbContext.SaveChanges();
        }

    }
}