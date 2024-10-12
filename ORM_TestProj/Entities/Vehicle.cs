using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Vehicle
{
    // Domains
    public Guid Id { get; set; }
    public string LicensePlate { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int ProductionYear { get; set; }
    public double CarryingCapacity { get; set; }
    
    // Navigation
    public virtual ICollection<Order> OrdersNavigation { get; set; } = new List<Order>();
}
