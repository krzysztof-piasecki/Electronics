using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class Laptop
{
    public Laptop(string name, decimal price, string cpu, string gpu, decimal size)
    {
        Name = name;
        Price = price;
        CPU = cpu;
        GPU = gpu;
        Size = size;
        Type = ProductType.GPU;

    }

    public string Name { get; set; }
    public decimal Price { get; set; }
    public string CPU { get; set; }
    public string GPU { get; set; }
    public decimal Size { get; set; }
    public ProductType Type { get; }

}