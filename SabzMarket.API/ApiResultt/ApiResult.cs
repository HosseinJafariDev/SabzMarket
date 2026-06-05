using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SabzMarket.API.ApiResultt
{
    public class ApiResult
    {
        public bool IsSuccess { get; protected set; }
        public string? Message { get; protected set; }
        public ApiResultStatusCode OperationError { get; protected set; }
        public ApiResult(bool isSuccess, ApiResultStatusCode apiResultStatusCode, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            OperationError = apiResultStatusCode;
        }

        #region Implicit Operators
        public static implicit operator ApiResult(ActionResult result)
        {
            if (result is BadRequestObjectResult badRequest)
            {
                return new ApiResult(false, ApiResultStatusCode.BadRequest, badRequest.Value?.ToString());
            }
            else if (result is OkResult okResult)
            {
                return new ApiResult(true, ApiResultStatusCode.Success);
            }
            else if (result is OkObjectResult okObjectResult)
            {
                return new ApiResult(true, ApiResultStatusCode.Success, okObjectResult.Value?.ToString());
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                return new ApiResult(false, ApiResultStatusCode.NotFound, notFoundObjectResult.Value?.ToString());
            }
            else if (result is ObjectResult objectResult)
            {
                return new ApiResult(false, ApiResultStatusCode.ServerError, objectResult.Value?.ToString());
            }
            else if (result is ConflictObjectResult conflictObjectResult)
            {
                return new ApiResult(false, ApiResultStatusCode.Conflict, conflictObjectResult.Value?.ToString());
            }
            else if (result is ForbidResult forbidResult)
            {
                return new ApiResult(false, ApiResultStatusCode.Forbidden);
            }
            else if (result is UnauthorizedResult unauthorizedResult)
            {
                return new ApiResult(false, ApiResultStatusCode.UnAuthorized);
            }
            return result;
        }

        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Success);
        }

        public static implicit operator ApiResult(OkObjectResult result)
        {
            return new ApiResult(true, ApiResultStatusCode.Success, result.Value?.ToString());
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.BadRequest, result.Value?.ToString());
        }

        public static implicit operator ApiResult(NotFoundObjectResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.NotFound, result.Value?.ToString());
        }

        public static implicit operator ApiResult(ObjectResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.ServerError, result.Value?.ToString());
        }

        public static implicit operator ApiResult(ConflictObjectResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.Conflict, result.Value?.ToString());
        }

        public static implicit operator ApiResult(ForbidResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.Forbidden);
        }

        public static implicit operator ApiResult(UnauthorizedResult result)
        {
            return new ApiResult(false, ApiResultStatusCode.UnAuthorized);
        }
        #endregion
    }

    public class ApiResult<T> : ApiResult
    {
        public T? Data { get; set; }
        public ApiResult(bool isSuccess, ApiResultStatusCode apiResultStatusCode, T data, string? message = null)
            : base(isSuccess, apiResultStatusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators
        public static implicit operator ApiResult<T>(ActionResult result)
        {
            if (result is OkObjectResult okObjectResult)
            {
                return new ApiResult<T>(true, ApiResultStatusCode.Success, (T)okObjectResult.Value!);
            }
            else if (result is BadRequestObjectResult badRequestObjectResult)
            {
                return new ApiResult<T>(false, ApiResultStatusCode.BadRequest, default, badRequestObjectResult.Value!.ToString());
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                return new ApiResult<T>(false, ApiResultStatusCode.NotFound, default, notFoundObjectResult.Value?.ToString());
            }
            else if (result is ObjectResult objectResult)
            {
                return new ApiResult<T>(false, ApiResultStatusCode.ServerError, default, objectResult.Value?.ToString());
            }
            else if (result is ConflictObjectResult conflictObjectResult)
            {
                return new ApiResult<T>(false, ApiResultStatusCode.Conflict, default, conflictObjectResult.Value?.ToString());
            }
            else if (result is ForbidResult forbidResult)
            {
                return new ApiResult<T>(false, ApiResultStatusCode.Forbidden, default);
            }
            else if (result is UnauthorizedResult unauthorizedResult)
            {
                return new ApiResult<T>(false, ApiResultStatusCode.UnAuthorized, default);
            }
            return result;
        }

        public static implicit operator ApiResult<T>(T data)
        {
            return new ApiResult<T>(true, ApiResultStatusCode.Success, data);
        }

        public static implicit operator ApiResult<T>(OkObjectResult result)
        {
            return new ApiResult<T>(true, ApiResultStatusCode.Success, (T)result.Value!);
        }

        public static implicit operator ApiResult<T>(BadRequestObjectResult result)
        {
            return new ApiResult<T>(false, ApiResultStatusCode.BadRequest, default, result.Value!.ToString());
        }

        public static implicit operator ApiResult<T>(NotFoundObjectResult result)
        {
            return new ApiResult<T>(false, ApiResultStatusCode.NotFound, default, result.Value?.ToString());
        }

        public static implicit operator ApiResult<T>(ObjectResult result)
        {
            return new ApiResult<T>(false, ApiResultStatusCode.ServerError, default, result.Value?.ToString());
        }

        public static implicit operator ApiResult<T>(ConflictObjectResult result)
        {
            return new ApiResult<T>(false, ApiResultStatusCode.Conflict, default, result.Value?.ToString());
        }

        public static implicit operator ApiResult<T>(ForbidResult result)
        {
            return new ApiResult<T>(false, ApiResultStatusCode.Forbidden, default);
        }

        public static implicit operator ApiResult<T>(UnauthorizedResult result)
        {
            return new ApiResult<T>(false, ApiResultStatusCode.UnAuthorized, default);
        }
        #endregion
    }
}

