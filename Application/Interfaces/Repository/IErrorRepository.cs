using SabzMarket.Application.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Repository
{
    public interface IErrorRepository
    {
        Task<string> LogErrorAsync(Exception ex, String layer);
    }
}
