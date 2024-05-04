using System.ComponentModel.DataAnnotations;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.DAO.MODEL;

public class GPU : IEntity
{
    [Key] 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string VRam { get; set; }
    
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }
}