namespace SabzMarket.Application.UseCases.Products.GetProduct;

public interface IGetProductByNameUseCase
{
    Task<List<GetProductOutputDto>> ExecuteAsync(SearchProductFilterInputDto inputDto, CancellationToken token);
}