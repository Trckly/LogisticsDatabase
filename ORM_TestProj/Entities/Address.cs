using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Address
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string Province { get; set; } = null!;

    [MaxLength(50)]
    public string City { get; set; } = null!;

    [MaxLength(50)]
    public string Street { get; set; } = null!;

    [MaxLength(50)]
    public string Number { get; set; } = null!;

    [MaxLength(50)]
    public string Organization { get; set; } = null!;

    public virtual ICollection<Order> OrderLoadingAddressNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderUnloadingAddressNavigations { get; set; } = new List<Order>();
}
