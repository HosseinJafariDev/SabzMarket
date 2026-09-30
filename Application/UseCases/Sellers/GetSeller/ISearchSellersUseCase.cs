namespace SabzMarket.Application.UseCases.Sellers.GetSeller;

public interface ISearchSellersUseCase
{
    Task<GetSellersPagedOutputDto> ExecuteAsync(SearchSellerFilterInputInputDto inputInputDto, CancellationToken token);
}