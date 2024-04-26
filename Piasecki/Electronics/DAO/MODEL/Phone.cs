using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class Phone
{
    public Phone(string name, decimal price, string camera)
    {
        Name = name;
        Price = price;
        Camera = camera;
        Type = ProductType.Phone;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Camera { get; set; }
    public ProductType Type { get; }
}
