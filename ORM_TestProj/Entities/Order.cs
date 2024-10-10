using System.ComponentModel.DataAnnotations;

namespace ORM_TestProj.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int Logist { get; set; }

    public int LoadingAddress { get; set; }

    public int UnloadingAddress { get; set; }

    public int Client { get; set; }

    public int Carrier { get; set; }

    public int Vehicle { get; set; }

    public int Driver { get; set; }

    public int Cargo { get; set; }

    public double ClientPrice { get; set; }

    public double CarrierPrice { get; set; }

    public bool ValueAddedTax { get; set; }

    public DateOnly DepartureDate { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public DateOnly EstimatedArrivalDate { get; set; }

    public bool Active { get; set; }

    [MaxLength(50)]
    public string? AdditionalInfo { get; set; }

    public virtual Cargo CargoNavigation { get; set; } = null!;

    public virtual Carrier CarrierNavigation { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Driver DriverNavigation { get; set; } = null!;

    public virtual Address LoadingAddressNavigation { get; set; } = null!;

    public virtual Logist LogistNavigation { get; set; } = null!;

    public virtual Address UnloadingAddressNavigation { get; set; } = null!;

    public virtual Vehicle VehicleNavigation { get; set; } = null!;
}
