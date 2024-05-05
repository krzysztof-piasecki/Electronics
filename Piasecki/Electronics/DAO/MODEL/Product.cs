using System.ComponentModel.DataAnnotations;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class Product : IEntity
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; }
    public ProductType Type { get; set; }

    public virtual Laptop Laptops { get; set; }
    public virtual GPU GPUs { get; set; }
    public virtual Phone Phone { get; set; }
    public virtual DisplayMonitor DisplayMonitors { get; set; }
}