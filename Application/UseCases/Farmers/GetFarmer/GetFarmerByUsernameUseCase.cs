using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
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
        private readonly IErrorRepository _errorRepository;
        public GetFarmerByUsernameUseCase(IFarmerQueryService farmerQueryService, IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
            _farmerQueryService = farmerQueryService;
        }
        public async Task<OperationResult<GetFarmerByUsernameOutputDTO>> ExecuteAsync(string username, CancellationToken token)
        {
            try
            {
                var farmer = await _farmerQueryService.SelectByUsernameAsync(username, token);
                return OperationResult<GetFarmerByUsernameOutputDTO>.SuccessedResult(farmer);
            }
            catch (Exception ex)
            {
                var errorResult = await _errorRepository.LogErrorAsync(ex.ExceptionToErrorDTO(GetType().Name));
                return OperationResult<GetFarmerByUsernameOutputDTO>.Failed(errorResult.ErrorMessage());
            }
        }
    }
}
