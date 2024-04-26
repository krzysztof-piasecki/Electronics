using System.ComponentModel.DataAnnotations;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class DisplayMonitor : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Diagonal { get; set; }
    public ProductType Type { get; set; } = ProductType.DisplayMonitor;
    
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
}