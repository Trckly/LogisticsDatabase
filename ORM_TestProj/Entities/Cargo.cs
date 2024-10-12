using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Cargo
{
    // Domains
    public Guid Id { get; set; }
    public string Denomination { get; set; } = null!;
    public double Weight { get; set; }
    public double Volume { get; set; }
    
    // Navigation
    public virtual ICollection<CargoOrder> CargoOrdersNavigation { get; set; } = new List<CargoOrder>();
}
