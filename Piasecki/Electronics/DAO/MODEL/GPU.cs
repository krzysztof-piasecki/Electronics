using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class GPU
{
    public GPU(string name, decimal price, string vRam)
    {
        Name = name;
        Price = price;
        VRam = vRam;
        Type = ProductType.GPU;
    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string VRam { get; set; }
    public ProductType Type { get; }
}