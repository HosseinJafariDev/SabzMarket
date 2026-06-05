using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException(string message)
            : base(message, OperationError.Validation) { }

        public BadRequestException(string message, Exception exception)
            : base(message, OperationError.Validation, exception) { }
    }
}
