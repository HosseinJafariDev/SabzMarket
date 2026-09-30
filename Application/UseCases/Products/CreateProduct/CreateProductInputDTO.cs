namespace SabzMarket.Application.UseCases.Products.CreateProduct;

public record CreateProductInputDto(
    long SellerId,
    long CategoryId,
    string Name,
    string Description,
    int Price,
    int Number,
    string ImageProduct);