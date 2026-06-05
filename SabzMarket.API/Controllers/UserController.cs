using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Users.GetUser;
namespace SabzMarket.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IGetUserByUserNameUseCase _getUserByUserNameUseCase;
        public UserController(IGetUserByUserNameUseCase getUserByUserNameUseCase)
        {
            _getUserByUserNameUseCase = getUserByUserNameUseCase;
        }
        [HttpGet]
        public async Task<ApiResult<GetUserByUserNameOutputDTO>> GetUserAsync(string username, CancellationToken token)
        {
            var result = await _getUserByUserNameUseCase.ExecuteAsync(username, token);
            return result.OperationResultTOApiResult();
        }
    }
}
