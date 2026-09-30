namespace SabzMarket.Application.UseCases.Products.UpdateProduct;

public interface IUpdateProductUseCase
{
    Task ExecuteAsync(UpdateProductInputDto updateProductInputDto, Stream stream,
        CancellationToken token);
}