using SabzMarket.Application.Common.Dtos;
using SabzMarket.Domain.Enums;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public class SearchOrderFilterInputDto : BasePaginationInputDto
{
    public int? Price { get; set; }

    public int? Number { get; set; }
    public string? Search { get; set; }

    public OrderStatus Status { get; set; }
}