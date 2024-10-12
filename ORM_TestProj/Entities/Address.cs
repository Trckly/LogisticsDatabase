using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Address
{
    // Domains
    public Guid Id { get; set; }
    public string Province { get; set; } = null!;
    public string Settlement { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    
    // Navigation
    public virtual ICollection<OrderAddress> OrderAddressesNavigation { get; set; } = new List<OrderAddress>();
}
