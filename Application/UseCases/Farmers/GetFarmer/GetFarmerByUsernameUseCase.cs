using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.GetFarmer
{
    public class GetFarmerByUsernameUseCase : IGetFarmerByUsernameUseCase
    {
        private readonly IFarmerQueryService _farmerQueryService;

        public GetFarmerByUsernameUseCase(IFarmerQueryService farmerQueryService)
        {
            _farmerQueryService = farmerQueryService;
        }

        public async Task<OperationResult<GetFarmerByUsernameOutputDTO>> ExecuteAsync(string username,
            CancellationToken token)
        {
            var farmer = await _farmerQueryService.SelectByUsernameAsync(username, token);
            return OperationResult<GetFarmerByUsernameOutputDTO>.Success(farmer, OperationError.Success);
        }
    }
}