using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Carrier
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string CompanyName { get; set; } = null!;

    public int Logist { get; set; }

    public decimal License { get; set; }

    public virtual Logist LogistNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
