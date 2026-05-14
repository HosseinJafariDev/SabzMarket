using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.Login;
using SabzMarket.Application.UseCases.Auth.SignUp;

namespace SabzMarket.API.Controllers
{
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
        [HttpPost]
        public async Task<OperationResult> SignUpAsync([FromBody] SignUpInputDTO signUpInputDTO, CancellationToken token)
        {
            var result = await _signUpUseCase.ExecuteAsync(signUpInputDTO, token);
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> LoginAsync([FromBody] LoginInputDTO loginInputDTO, CancellationToken token)
        {
            var result = await _loginUseCase.ExecuteAsync(loginInputDTO, token);
            return result;
        }
    }
}
