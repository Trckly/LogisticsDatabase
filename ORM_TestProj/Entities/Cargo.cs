using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Cargo
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Denomination { get; set; } = null!;

    public double Weight { get; set; }

    public double Volume { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
