using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
using SabzMarket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly SabzMarketDbContext _context;
        public SellerRepository(SabzMarketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UserIsSellerAsync(string username)
        {
            var result = await _context
                .Sellers
                .AsNoTracking()
                .AnyAsync(s => s.User!.UserName == username);
            return result;
        }

        public async Task InsertAsync(string username, Seller seller, CancellationToken token)
        {
            var user = await _context
                .Users
                .FirstAsync(us => us.UserName == username);

            SellerTable sellerTable = new SellerTable
            {
                Address = seller.Address,
                ProfileImage = seller.ProfileImage,
                UserId = user.Id,
                WorkHistory = seller.WorkHistory,
                User = user
            };
            _context.Sellers.Add(sellerTable);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> SelectByUsernameAsync(string username, CancellationToken token)
        {
            var seller = await _context
                .Sellers
                .AsNoTracking()
                .Include(us => us.User)
                .Where(s => s.User!.UserName == username)
                .Select(s => new Seller
                {
                    UserId = s.UserId,
                    Users = new User()
                    {
                        Email = s.User!.Email,
                        FirstName = s.User.FirstName,
                        Id = s.UserId,
                        LastName = s.User.LastName,
                        Password = s.User.Password,
                        Phone = s.User.Phone,
                        UserName = s.User.UserName
                    },
                    Address = s.Address,
                    ProfileImage = s.ProfileImage,
                    WorkHistory = s.WorkHistory,
                    Id = s.Id
                }).SingleOrDefaultAsync();
            return seller!;
        }

        public async Task UpdateAsync(Seller seller, CancellationToken token)
        {
            var sellerTable = new SellerTable { Id = seller.Id };
            _context.Attach(sellerTable);
            sellerTable.Address = seller.Address!;
            sellerTable.ProfileImage = seller.ProfileImage!;
            sellerTable.WorkHistory = seller.WorkHistory!;

            var entrySeller = _context.Entry(sellerTable);
            entrySeller.Property(x => x.Address).IsModified = true;
            entrySeller.Property(x => x.ProfileImage).IsModified = true;
            entrySeller.Property(x => x.WorkHistory).IsModified = true;

            await _context.SaveChangesAsync();
        }

        public async Task<List<Seller>> SelectByPhoneNumberAsync(string phone, CancellationToken token)
        {
            var result = await _context
                .Sellers
                .AsNoTracking()
                .Where(x => x.User!.Phone == phone)
                .Select(x => new Seller()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    Address = x.Address,
                    ProfileImage = x.ProfileImage,
                    WorkHistory = x.WorkHistory,
                    Users = new User()
                    {
                        Email = x.User!.Email,
                        Phone = x.User.Phone,
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                    }
                }).ToListAsync();
            return result;
        }

        public async Task<Seller> SelectByIdAsync(long id, CancellationToken token)
        {
            var result = await _context.Sellers.AsNoTracking().Where(x => x.Id == id).Select(x => new Seller()
            {
                Id = id,
                UserId = x.User!.Id,
                ProfileImage = x.ProfileImage,
                WorkHistory = x.WorkHistory,
                Address = x.Address,
                Users = new User()
                {
                    Email = x.User!.Email,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    Phone = x.User.Phone,
                    UserName = x.User.UserName
                }
            }).SingleOrDefaultAsync();
            return result;
        }
    }
}
