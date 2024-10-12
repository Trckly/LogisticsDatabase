namespace ORM_TestProj.Entities;

public class CargoOrder
{
    // Domains
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid CargoId { get; set; }
    
    // Navigation
    public virtual Order OrderNavigation { get; set; } = null!;
    public virtual Cargo CargoNavigation { get; set; } = null!;
}