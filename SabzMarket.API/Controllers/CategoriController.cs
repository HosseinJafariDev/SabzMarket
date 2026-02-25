using Microsoft.AspNetCore.Mvc;
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
        public async Task<OperationResult<List<GetAllCategoriesOutputDTO>>> GetAllCategoriesAsync()
        {
            var result = await _getAllCategoriesUseCase.ExecuteAsync();
            return result;
        }
    }
}
