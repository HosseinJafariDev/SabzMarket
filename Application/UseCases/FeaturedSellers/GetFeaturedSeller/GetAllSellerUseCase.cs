using Microsoft.IdentityModel.Tokens.Experimental;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller
{
    public class GetAllSellerUseCase : IGetAllSellerUseCase
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IFeaturedSellerQueryService _featuredSellerQueryService;
        public GetAllSellerUseCase(IErrorRepository errorRepository, IFeaturedSellerQueryService featuredSellerQueryService)
        {
            _errorRepository = errorRepository;
            _featuredSellerQueryService = featuredSellerQueryService;
        }
        public async Task<OperationResult<List<GetAllFeaturedSellerOutputDTO>>> ExecuteAsync()
        {
            try
            {
                var result = await _featuredSellerQueryService.SelectAllSellerAsync();
                return OperationResult<List<GetAllFeaturedSellerOutputDTO>>.SuccessedResult(result);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<List<GetAllFeaturedSellerOutputDTO>>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
