using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Services
{
    public interface IConnectionManager
    {
        public void AddOrUpdate(string userId, string connectionId);
        public void RemoveByConnectionId(string connectionId);
        public string? GetConnectionId(string userId);
        public string? GetUserId(string connection);
    }
}
