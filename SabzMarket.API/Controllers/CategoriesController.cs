using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Categories.GetCategory;

namespace SabzMarket.API.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        private readonly IGetAllCategoriesUseCase _getAllCategoriesUseCase;

        public CategoriesController(IGetAllCategoriesUseCase getAllCategoriesUseCase)
        {
            _getAllCategoriesUseCase = getAllCategoriesUseCase;
        }

        [HttpGet]
        public async Task<ApiResult<List<GetAllCategoriesOutputDTO>>> GetAllCategories(CancellationToken token)
        {
            var result = await _getAllCategoriesUseCase.ExecuteAsync(token);
            return result.OperationResultTOApiResult();
        }
    }
}