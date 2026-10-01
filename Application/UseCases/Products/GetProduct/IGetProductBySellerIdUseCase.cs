namespace SabzMarket.Application.UseCases.Products.GetProduct;

public interface IGetProductBySellerIdUseCase
{
    Task<List<GetProductOutputDto>> ExecuteAsync(SearchProductFilterInputDto inputDto, CancellationToken token);
}