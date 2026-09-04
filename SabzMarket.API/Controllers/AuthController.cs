using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.Login;
using SabzMarket.Application.UseCases.Auth.SignUp;

namespace SabzMarket.API.Controllers
{
    [Authorize]
    public class AuthController(ISignUpUseCase signUpUseCase, ILoginUseCase loginUseCase) : BaseController
    {
        [HttpPost("signup")]
        public async Task<ApiResult> SignUp([FromBody] SignUpInputDto signUpInputDto, CancellationToken token)
        {
            await signUpUseCase.ExecuteAsync(signUpInputDto, token);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ApiResult> Login([FromBody] LoginInputDto loginInputDto, CancellationToken token)
        {
            var result = await loginUseCase.ExecuteAsync(loginInputDto, token);
            return Ok(result);
        }
    }
}