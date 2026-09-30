namespace SabzMarket.Application.UseCases.Products.DeleteProduct;

public interface IDeleteProductUseCase
{
    Task ExecuteAsync(long id, CancellationToken token);
}