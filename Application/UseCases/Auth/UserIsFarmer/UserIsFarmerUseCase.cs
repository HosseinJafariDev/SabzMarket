using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.UserIsFarmer
{
    public class UserIsFarmerUseCase : IUserIsFarmerUseCase
    {
        private readonly IFarmerRepository _farmerRepository;

        public UserIsFarmerUseCase(IFarmerRepository farmerRepository)
        {
            _farmerRepository = farmerRepository;
        }

        public async Task<OperationResult<bool>> ExecuteAsync(string username, CancellationToken token)
        {
            var result = await _farmerRepository.UserExistsInFarmerAsync(username, token);

            return OperationResult<bool>.Success(result, OperationError.Success);
        }
    }
}