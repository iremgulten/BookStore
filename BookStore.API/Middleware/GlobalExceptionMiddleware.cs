using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BookStore.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _request;
        private static readonly Serilog.ILogger _logger = Log.ForContext<GlobalExceptionMiddleware>();

        public GlobalExceptionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception ex)
            {
               _logger.Error($"{DateTime.Now.ToString("HH:mm:ss")} : {ex}");
                await Task.CompletedTask;
            }
        }
    }
}
