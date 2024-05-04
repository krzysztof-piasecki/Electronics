using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;

namespace Piasecki.Electronics.BL;

public class PhoneService
{
    private readonly Repository _repository;

    public PhoneService()
    {
        var dbContextFactory = new DbContextFactory();
        var appDbContext = dbContextFactory.CreateDbContext(new string[0]);
        
        _repository = new Repository(appDbContext);
    }
    public async Task<IEnumerable<Phone>> GetAllPhoneAsync()
    {
        return await _repository.GetAll<Phone>();
    }
    public async Task AddPhoneAsync(Phone product)
    {
        await _repository.Add(product);
    }
    public async Task UpdatePhoneAsync(Phone phone)
    {
        await _repository.Update(phone);
    }
    public async Task GetPhoneByGuid(Guid guid)
    {
        await _repository.GetById<Phone>(guid);
    }
    public async Task DeletePhoneAsync(Phone phone)
    {
        await _repository.Delete<Phone>(phone.Id);
    }
}