using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Logist
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? FirstName { get; set; }

    [MaxLength(50)]
    public string? LastName { get; set; }

    [MaxLength(50)]
    public string? Surname { get; set; }

    [MinLength(13)]
    [MaxLength(13)]
    public string? PhoneNumber { get; set; }

    [MaxLength(50)]
    public string? Email { get; set; }

    public virtual ICollection<Carrier> Carriers { get; set; } = new List<Carrier>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
