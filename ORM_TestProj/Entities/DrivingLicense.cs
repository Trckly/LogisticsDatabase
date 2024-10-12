using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class DrivingLicense
{
    // Domains
    public string DrivingLicenceId { get; set; } = null!;
    public string LicenseIssuer { get; set; } = null!;
    public DateOnly LicenseIssuingDate { get; set; }

    //Navigation
    public virtual Driver DriverNavigation { get; set; } = null!;
}
