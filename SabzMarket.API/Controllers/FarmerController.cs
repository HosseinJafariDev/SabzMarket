using Microsoft.AspNetCore.Mvc;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.UseCases.Auth.UserIsFarmer;
using SabzMarket.Application.UseCases.Farmers.CreateFarmer;
using SabzMarket.Application.UseCases.Farmers.GetFarmer;
using SabzMarket.Application.UseCases.Farmers.UpdateFarmer;
using System.IO;
using System.IO.Pipes;

namespace SabzMarket.API.Controllers
{
    public class FarmerController : BaseController
    {
        private readonly IUserIsFarmerUseCase _userIsFarmerUseCase;
        private readonly ICreateFarmerUseCase _createFarmerUseCase;
        private readonly IGetFarmerByUsernameUseCase _getFarmerByUsernameUseCase;
        private readonly IUpdateFarmerUseCase _updateFarmerUseCase;
        public FarmerController(
            IUserIsFarmerUseCase userIsFarmerUseCase,
            ICreateFarmerUseCase createFarmerUseCase,
            IGetFarmerByUsernameUseCase getFarmerByUsernameUseCase,
            IUpdateFarmerUseCase updateFarmerUseCase)
        {
            _userIsFarmerUseCase = userIsFarmerUseCase;
            _createFarmerUseCase = createFarmerUseCase;
            _getFarmerByUsernameUseCase = getFarmerByUsernameUseCase;
            _updateFarmerUseCase = updateFarmerUseCase;
        }
        [HttpGet]
        public async Task<ApiResult> CheckUserExistsInFarmerAsync(string username, CancellationToken token)
        {
            var result = await _userIsFarmerUseCase.ExecuteAsync(username, token);
            return result.OperationResultTOApiResult();
        }
        [HttpPost]
        public async Task<ApiResult> CreateFarmerAsync(string username, [FromForm] CreateFarmerInputDTO farmer, IFormFile file, CancellationToken token)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }
            var result = await _createFarmerUseCase.ExecuteAsync(username, farmer, stream, token);
            return result.OperationResultTOApiResult();
        }
        [HttpGet]
        public async Task<ApiResult<GetFarmerByUsernameOutputDTO>> GetByUsernameAsync(string username, CancellationToken token)
        {
            var result = await _getFarmerByUsernameUseCase.ExecuteAsync(username, token);
            return result.OperationResultTOApiResult();
        }
        [HttpPost]
        public async Task<ApiResult> UpdateAsync([FromForm] UpdateFarmerInputDTO updateFarmerInputDTO, IFormFile file, CancellationToken token)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }
            var result = await _updateFarmerUseCase.ExecuteAsync(updateFarmerInputDTO, stream, token);
            return result.OperationResultTOApiResult();
        }
    }
}
