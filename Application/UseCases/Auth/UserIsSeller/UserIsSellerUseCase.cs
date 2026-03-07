using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
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
        private readonly IErrorRepository _errorRepository;
        public UserIsSellerUseCase(ISellerRepository sellerRepository, IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
            _sellerRepository = sellerRepository;
        }
        public async Task<OperationResult<bool>> ExecuteAsync(string username)
        {
            try
            {
                var result = await _sellerRepository.UserIsSellerAsync(username);

                return OperationResult<bool>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<bool>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
