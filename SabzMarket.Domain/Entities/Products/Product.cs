using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Products
{
    public class Product
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public long Id { get; private set; }
        public long SellerId { get; private set; }
        public long CategoryId { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public int Price { get; private set; }
        public int Number { get; private set; }
        public string ImageProduct { get; private set; } = null!;
        public bool IsDeleted { get; private set; } = false;

        private Product()
        {
        }

        public Product(long sellerId, long categoryId, string name, int price, int number, string imageProduct,
            string description)
        {
            if (sellerId <= 0)
                throw new DomainException(ProductMessages.SellerIdRequired);

            if (categoryId <= 0)
                throw new DomainException(ProductMessages.CategoryIdRequired);

            if (price <= 0)
                throw new DomainException(ProductMessages.PriceRequired);

            if (number <= 0)
                throw new DomainException(ProductMessages.NumberRequired);

            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException(ProductMessages.NameRequired);

            if (string.IsNullOrWhiteSpace(imageProduct))
                throw new DomainException(ProductMessages.ImageProductRequired);

            SellerId = sellerId;
            CategoryId = categoryId;
            Name = name;
            Price = price;
            Number = number;
            ImageProduct = imageProduct;
            Description = description;
        }

        public void Delete() => IsDeleted = true;
    }
}