using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class DrivingLicense
{
    [MaxLength(50)]
    public string LicenseNumber { get; set; } = null!;

    [MaxLength(50)]
    public string LicenseIssuer { get; set; } = null!;

    public DateOnly LicenseIssuingDate { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
