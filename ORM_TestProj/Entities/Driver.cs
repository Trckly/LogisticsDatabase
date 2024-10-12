using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Driver
{
    // Domains
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string DrivingLicenseId { get; set; } = null!;
    
    // Navigation
    public virtual DrivingLicense DrivingLicenseNavigation { get; set; } = null!;
    public virtual ICollection<Order> OrdersNavigation{ get; set; } = new List<Order>();
}
