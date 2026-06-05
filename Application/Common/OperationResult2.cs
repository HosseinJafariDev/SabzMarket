using SabzMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SabzMarket.Application.Common
{
    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; protected set; }

        protected OperationResult(bool isSuccess, T? data, OperationError operationError, string? message = null)
            : base(isSuccess, operationError, message)
        {
            Data = data;
        }

        public static OperationResult<T> Success(T data, OperationError operationError, string? message = null)
            => new OperationResult<T>(true, data, operationError, message);

        public static OperationResult<T> Failed(OperationError operationError, string? message = null)
            => new OperationResult<T>(false, default, operationError, message);
    }
}
