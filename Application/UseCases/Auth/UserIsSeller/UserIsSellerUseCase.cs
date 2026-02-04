using Application.Interfaces.Services;
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
        private readonly IErrorService _errorService;
        public UserIsSellerUseCase(ISellerRepository sellerRepository, IErrorService errorService)
        {
            _errorService = errorService;
            _sellerRepository = sellerRepository;
        }
        public async Task<OperationResult> ExecuteAsync(string username)
        {
            try
            {
                var result = await _sellerRepository.UserIsSellerAsync(username);
                if (result)
                {
                    return OperationResult.SuccessedResult();
                }
                return OperationResult.FailedResult();
            }
            catch (Exception ex)
            {
                var errorResult = await _errorService.LogErrorAsync(ex,GetType().Name);
                return OperationResult.Failed(errorResult.Message!.ErrorMessage());
            }
        }
    }
}
