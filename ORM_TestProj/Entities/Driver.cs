using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public sealed partial class Driver
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [MaxLength(50)]
    public string Surname { get; set; } = null!;

    [MaxLength(50)]
    public string PhoneNumber { get; set; }

    [MaxLength(50)]
    public string? DrivingLicense { get; set; }

    public DrivingLicense? DrivingLicenseNavigation { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
