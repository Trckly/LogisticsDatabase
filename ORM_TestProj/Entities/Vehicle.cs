using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Vehicle
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string LicensePlate { get; set; } = null!;

    [MaxLength(50)]
    public string Model { get; set; } = null!;

    public int ProductionYear { get; set; }

    public double CarryingCapacity { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
