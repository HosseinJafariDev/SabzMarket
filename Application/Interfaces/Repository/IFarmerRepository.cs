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
        public Task<bool> UserExistsInFarmerAsync(string username, CancellationToken token);
        public Task InsertAsync(string username, Farmer farmer, CancellationToken token);
        public Task UpdateAsync(Farmer farmer, CancellationToken token);
    }
}
