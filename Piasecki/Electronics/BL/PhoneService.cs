using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;
using Piasecki.Electronics.UI.ViewsModels;

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

    public async Task AddPhoneAsync(PhoneViewModel phoneViewModel)
    {
        var product = new Product()
        {
            Name = phoneViewModel.Name,
            Type = ProductType.Phone,
            Phone = new Phone()
            {
                Camera = phoneViewModel.Camera,
                Price = phoneViewModel.Price
            }
        };

        await _repository.Add(product);
    }

    public async Task UpdatePhoneAsync(PhoneViewModel phoneViewModel)
    {
        if (phoneViewModel.Id is null)
            throw new ArgumentNullException(nameof(phoneViewModel.Id));

        var phone = await _repository.GetById<Phone>(phoneViewModel.Id.Value, p => p.Product);

        if (phone is null)
            throw new InvalidOperationException("Phone not found");

        phone.Product.Name = phoneViewModel.Name;

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