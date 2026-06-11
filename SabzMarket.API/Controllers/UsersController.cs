using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Users.GetUser;

namespace SabzMarket.API.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IGetUserByUserNameUseCase _getUserByUserNameUseCase;

        public UsersController(IGetUserByUserNameUseCase getUserByUserNameUseCase)
        {
            _getUserByUserNameUseCase = getUserByUserNameUseCase;
        }

        [HttpGet("{username}")]
        public async Task<ApiResult<GetUserByUserNameOutputDTO>> GetByUsername(string username, CancellationToken token)
        {
            var result = await _getUserByUserNameUseCase.ExecuteAsync(username, token);
            return result.OperationResultTOApiResult();
        }
    }
}