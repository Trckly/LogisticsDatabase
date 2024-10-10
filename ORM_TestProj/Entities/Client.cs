using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Client
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string CompanyName { get; set; } = null!;

    public int Logist { get; set; }

    public Logist LogistNavigation { get; set; } = null!;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
