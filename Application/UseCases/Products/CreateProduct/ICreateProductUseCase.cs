namespace SabzMarket.Application.UseCases.Products.CreateProduct;

public interface ICreateProductUseCase
{
    Task ExecuteAsync(CreateProductInputDto createProductInputDto, Stream stream, CancellationToken token);
}