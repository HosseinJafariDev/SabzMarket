using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.Common
{
    public class OperationResult
    {
        public bool Success { get;  set; }
        public bool Result { get; set; }
        public string? Message { get;  set; }
        public Exception? Exception { get;  set; }

        public static OperationResult SuccessedResult(bool success= true,
            string message = "")
        {
            return new OperationResult
            {
                Success = success,
                Message = message
                ,Result=true
            };

        }
        public static OperationResult Failed(
            string message = "", Exception? ex=null)
        {
            return new OperationResult
            {
                Success = false,
                Message = message,
                Exception=ex,
                Result=false
            };
        }
        public static OperationResult FailedResult(
           string message = "")
        {
            return new OperationResult
            {
                Success = false,
                Message = message,
                Result=true
            };
        }

    }
}
