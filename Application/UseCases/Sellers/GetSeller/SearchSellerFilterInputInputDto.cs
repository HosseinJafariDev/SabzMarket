using SabzMarket.Application.Common.Dtos;
using SabzMarket.Application.Common.Enums;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Application.UseCases.Sellers.GetSeller;

public class SearchSellerFilterInputInputDto : BasePaginationInputDto
{
    public string? Phone { get; set; }

    public string? UserName { get; set; }
}