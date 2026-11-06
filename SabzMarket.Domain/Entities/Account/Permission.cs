using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.Account;

public class Permission : BaseEntity
{
    public long ParentId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
}