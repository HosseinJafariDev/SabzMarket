using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Share.Models
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public bool Result { get; set; }

        public static OperationResult SuccessedResult(
            string message = "")
        {
            return new OperationResult
            {
                Success = true,
                Message = message
            };

        }
        public static OperationResult Failed(
            string message = "")
        {
            return new OperationResult
            {
                Success = false,
                Message = message,
                Result = false
            };
        }
        public static OperationResult FailedResult(
           string message = "")
        {
            return new OperationResult
            {
                Success = false,
                Message = message,
                Result = true
            };
        }

    }
}
