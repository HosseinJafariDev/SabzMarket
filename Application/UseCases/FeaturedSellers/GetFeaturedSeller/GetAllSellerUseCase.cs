using Microsoft.IdentityModel.Tokens.Experimental;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller
{
    public class GetAllSellerUseCase : IGetAllSellerUseCase
    {
        private readonly IFeaturedSellerQueryService _featuredSellerQueryService;

        public GetAllSellerUseCase(IFeaturedSellerQueryService featuredSellerQueryService)
        {
            _featuredSellerQueryService = featuredSellerQueryService;
        }

        public async Task<OperationResult<List<GetAllFeaturedSellerOutputDTO>>> ExecuteAsync(CancellationToken token)
        {
            var result = await _featuredSellerQueryService.SelectAllSellerAsync(token);
            return OperationResult<List<GetAllFeaturedSellerOutputDTO>>.Success(result, OperationError.Success);
        }
    }
}