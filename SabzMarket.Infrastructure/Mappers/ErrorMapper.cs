using SabzMarket.Domain.Entities;
using SabzMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabzMarket.Infrastructure.Mappers
{
    public static class ErrorMapper
    {
        public static ErrorTable ExceptionToErrorDTO(this Exception ex,String layer)
        {
            return new ErrorTable
            {
                Layer = layer,
                Message = ex.InnerException?.Message ?? ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace
            };
        }
    }
}
