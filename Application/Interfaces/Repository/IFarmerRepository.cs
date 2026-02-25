using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IFarmerRepository
    {
        public Task<bool> UserExistsInFarmerAsync(string username);
        public Task InsertAsync(string username,Farmer farmer);
        public Task UpdateAsync(Farmer farmer);
    }
}
