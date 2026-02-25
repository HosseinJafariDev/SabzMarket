using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.UpdateFarmer
{
    public interface IUpdateFarmerUseCase
    {
        Task<OperationResult> ExecuteAsync(string username, UpdateFarmerInputDTO updateFarmerInputDTO);
    }
}
