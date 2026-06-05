using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string message)
            : base(message, OperationError.NotFound)
        {
        }

        public NotFoundException(string message, Exception exception)
            : base(message, OperationError.NotFound, exception)
        {
        }
    }
}
