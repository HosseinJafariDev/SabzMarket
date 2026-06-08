using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UserIsSeller
{
    public class UserIsSellerUseCase : IUserIsSellerUseCase
    {
        private readonly ISellerRepository _sellerRepository;

        public UserIsSellerUseCase(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<OperationResult<bool>> ExecuteAsync(string username, CancellationToken token)
        {
            var result = await _sellerRepository.UserIsSellerAsync(username, token);

            return OperationResult<bool>.Success(result, OperationError.Success);
        }
    }
}