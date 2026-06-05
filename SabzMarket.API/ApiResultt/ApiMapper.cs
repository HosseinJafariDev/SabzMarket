using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SabzMarket.Application.Common;
using SabzMarket.Domain.Enums;
using System.Threading.Tasks;

namespace SabzMarket.API.ApiResultt
{
    public static class ApiMapper
    {
        public static ActionResult OperationResultTOApiResult(this OperationResult operationResult)
        {
            switch (operationResult.OperationError)
            {
                case OperationError.None:
                    return new OkObjectResult(operationResult.Message);
                    break;

                case OperationError.Success:
                    return new OkResult();
                    break;

                case OperationError.ServerError:
                    return new ObjectResult(operationResult.Message);
                    break;

                case OperationError.NotFound:
                    return new NotFoundObjectResult(operationResult.Message);
                    break;

                case OperationError.Validation:
                    return new BadRequestObjectResult(operationResult.Message);
                    break;

                case OperationError.Conflict:
                    return new ConflictObjectResult(operationResult.Message);
                    break;

                case OperationError.Forbidden:
                    return new ForbidResult();
                    break;

                case OperationError.Unauthorized:
                    return new UnauthorizedResult();
                    break;

                default:
                    return new ObjectResult(operationResult.Message);
            }
        }

        public static ActionResult OperationResultTOApiResult<T>(this OperationResult<T> operationResult)
        {
            switch (operationResult.OperationError)
            {
                case OperationError.Success:
                    return new OkObjectResult(operationResult.Data);
                    break;

                case OperationError.ServerError:
                    return new ObjectResult(operationResult.Message);
                    break;

                case OperationError.NotFound:
                    return new NotFoundObjectResult(operationResult.Message);
                    break;

                case OperationError.Validation:
                    return new BadRequestObjectResult(operationResult.Message);
                    break;

                case OperationError.Conflict:
                    return new ConflictObjectResult(operationResult.Message);
                    break;

                case OperationError.Forbidden:
                    return new ForbidResult();
                    break;

                case OperationError.Unauthorized:
                    return new UnauthorizedResult();
                    break;

                default:
                    return new ObjectResult(operationResult.Message);
            }
        }

        public static ApiResultStatusCode OperationResultTOApiResult(this OperationError operationError)
        {
            switch (operationError)
            {
                case OperationError.Success:
                    return ApiResultStatusCode.Success;

                case OperationError.ServerError:
                    return ApiResultStatusCode.ServerError;

                case OperationError.NotFound:
                    return ApiResultStatusCode.NotFound;

                case OperationError.Validation:
                    return ApiResultStatusCode.BadRequest;

                case OperationError.Conflict:
                    return ApiResultStatusCode.Conflict;

                case OperationError.Forbidden:
                    return ApiResultStatusCode.Forbidden;

                case OperationError.Unauthorized:
                    return ApiResultStatusCode.UnAuthorized;

                default:
                    return ApiResultStatusCode.ServerError;
            }
        }
    }
}
