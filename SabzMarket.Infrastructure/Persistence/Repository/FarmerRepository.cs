using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Infrastructure.Persistence;
using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.Repository
{
    public class FarmerRepository : IFarmerRepository
    {
        private readonly SabzMarketDbContext _dbContext;
        public FarmerRepository(SabzMarketDbContext sabzMarketDbContext)
        {
            _dbContext = sabzMarketDbContext;
        }

        public async Task<OperationResult> InsertAsync(string username, FarmerDTO farmer)
        {
            try
            {
                var user = await _dbContext.Users.SingleAsync(x => x.UserName == username);
                Farmer farmer1 = new Farmer()
                {
                    CodParvaneBHB = farmer.CodParvaneBHB,
                    UserId = user.Id,
                    Address = farmer.Address,
                    CodePosti = farmer.CodePosti,
                    DataBuilt = farmer.DataBuilt,
                    LandArea = farmer.LandArea,
                    NationalCode = farmer.NationalCode,
                    ProfileImage = farmer.ProfileImage,
                };
                _dbContext.Add(farmer1);
                var result = await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult<FarmerDTO>> SelectByUsernameAsync(string username)
        {
            try
            {
                var result = await _dbContext
                    .Farmers
                    .AsNoTracking()
                    .Include(x => x.User)
                    .Where(f => f.User!.UserName == username)
                    .Select(f => new FarmerDTO()
                    {
                        Id= f.Id,
                        UserId = f.UserId,
                        UserName = f.User!.UserName,
                        Address = f.Address!,
                        CodePosti = f.CodePosti,
                        CodParvaneBHB = f.CodParvaneBHB,
                        DataBuilt = f.DataBuilt!,
                        LandArea = f.LandArea,
                        NationalCode = f.NationalCode,
                        ProfileImage = f.ProfileImage,
                        Email = f.User.Email,
                        FirstName = f.User.FirstName,
                        LastName = f.User.LastName,
                        Password = f.User.Password,
                        Phone = f.User.Phone
                    }).SingleAsync();
                return OperationResult<FarmerDTO>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult<FarmerDTO>.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> UpdateAsync(FarmerDTO farmerDTO)
        {
            try
            {
                var farmer = new Farmer { Id = farmerDTO.Id };
                _dbContext.Attach(farmer);
                farmer.Address = farmerDTO.Address;
                farmer.CodePosti = farmerDTO.CodePosti;
                farmer.ProfileImage = farmerDTO.ProfileImage;
                var entryFarmer = _dbContext.Entry(farmer);
                entryFarmer.Property(x => x.Address).IsModified = true;
                entryFarmer.Property(x => x.CodePosti).IsModified = true;
                entryFarmer.Property(x => x.ProfileImage).IsModified = true;
                
                var user=new User { Id=farmerDTO.UserId};
                _dbContext.Attach(user);
                user.FirstName = farmerDTO.FirstName;
                user.Email = farmerDTO.Email;
                user.LastName = farmerDTO.LastName;
                user.Password = farmerDTO.Password;
                user.UserName = farmerDTO.UserName;
                user.Phone = farmerDTO.Phone;
                var entryUser = _dbContext.Entry(user);
                entryUser.Property(x => x.FirstName).IsModified = true;
                entryUser.Property(x => x.Email).IsModified = true;
                entryUser.Property(x => x.LastName).IsModified = true;
                entryUser.Property(x => x.Password).IsModified = true;
                entryUser.Property(x => x.UserName).IsModified = true;
                entryUser.Property(x => x.Phone).IsModified = true;
                
                await _dbContext.SaveChangesAsync();
                return OperationResult.SuccessedResult();
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }

        public async Task<OperationResult> UserExistsInFarmerAsync(string username)
        {
            try
            {
                var result = await _dbContext
                    .Farmers
                    .AsNoTracking()
                    .Where(f => f.User!.UserName == username)
                    .AnyAsync();
                return OperationResult.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                return OperationResult.Failed(GetType().Name, ex);
            }
        }
    }
}
