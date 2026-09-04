using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SabzMarket.API.ApiResultt
{
    public class ApiResult
    {
        public bool IsSuccess { get; protected set; }
        public string? Message { get; protected set; }
        public int Status { get; protected set; }


        public ApiResult(bool isSuccess, int status, string? message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Status = status;
        }

        #region Implicit Operators

        public static implicit operator ApiResult(ActionResult result)
        {
            if (result is BadRequestObjectResult badRequest)
            {
                return new ApiResult(false, StatusCodes.Status400BadRequest, badRequest.Value?.ToString());
            }
            else if (result is OkResult okResult)
            {
                return new ApiResult(true, StatusCodes.Status204NoContent);
            }
            else if (result is OkObjectResult okObjectResult)
            {
                return new ApiResult(true, StatusCodes.Status200OK, okObjectResult.Value?.ToString());
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                return new ApiResult(false, StatusCodes.Status404NotFound, notFoundObjectResult.Value?.ToString());
            }
            else if (result is ObjectResult objectResult)
            {
                return new ApiResult(false, StatusCodes.Status500InternalServerError, objectResult.Value?.ToString());
            }
            else if (result is ConflictObjectResult conflictObjectResult)
            {
                return new ApiResult(false, StatusCodes.Status409Conflict, conflictObjectResult.Value?.ToString());
            }
            else if (result is ForbidResult forbidResult)
            {
                return new ApiResult(false, StatusCodes.Status403Forbidden);
            }
            else if (result is UnauthorizedResult unauthorizedResult)
            {
                return new ApiResult(false, StatusCodes.Status401Unauthorized);
            }

            return result;
        }

        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, StatusCodes.Status204NoContent);
        }

        public static implicit operator ApiResult(OkObjectResult result)
        {
            return new ApiResult(true, StatusCodes.Status200OK, result.Value?.ToString());
        }

        public static implicit operator ApiResult(BadRequestObjectResult result)
        {
            return new ApiResult(false, StatusCodes.Status400BadRequest, result.Value?.ToString());
        }

        public static implicit operator ApiResult(NotFoundObjectResult result)
        {
            return new ApiResult(false, StatusCodes.Status404NotFound, result.Value?.ToString());
        }

        public static implicit operator ApiResult(ObjectResult result)
        {
            return new ApiResult(false, StatusCodes.Status500InternalServerError, result.Value?.ToString());
        }

        public static implicit operator ApiResult(ConflictObjectResult result)
        {
            return new ApiResult(false, StatusCodes.Status409Conflict, result.Value?.ToString());
        }

        public static implicit operator ApiResult(ForbidResult result)
        {
            return new ApiResult(false, StatusCodes.Status403Forbidden);
        }

        public static implicit operator ApiResult(UnauthorizedResult result)
        {
            return new ApiResult(false, StatusCodes.Status401Unauthorized);
        }

        #endregion
    }

    public class ApiResult<T> : ApiResult
    {
        public T? Data { get; set; }

        public ApiResult(bool isSuccess, int statusCodes, T data, string? message = null)
            : base(isSuccess, statusCodes, message)
        {
            Data = data;
        }

        #region Implicit Operators

        public static implicit operator ApiResult<T>(ActionResult result)
        {
            if (result is OkObjectResult okObjectResult)
            {
                return new ApiResult<T>(true, StatusCodes.Status204NoContent, (T)okObjectResult.Value!);
            }
            else if (result is BadRequestObjectResult badRequestObjectResult)
            {
                return new ApiResult<T>(false, StatusCodes.Status400BadRequest, default,
                    badRequestObjectResult.Value!.ToString());
            }
            else if (result is NotFoundObjectResult notFoundObjectResult)
            {
                return new ApiResult<T>(false, StatusCodes.Status404NotFound, default,
                    notFoundObjectResult.Value?.ToString());
            }
            else if (result is ObjectResult objectResult)
            {
                return new ApiResult<T>(false, StatusCodes.Status500InternalServerError, default,
                    objectResult.Value?.ToString());
            }
            else if (result is ConflictObjectResult conflictObjectResult)
            {
                return new ApiResult<T>(false, StatusCodes.Status409Conflict, default,
                    conflictObjectResult.Value?.ToString());
            }
            else if (result is ForbidResult forbidResult)
            {
                return new ApiResult<T>(false, StatusCodes.Status403Forbidden, default);
            }
            else if (result is UnauthorizedResult unauthorizedResult)
            {
                return new ApiResult<T>(false, StatusCodes.Status401Unauthorized, default);
            }

            return result;
        }

        public static implicit operator ApiResult<T>(T data)
        {
            return new ApiResult<T>(true, StatusCodes.Status204NoContent, data);
        }

        public static implicit operator ApiResult<T>(OkObjectResult result)
        {
            return new ApiResult<T>(true, StatusCodes.Status200OK, (T)result.Value!);
        }

        public static implicit operator ApiResult<T>(BadRequestObjectResult result)
        {
            return new ApiResult<T>(false, StatusCodes.Status400BadRequest, default, result.Value!.ToString());
        }

        public static implicit operator ApiResult<T>(NotFoundObjectResult result)
        {
            return new ApiResult<T>(false, StatusCodes.Status404NotFound, default, result.Value?.ToString());
        }

        public static implicit operator ApiResult<T>(ObjectResult result)
        {
            return new ApiResult<T>(false, StatusCodes.Status500InternalServerError, default, result.Value?.ToString());
        }

        public static implicit operator ApiResult<T>(ConflictObjectResult result)
        {
            return new ApiResult<T>(false, StatusCodes.Status409Conflict, default, result.Value?.ToString());
        }

        public static implicit operator ApiResult<T>(ForbidResult result)
        {
            return new ApiResult<T>(false, StatusCodes.Status403Forbidden, default);
        }

        public static implicit operator ApiResult<T>(UnauthorizedResult result)
        {
            return new ApiResult<T>(false, StatusCodes.Status401Unauthorized, default);
        }

        #endregion
    }
}