using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.FeaturedSellers.GetFeaturedSeller;

namespace SabzMarket.API.Controllers
{
    public class FeaturedSellerController : BaseController
    {
        private readonly IGetAllSellerUseCase _getAllSellerUseCase;
        public FeaturedSellerController(IGetAllSellerUseCase getAllSellerUseCase)
        {
            _getAllSellerUseCase = getAllSellerUseCase;
        }
        [HttpGet]
        public async Task<ApiResult<List<GetAllFeaturedSellerOutputDTO>>> GetAllSellerAsync(CancellationToken token)
        {
            var result = await _getAllSellerUseCase.ExecuteAsync(token);
            return result.OperationResultTOApiResult();
        }
    }
}
