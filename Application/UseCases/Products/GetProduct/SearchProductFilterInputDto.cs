using SabzMarket.Application.Common.Dtos;

namespace SabzMarket.Application.UseCases.Products.GetProduct;

public class SearchProductFilterInputDto:BasePaginationInputDto
{
    public long? SellerId { get; set; }
    public string? Name { get; set; }
}