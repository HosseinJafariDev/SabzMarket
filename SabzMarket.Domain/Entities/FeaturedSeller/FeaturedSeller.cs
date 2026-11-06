using SabzMarket.Domain.Entities.Base;

namespace SabzMarket.Domain.Entities.FeaturedSeller;

public class FeaturedSeller : BaseEntity<int>
{
    public long SellerId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActive { get; private set; } = true;

    public Seller.Seller? Seller { get; private init; }

    private FeaturedSeller()
    {
    }

    public FeaturedSeller(long sellerId, DateTime startDate, DateTime endDate)
    {
        if (sellerId <= 0)
            throw new ArgumentException(FeaturedSellerDomainMessages.SellerIdRequired);

        if (startDate <= endDate)
            throw new ArgumentException(FeaturedSellerDomainMessages.InvalidDateRange);

        SellerId = sellerId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void Active() => IsActive = true;
    public void Inactive() => IsActive = false;
}