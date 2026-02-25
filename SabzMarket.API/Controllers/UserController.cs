using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<OperationResult<GetUserByUserNameOutputDTO>> GetUserAsync(string username)
        {
            var result = await _getUserByUserNameUseCase.ExecuteAsync(username);
            return result;
        }
    }
}
