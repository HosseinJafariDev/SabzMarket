using Microsoft.EntityFrameworkCore;
using SabzMarket.Application.UseCases.Farmers.GetFarmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Persistence.QueryServices
{
    public class FarmerQueryService : IFarmerQueryService
    {
        private readonly SabzMarketDbContext _dbContext;
        public FarmerQueryService(SabzMarketDbContext sabzMarketDbContext)
        {
            _dbContext = sabzMarketDbContext;
        }

        public async Task<GetFarmerByUsernameOutputDTO> SelectByUsernameAsync(string username, CancellationToken token)
        {
            var result = await _dbContext
                    .Farmers
                    .AsNoTracking()
                    .Include(x => x.User)
                    .Where(f => f.User!.UserName == username)
                    .Select(f => new GetFarmerByUsernameOutputDTO()
                    {
                        Id = f.Id,
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
                    }).SingleAsync(token);

            return result;
        }
    }
}
