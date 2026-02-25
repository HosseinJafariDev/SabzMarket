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
        public async Task<OperationResult> SignUpAsync([FromBody] SignUpInputDTO signUpInputDTO)
        {
            var result = await _signUpUseCase.ExecuteAsync(signUpInputDTO);
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> LoginAsync([FromBody] LoginInputDTO loginInputDTO)
        {
            var result = await _loginUseCase.ExecuteAsync(loginInputDTO);
            return result;
        }
    }
}
