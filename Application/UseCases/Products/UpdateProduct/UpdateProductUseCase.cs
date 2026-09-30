using SabzMarket.Application.Common;
using SabzMarket.Application.Common.Enums;
using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.Product;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;

namespace SabzMarket.Application.UseCases.Products.UpdateProduct;

public class UpdateProductUseCase(
    IProductRepository productRepository,
    IFileStorageService fileStorageService,
    IUnitOfWork unitOfWork)
    : IUpdateProductUseCase
{
    public async Task ExecuteAsync(UpdateProductInputDto inputDto, Stream stream,
        CancellationToken token)
    {
        var product = await productRepository.GetByIdAsync(inputDto.SellerId, token);

        if (product is null)
        {
            throw new NotFoundException(CommonMessages.NotFoundWarning(ProductMessages.Product));
        }

        bool newImage = false;
        if (!inputDto.ImageProduct!.StartsWith(CommonMessages.Url))
        {
            newImage = true;
        }

        productRepository.Update(product);
        if (!newImage)
        {
            product.UpdateImageProduct(inputDto.ImageProduct);
        }
        else
        {
            product.UpdateImageProduct(await fileStorageService.SaveAsync(stream!,
                inputDto.ImageProduct, FileFolder.ProductImage, product.Id, token));
        }

        await unitOfWork.SaveChangesAsync(token);
        await unitOfWork.SaveChangesAsync(token);
    }
}