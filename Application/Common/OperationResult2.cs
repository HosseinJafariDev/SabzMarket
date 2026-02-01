using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SabzMarket.Application.Common
{
    public class OperationResult<t>: OperationResult
    {
            public t Data { get; set; }
            public static OperationResult<t> SuccessedResult(
                 t data, string message = "")
            {
                return new OperationResult<t>
                {
                    Success = true,
                    Message = message,
                    Data = data
                    ,Result=true
                };
            }
        public static OperationResult<t> Failed(
           string message = "", Exception? ex = null)
        {
            return new OperationResult<t>
            {
                Success = false,
                Message = message,
                Exception = ex,
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
                   Result=true
                };
            }
    }
}
