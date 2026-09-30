using SabzMarket.Application.Common.Attributes;
using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Common.Enums;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Domain.Enums;

namespace SabzMarket.Application.UseCases.Orders.GetOrders;

public class SearchOrderFilterInputInputDto : BasePaginationInputDto
{
    [Filter(nameof(Product.Name), FilterOperator.Equal)]
    public int Price { get; private set; }

    [Filter(nameof(Product.Name), FilterOperator.Equal)]
    public int Number { get; private set; }

    [Filter(nameof(Product.Name), FilterOperator.Equal)]
    public OrderStatus Status { get; set; }
}