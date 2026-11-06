using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.Account;

public class Menu : BaseEntity
{
    public long ParentId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public int SortOrder { get; set; }
}