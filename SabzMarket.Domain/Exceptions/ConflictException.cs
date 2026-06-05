using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Exceptions
{
    public class ConflictException : AppException
    {
        public ConflictException(string message)
            : base(message, OperationError.Conflict)
        {
        }

        public ConflictException(string message, Exception exception)
            : base(message, OperationError.Conflict, exception)
        {
        }
    }
}
