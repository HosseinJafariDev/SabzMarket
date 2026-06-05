using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Common
{
    public class OperationResult
    {
        public bool IsSuccess { get; protected set; }
        public string? Message { get; protected set; }
        public OperationError OperationError { get; protected set; }

        protected OperationResult(bool isSuccess, OperationError operationError, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            OperationError = operationError;
        }

        public static OperationResult Success(OperationError operationError, string? message = null)
            => new OperationResult(true, operationError, message);

        public static OperationResult Failed(OperationError operationError, string? message = null)
            => new OperationResult(false, operationError, message);
    }
}
