using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Categories.GetCategory;

namespace SabzMarket.API.Controllers
{
    public class CategoriController : BaseController
    {
        public readonly IGetAllCategoriesUseCase _getAllCategoriesUseCase;
        public CategoriController(IGetAllCategoriesUseCase getAllCategoriesUseCase)
        {
            _getAllCategoriesUseCase = getAllCategoriesUseCase;
        }
        [HttpGet]
        public async Task<ApiResult<List<GetAllCategoriesOutputDTO>>> GetAllCategoriesAsync(CancellationToken token)
        {
            var result = await _getAllCategoriesUseCase.ExecuteAsync(token);
            return result.OperationResultTOApiResult();
        }
    }
}
