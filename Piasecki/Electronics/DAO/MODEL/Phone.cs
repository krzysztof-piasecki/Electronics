using System.ComponentModel.DataAnnotations;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class Phone : IEntity
{
    [Key] 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Camera { get; set; }
    public ProductType Type { get; set; } = ProductType.Phone;
    
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
}
