using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.FeaturedSellers;
using SabzMarket.Domain.Entities.Orders;
using SabzMarket.Domain.Entities.Products;
using SabzMarket.Domain.Entities.Users;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Sellers
{
    public class Seller : BaseEntity
    {
        public long UserId { get; private set; }
        public string Address { get; private set; }
        public string? ProfileImage { get; private set; }
        public string WorkHistory { get; private set; }
        public User? User { get; private init; }

        private Seller()
        {
        }

        public Seller(long userId, string address, string profileImage, string workHistory)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new DomainException(SellerMessages.AddressRequired);
            if (string.IsNullOrWhiteSpace(workHistory))
                throw new DomainException(SellerMessages.WorkHistoryRequired);
            if (userId <= 0)
                throw new DomainException(SellerMessages.UserIdRequired);

            UserId = userId;
            Address = address;
            ProfileImage = profileImage;
            WorkHistory = workHistory;
        }
    }
}