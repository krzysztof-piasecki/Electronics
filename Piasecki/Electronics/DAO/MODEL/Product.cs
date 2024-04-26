using System.ComponentModel.DataAnnotations;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class Product : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public virtual List<Laptop> Laptops { get; set; }
    public virtual List<GPU> GPUs { get; set; }
    public virtual List<Phone> Phones { get; set; }
    public virtual List<DisplayMonitor> DisplayMonitors { get; set; }
}