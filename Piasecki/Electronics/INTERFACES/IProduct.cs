namespace Piasecki.Electronics.INTERFACES;

public interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
    ProductType ProductType { get; set; }
}