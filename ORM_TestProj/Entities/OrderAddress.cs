namespace ORM_TestProj.Entities;

public class OrderAddress
{
    // Domains
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid AddressId { get; set; }
    public bool IsInitialAddress { get; set; }

    // Navigation
    public virtual Order OrderNavigation { get; set; } = null!;
    public virtual Address AddressNavigation { get; set; } = null!;
}