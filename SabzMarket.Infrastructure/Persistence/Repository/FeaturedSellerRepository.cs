using Application.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Migrations;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Share.Models;
using SabzMarket.Share.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class FeaturedSellerRepository : IFeaturedSellerRepository
    {
        private readonly SabzMarketDbContext _context;
        public FeaturedSellerRepository(SabzMarketDbContext context) 
        {
            _context=context;
        }
        public async Task<OperationResult<List<SellerDTO>>> SelectAllSellerAsync()
        {
            try
            {
                var result = await _context
                .FeaturedSellers
                .AsNoTracking()
                .Select(s =>
                new SellerDTO()
                {
                    Id = s.Seller!.Id,
                    UserId = s.Seller!.UserId,
                    ProfileImage = s.Seller.ProfileImage,
                    FirstName = s.Seller.User!.FirstName,
                    LastName = s.Seller.User!.LastName,
                }).ToListAsync();
                return OperationResult<List<SellerDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<List<SellerDTO>>.Failed(GetType().Name, ex);
            }
        }
    }
}
