using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Order
{
    // Domains
    public Guid Id { get; set; }
    public Guid LogistId { get; set; }
    public string ClientCompanyName { get; set; } = null!;
    public string CarrierCompanyName { get; set; } = null!;
    public Guid VehicleId { get; set; }
    public Guid DriverId { get; set; }
    public double ClientPrice { get; set; }
    public double CarrierPrice { get; set; }
    public bool Active { get; set; }
    
    // Navigation
    public virtual Logist LogistNavigation { get; set; } = null!;
    public virtual Vehicle VehicleNavigation { get; set; } = null!;
    public virtual Driver DriverNavigation { get; set; } = null!;
    public virtual ICollection<OrderAddress> OrderAddressesNavigation { get; set; } = new List<OrderAddress>();
    public virtual ICollection<CargoOrder> CargoOrderNavigation { get; set; } = new List<CargoOrder>();
}
