using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SabzMarket.API.ApiResultt;
using SabzMarket.Application.Common;
using SabzMarket.Application.Exceptions;
using SabzMarket.Application.Interfaces.Repository;
using SabzMarket.Application.Interfaces.Services;
using SabzMarket.Application.UseCases.Erorr;
using SabzMarket.Domain.Entities.Log;
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

        public async Task InvokeAsync(HttpContext context, IAddLogErrorUseCase addLogErrorUseCase,
            IFileLogService fileLogService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = GetStatusCode(ex);
                var exceptionLog =
                    ExceptionLog.CreateByException(ex, statusCode, context.Request.Path, context.Request.Method);
                try
                {
                    await addLogErrorUseCase.ExecuteAsync(exceptionLog);
                }
                catch (Exception e)
                {
                    var createdAt = await fileLogService.SaveFailedLogAsync(exceptionLog);
                    _logger.LogError(e,
                        "Failed to persist exception log to MongoDB for {ExceptionType} CreatedAt:{createdAt}",
                        ex.GetType().Name, createdAt);
                }


                await HandleExceptionAsync(context, statusCode, ResolveDetail(ex, statusCode));
            }
        }

        private static string ResolveDetail(Exception exception, int statusCode) =>
            statusCode == StatusCodes.Status500InternalServerError
                ? "خطای غیر منتظره ای رخ داد."
                : exception.Message;

        public async Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            var result = new ApiResult(false, statusCode, message);

            var json = JsonConvert.SerializeObject(result);
            await context.Response.WriteAsync(json);
        }

        private int GetStatusCode(Exception exception)
        {
            switch (exception)
            {
                case DomainException:
                    return StatusCodes.Status500InternalServerError;
                case BadRequestException:
                    return StatusCodes.Status400BadRequest;
                case ConflictException:
                    return StatusCodes.Status409Conflict;
                case NotFoundException:
                    return StatusCodes.Status404NotFound;
            }

            return StatusCodes.Status500InternalServerError;
        }
    }
}