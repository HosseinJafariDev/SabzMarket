using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.CreateFarmer
{
    public interface ICreateFarmerUseCase
    {
        Task<OperationResult> ExecuteAsync(string username, CreateFarmerInputDTO createFarmerInputDTO, Stream stream, CancellationToken token);
    }
}
