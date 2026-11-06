using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.Role;

public class Role : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public bool IsSystem { get; set; }
}