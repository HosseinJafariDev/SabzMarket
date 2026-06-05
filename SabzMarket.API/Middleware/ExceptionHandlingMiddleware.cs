using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.UseCases.Erorr;
using SabzMarket.Domain.Enums;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IAddLogErrorUseCase addLogErrorUseCase)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "Application exception occurred");

                await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {

                var errorDTO = new ErrorLogDTO()
                {
                    CreatedAt = DateTime.Now,
                    Message = ex.Message,
                    //Layer = ex.Layer,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                };

                var result = await addLogErrorUseCase.ExecuteAsync(errorDTO);
                //_logger.LogError(ex, "Unhandled exception occurred");

                await HandleExceptionAsync(context, OperationError.ServerError, result.Message!);
            }

            static async Task HandleExceptionAsync(HttpContext context, OperationError operationError, string message)
            {
                context.Response.ContentType = "application/json";
                //context.Response.StatusCode = statusCode;
                var statusCode = operationError.OperationResultTOApiResult();
                var result = new ApiResult(false, statusCode, message);

                var json = JsonConvert.SerializeObject(result);
                await context.Response.WriteAsync(json);
            }
        }
    }
}



