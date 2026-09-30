using SabzMarket.Application.Constants.Common.Messages;
using SabzMarket.Application.Constants.Product;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Persistence;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;

namespace SabzMarket.Application.UseCases.Products.DeleteProduct;

public class DeleteProductUseCase(
    IProductRepository productRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork)
    : IDeleteProductUseCase
{
    public async Task ExecuteAsync(long id, CancellationToken token)
    {
        var order = await orderRepository.GetOrderWithDetilsByProductId(id, token);
        if (order is not null)
        {
            if (order.OrderDetails.Any(x => x.Status == OrderStatus.Pending))
            {
                throw new ConflictException(ProductMessages.ProductIsOnOrder);
            }
        }

        var product = await productRepository.GetByIdAsync(id, token);
        if (product is null)
        {
            throw new NotFoundException(CommonMessages.NotFoundWarning(ProductMessages.Product));
        }

        product.Delete();

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync(token);
    }
}