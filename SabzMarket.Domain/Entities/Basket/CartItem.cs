using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.CartItems;

public class CartItem : BaseEntity<int>
{
    public long FarmerId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime AddedDate { get; set; }

    public Buyer.Buyer? Farmer { get; private init; }
    public Product.Product? Product { get; private init; }

    private CartItem()
    {
    }

    public CartItem(long productId, int quantity, long farmerId)
    {
        if (productId <= 0)
            throw new ArgumentException(CartItemDomainMessages.ProductIdRequired);

        if (quantity <= 0)
            throw new ArgumentException(CartItemDomainMessages.QuantityRequired);

        if (farmerId <= 0)
            throw new ArgumentException(CartItemDomainMessages.FarmerIdRequired);

        ProductId = productId;
        Quantity = quantity;
        FarmerId = farmerId;
    }
}