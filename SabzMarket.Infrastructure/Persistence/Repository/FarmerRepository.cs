using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.DAL.Entities;
using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
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

        public async Task InsertAsync(string username, Farmer farmer)
        {
            var user = await _dbContext.Users.SingleAsync(x => x.UserName == username);
            FarmerTable farmerTable = new FarmerTable()
            {
                UserId = user.Id,
                Address = farmer.Address,
                CodePosti = farmer.CodePosti,
                DataBuilt = farmer.DataBuilt,
                LandArea = farmer.LandArea,
                NationalCode = farmer.NationalCode,
                ProfileImage = farmer.ProfileImage,
                CodParvaneBHB = farmer.CodParvaneBHB,
            };

            _dbContext.Add(farmerTable);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Farmer farmer)
        {
            var farmerTable = new FarmerTable { Id = farmer.Id };
            _dbContext.Attach(farmer);
            farmer.Address = farmer.Address;
            farmer.CodePosti = farmer.CodePosti;
            farmer.ProfileImage = farmer.ProfileImage;
            var entryFarmer = _dbContext.Entry(farmer);
            entryFarmer.Property(x => x.Address).IsModified = true;
            entryFarmer.Property(x => x.CodePosti).IsModified = true;
            entryFarmer.Property(x => x.ProfileImage).IsModified = true;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UserExistsInFarmerAsync(string username)
        {
            var result = await _dbContext
                .Farmers
                .AsNoTracking()
                .AnyAsync(f => f.User!.UserName == username);

            return result;
        }
    }
}
