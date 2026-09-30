using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Common.Enums;
using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Application.UseCases.Products.CreateProduct;

public class CreateProductUseCase(
    IProductRepository productRepository,
    IFileStorageService fileStorageService,
    IUnitOfWork unitOfWork)
    : ICreateProductUseCase
{
    public async Task ExecuteAsync(CreateProductInputDto inputDto, Stream stream,
        CancellationToken token)
    {
        var product = new Product(inputDto.SellerId, inputDto.CategoryId, inputDto.Name, inputDto.Price,
            inputDto.Number, inputDto.Description);

        await unitOfWork.BeginAsync();
        productRepository.Add(product);
        await unitOfWork.SaveChangesAsync(token);

        var imageUrl = await fileStorageService.SaveAsync(stream, inputDto.ImageProduct, FileFolder.ProductImage,
            product.Id, token);

        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            await unitOfWork.RollbackAsync();
            throw new BadRequestException(CommonMessages.Error);
        }

        product.UpdateImageProduct(imageUrl);

        productRepository.Update(product);
        await unitOfWork.CommitAsync();
        await unitOfWork.SaveChangesAsync(token);
    }
}