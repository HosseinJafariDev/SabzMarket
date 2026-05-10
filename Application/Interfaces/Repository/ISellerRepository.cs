using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISellerRepository
    {
        Task InsertAsync(string username, Seller seller, CancellationToken token);
        Task<bool> UserIsSellerAsync(string username);
        Task<Seller> SelectByUsernameAsync(string username, CancellationToken token);
        Task UpdateAsync(Seller seller, CancellationToken token);
        Task<List<Seller>> SelectByPhoneNumberAsync(string phone, CancellationToken token);
        Task<Seller> SelectByIdAsync(long id, CancellationToken token);
    }
}
