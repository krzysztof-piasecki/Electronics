using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class DisplayMonitor
{
    public DisplayMonitor(string name, decimal price, decimal diagonal)
    {
        Name = name;
        Price = price;
        Diagonal = diagonal;
        Type = ProductType.DisplayMonitor;
    }

    public string Name { get; }
    public decimal Price { get; set; }
    public decimal Diagonal { get; set; }
    public ProductType Type { get; }
}