namespace ORM_TestProj.Entities;

public class DestinationOrderAddress
{
    // Domains
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid DestinationAddressId { get; set; }

    // Navigation
    public virtual Order OrderNavigation { get; set; } = null!;
    public virtual Address DestinationAddressNavigation { get; set; } = null!;
}