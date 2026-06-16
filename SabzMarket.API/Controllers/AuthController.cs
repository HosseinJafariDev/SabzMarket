using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.Login;
using SabzMarket.Application.UseCases.Auth.SignUp;

namespace SabzMarket.API.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        private readonly ISignUpUseCase _signUpUseCase;
        private readonly ILoginUseCase _loginUseCase;

        public AuthController(
            ISignUpUseCase signUpUseCase,
            ILoginUseCase loginUseCase)
        {
            _signUpUseCase = signUpUseCase;
            _loginUseCase = loginUseCase;
        }

        [HttpPost("signup")]
        public async Task<ApiResult> SignUp([FromBody] SignUpInputDTO signUpInputDTO, CancellationToken token)
        {
            var result = await _signUpUseCase.ExecuteAsync(signUpInputDTO, token);
            return result.OperationResultTOApiResult();
        }

        [HttpPost("login")]
        public async Task<ApiResult> Login([FromBody] LoginInputDTO loginInputDTO, CancellationToken token)
        {
            var result = await _loginUseCase.ExecuteAsync(loginInputDTO, token);
            return result.OperationResultTOApiResult();
        }
    }
}