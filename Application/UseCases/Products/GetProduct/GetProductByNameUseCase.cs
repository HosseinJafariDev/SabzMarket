using SabzMarket.Application.Common;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Application.UseCases.Products.GetProduct;

public class GetProductByNameUseCase(IProductRepository productRepository) : IGetProductByNameUseCase
{
    public async Task<List<GetProductOutputDto>> ExecuteAsync(string name, CancellationToken token)
    {
        var products = await productRepository.GetAllAsync(token, x => x.Name == name);

        if (!products.Any())
            throw new NotFoundException(Messages.ProductNotFoundByName);

        return products.Select(x => ToDto(x)).ToList();
    }

    private GetProductOutputDto ToDto(Product product) => new(product.Id, product.SellerId, product.CategoryId,
        product.Name, product.Description, product.Number, product.Price, product.ImageProduct);
}