using SabzMarket.Application.Common;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Application.UseCases.Products.GetProduct;

public class GetProductBySellerIdUseCase(IProductRepository productRepository) : IGetProductBySellerIdUseCase
{
    public async Task<List<GetProductOutputDto>> ExecuteAsync(SearchProductFilterInputDto inputDto,
        CancellationToken token)
    {
        var products = await productRepository.GetAllAsync(inputDto.SellerId, inputDto.Name, inputDto.PageNumber,
            inputDto.PageSize, token);

        if (!products.Any())
            throw new NotFoundException(Messages.ProductNotFoundBySellerId);

        return products.Select(x => ToDto(x)).ToList();
    }

    private GetProductOutputDto ToDto(Product product) => new(product.Id, product.SellerId, product.CategoryId,
        product.Name, product.Description, product.Number, product.Price, product.ImageProduct);
}