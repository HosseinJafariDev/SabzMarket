using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.CartItems.GetCartItem
{
    public interface ICartItemQueryService
    {
        public Task<List<GetCartItemByFarmerIdOutputDTO>> SelectByFarmerIdAsync(long farmerId, CancellationToken token);
    }
}
