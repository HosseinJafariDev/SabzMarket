using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Farmers;
using SabzMarket.Domain.Entities.Products;

namespace SabzMarket.Domain.Entities.CartItems
{
    public class CartItem : BaseEntity<int>
    {
        public long FarmerId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }

        public Farmer? Farmer { get; private init; }
        public Product? Product { get; private init; }

        private CartItem()
        {
        }

        public CartItem(long productId, int quantity, long farmerId)
        {
            if (productId <= 0)
                throw new ArgumentException(CartItemMessages.ProductIdRequired);

            if (quantity <= 0)
                throw new ArgumentException(CartItemMessages.QuantityRequired);

            if (farmerId <= 0)
                throw new ArgumentException(CartItemMessages.FarmerIdRequired);

            ProductId = productId;
            Quantity = quantity;
            FarmerId = farmerId;
        }
    }
}