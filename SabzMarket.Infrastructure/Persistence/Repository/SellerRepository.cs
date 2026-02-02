using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Share.Models;
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

        public async Task<OperationResult> UserExistsInSellerAsync(string username)
        {
            try
            {
                var result = await _context
                    .Sellers
                    .AsNoTracking()
                    .AnyAsync(s => s.User.UserName == username);
                return OperationResult.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }

        }

        public async Task<OperationResult> InsertAsync(SellerDTO sellerDto)
        {
            try
            {
                var user = await _context
                    .Users
                    .FirstAsync(us => us.UserName == sellerDto.Username);
                Seller seller = new Seller
                {
                    Address = sellerDto.Address,
                    ProfileImage = sellerDto.ProfileImage,
                    UserId = user.Id,
                    WorkHistory = sellerDto.WorkHistory,
                    User = user
                };
                _context.Sellers.Add(seller);
                await _context.SaveChangesAsync();
                return OperationResult.SuccessedResult(true);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }


        }

        public async Task<OperationResult<SellerDTO>> SelectByUsernameAsync(string username)
        {
            try
            {
                var seller = await _context
                    .Sellers
                    .AsNoTracking()
                    .Include(us => us.User)
                    .Where(s => s.User.UserName == username)
                    .Select(s => new SellerDTO
                    {
                        UserId = s.UserId,
                        FirstName = s.User.FirstName,
                        LastName = s.User.LastName,
                        Phone = s.User.Phone,
                        Address = s.Address,
                        ProfileImage = s.ProfileImage,
                        Email = s.User.Email,
                        Password = s.User.Password,
                        Username = s.User.UserName,
                        WorkHistory = s.WorkHistory,
                        Id = s.Id
                    }).SingleOrDefaultAsync();

                return OperationResult<SellerDTO>.SuccessedResult(seller);
            }
            catch (Exception ex)
            {
                return OperationResult<SellerDTO>.Failed(GetType().Name, ex);
            }


        }

        public async Task<OperationResult> UpdateAsync(UserDTO userDto, SellerDTO sellerDto)
        {
            try
            {
                var seller = new Seller { Id = sellerDto.Id };
                _context.Attach(seller);
                seller.Address = sellerDto.Address!;
                seller.ProfileImage = sellerDto.ProfileImage!;
                seller.WorkHistory = sellerDto.WorkHistory!;

                var entrySeller = _context.Entry(seller);
                entrySeller.Property(x => x.Address).IsModified = true;
                entrySeller.Property(x => x.ProfileImage).IsModified = true;
                entrySeller.Property(x => x.WorkHistory).IsModified = true;

                var user = new User { Id = userDto.Id };
                _context.Attach(user);
                user.UserName = userDto.UserName;
                user.Password = userDto.Password;
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Email = userDto.Email;
                user.Phone = userDto.Phone;

                var entryUser = _context.Entry(user);
                entryUser.Property(x => x.UserName).IsModified = true;
                entryUser.Property(x => x.Password).IsModified = true;
                entryUser.Property(x => x.FirstName).IsModified = true;
                entryUser.Property(x => x.LastName).IsModified = true;
                entryUser.Property(x => x.Email).IsModified = true;
                entryUser.Property(x => x.Phone).IsModified = true;

                await _context.SaveChangesAsync();
                return OperationResult<SellerDTO>.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }




        }

        public async Task<OperationResult<List<SellerDTO>>> SelectByPhoneNumberAsync(string phone)
        {
            try
            {
                var result = await _context.Sellers.AsNoTracking().Where(x => x.User!.Phone == phone).Select(x => new SellerDTO()
                {
                    Id = x.Id,
                    Address = x.Address,
                    Email = x.User!.Email,
                    Phone = x.User.Phone,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    ProfileImage = x.ProfileImage,
                    WorkHistory = x.WorkHistory

                }).ToListAsync();
                return OperationResult<List<SellerDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<List<SellerDTO>>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<SellerDTO>> SelectByIdAsync(long id)
        {
            try
            {
                var result = await _context.Sellers.AsNoTracking().Where(x => x.Id == id).Select(x => new SellerDTO()
                {
                    Address = x.Address,
                    Email = x.User!.Email,
                    FirstName = x.User.FirstName,
                    UserId = x.User.Id,
                    Id = id,
                    LastName = x.User.LastName,
                    Phone = x.User.Phone,
                    ProfileImage = x.ProfileImage,
                    WorkHistory = x.WorkHistory,
                    Username = x.User.UserName
                }).SingleAsync();
                return OperationResult<SellerDTO>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<SellerDTO>.Failed(GetType().Name, ex);
            }
        }
    }
}
