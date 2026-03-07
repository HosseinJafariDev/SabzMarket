using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share.Mappers
{
    public static class ErrorMapper
    {
        public static ErrorLogDTO ExceptionToErrorDTO(this Exception ex, String layer)
        {
            return new ErrorLogDTO
            {
                Layer = layer,
                Message = ex.InnerException?.Message ?? ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace,
            };
        }
    }
}
