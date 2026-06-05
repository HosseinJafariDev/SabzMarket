using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Domain.Exceptions
{
    public class AppException : Exception
    {
        public OperationError StatusCode { get; set; }
        public AppException(string message, OperationError statusCode, Exception exception)
            : base(message, exception)
        {
            StatusCode = statusCode;
        }
        public AppException(string message, OperationError statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
