using SabzMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface ISellerRepository
    {
        Task InsertAsync(string username, Seller seller);
        Task<bool> UserIsSellerAsync(string username);
        Task<Seller> SelectByUsernameAsync(string username);
        Task UpdateAsync(Seller seller);
        Task<List<Seller>> SelectByPhoneNumberAsync(string phone);
        Task<Seller> SelectByIdAsync(long id);
    }
}
