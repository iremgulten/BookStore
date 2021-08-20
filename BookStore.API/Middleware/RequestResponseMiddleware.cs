using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Middleware
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate next;

        public ILogger<RequestResponseMiddleware> logger;

        public RequestResponseMiddleware(RequestDelegate Next, ILogger<RequestResponseMiddleware> Logger)
        {
            next = Next;
            logger = Logger;
        }
        public async Task Invoke(HttpContext httpContext)
        {

            await RequestLogging(httpContext);

            var originalBody = httpContext.Response.Body;
            using var newBody = new MemoryStream();
            httpContext.Response.Body = newBody;

            await next.Invoke(httpContext);

            newBody.Seek(0, SeekOrigin.Begin);
            var bodyText = await new StreamReader(httpContext.Response.Body,Encoding.UTF8).ReadToEndAsync();//TODO
            logger.LogError($"Response: {bodyText}");
            newBody.Seek(0, SeekOrigin.Begin);
            await newBody.CopyToAsync(originalBody);

        }

        private async Task RequestLogging(HttpContext httpContext)
        {
            var requestBody = "";
            var request = httpContext.Request;
            httpContext.Request.EnableBuffering();

            using (StreamReader stream = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
            {
                requestBody = await stream.ReadToEndAsync();
                request.Body.Position = 0;
            }
            logger.LogError($"Request: {requestBody}");
        }
        
        
    }
}
