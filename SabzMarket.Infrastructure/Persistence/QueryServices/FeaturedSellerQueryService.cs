using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller;

namespace SabzMarket.Infrastructure.Persistence.QueryServices
{
    public class FeaturedSellerQueryService : IFeaturedSellerQueryService
    {
        private readonly SabzMarketDbContext _context;
        public FeaturedSellerQueryService(SabzMarketDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetAllFeaturedSellerOutputDTO>> SelectAllSellerAsync()
        {
            var now = DateTime.UtcNow;
            var result = await _context
            .FeaturedSellers
            .Where(x => x.IsActive && x.StartDate <= now && x.EndDate >= now)
            .AsNoTracking()
            .Select(s =>
            new GetAllFeaturedSellerOutputDTO()
            {
                SellerId = s.Seller!.Id,
                UserId = s.Seller!.UserId,
                ProfileImage = s.Seller.ProfileImage,
                FirstName = s.Seller.User!.FirstName,
                LastName = s.Seller.User!.LastName,
            }).ToListAsync();

            return result;
        }
    }
}
