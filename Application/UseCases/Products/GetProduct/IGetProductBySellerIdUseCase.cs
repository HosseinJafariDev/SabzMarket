namespace SabzMarket.Application.UseCases.Products.GetProduct;

public interface IGetProductBySellerIdUseCase
{
    Task<List<GetProductOutputDto>> ExecuteAsync(long sellerId, CancellationToken token);
}