using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Interfaces.Services
{
    public interface IFileLogService
    {
        public Task<string> SaveFailedLogAsync(ErrorLogDTO errorLogDTO);
    }
}
