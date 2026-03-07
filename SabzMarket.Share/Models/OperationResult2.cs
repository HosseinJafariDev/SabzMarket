using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SabzMarket.Share.Models
{
    public class OperationResult<t> : OperationResult
    {
        public t Data { get; set; }
        public static OperationResult<t> SuccessedResult(
             t data, string message = "")
        {
            return new OperationResult<t>
            {
                Success = true,
                Message = message,
                Data = data,
            };
        }
        public static OperationResult<t> Failed(
           string message = "")
        {
            return new OperationResult<t>
            {
                Success = false,
                Message = message,
                Result = false
            };
        }
        public static OperationResult<t> FailedResult(
                string message = "")
        {
            return new OperationResult<t>
            {
                Success = false,
                Message = message,
                Result = true
            };
        }
    }
}
