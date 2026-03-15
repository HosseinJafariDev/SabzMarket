using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.UseCases.CartItems.GetCartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.QueryServices
{
    public class CartItemQueryService : ICartItemQueryService
    {
        private readonly SabzMarketDbContext _context;
        public CartItemQueryService(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetCartItemByFarmerIdOutputDTO>> SelectByFarmerIdAsync(long farmerId)
        {
            var result = await _context
               .CartItems
               .AsNoTracking()
               .Include(x=>x.Product)
               .Where(x =>
               x.FarmerId == farmerId &&
               x.Product.IsDeleted == false)
               .Select(x => new GetCartItemByFarmerIdOutputDTO()
               {
                   Id = x.Id,
                   FarmerId = farmerId,
                   SellerId = x.Product.SellerId,
                   AddedDate = x.AddedDate,
                   ProductId = x.ProductId,
                   ProductImage = x.Product.ImageProduct,
                   ProductName = x.Product.ProductName,
                   ProductPrice = x.Product.Price,
                   Quantity = x.Quantity,
                   ProducNumber = x.Product.Number
               }).ToListAsync();
            return result;
        }
    }
}
