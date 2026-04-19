using Microsoft.AspNetCore.Mvc;
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
        public async Task<OperationResult> CheckUserExistsInFarmerAsync(string username)
        {
            var result = await _userIsFarmerUseCase.ExecuteAsync(username);
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> CreateFarmerAsync(string username, [FromForm] CreateFarmerInputDTO farmer, IFormFile file)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }
            var result = await _createFarmerUseCase.ExecuteAsync(username, farmer, stream);
            return result;
        }
        [HttpGet]
        public async Task<OperationResult<GetFarmerByUsernameOutputDTO>> GetByUsernameAsync(string username)
        {
            var result = await _getFarmerByUsernameUseCase.ExecuteAsync(username);
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> UpdateAsync([FromForm] UpdateFarmerInputDTO updateFarmerInputDTO, IFormFile file)
        {
            Stream stream = null;
            if (file != null)
            {
                stream = file.OpenReadStream();
            }
            var result = await _updateFarmerUseCase.ExecuteAsync(updateFarmerInputDTO, stream);
            return result;
        }
    }
}
