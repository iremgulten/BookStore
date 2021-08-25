using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookStore.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate Next, ILogger<ExceptionHandlerMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);

            }catch(Exception ex)
            {
                await ExceptionHandler(httpContext, ex);
            }
        }
        private  Task  ExceptionHandler(HttpContext httpContext,Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var exceptionType = ex.GetType();
            if (exceptionType == typeof(KeyNotFoundException))
            {
                logger.LogError($"Not Found Exception: {ex.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(BadHttpRequestException))
            {
                logger.LogError($"Bad Request Exception: {ex.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                logger.LogError($"Unauthorized Acces Exception: {ex.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
                logger.LogError($"Internal Server Error Exception: {ex.Message}");
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return httpContext.Response.WriteAsync(new ErrorResultModel()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }


    }
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }

}
