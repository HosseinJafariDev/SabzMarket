using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Categories.GetCategory
{
    public interface IGetAllCategoriesUseCase
    {
        Task<OperationResult<List<GetAllCategoriesOutputDTO>>> ExecuteAsync();
    }
}
