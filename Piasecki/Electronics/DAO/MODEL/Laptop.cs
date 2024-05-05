using System.ComponentModel.DataAnnotations;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class Laptop : IEntity
{
    [Key] public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string CPU { get; set; }
    public string GPU { get; set; }
    public decimal Size { get; set; }
    public ProductBrand Brand { get; set; } = ProductBrand.Lenovo;

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
}