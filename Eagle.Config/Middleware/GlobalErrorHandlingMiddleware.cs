using Eagle.Config.Models;
using Eagle.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace Eagle.Config.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                string message = string.Empty;
                int statusCode = 400;
                do
                {
                    if (ex is ApiException)
                    {
                        message = ex.Message;
                        statusCode = ((ApiException)ex).StatusCode;
                        break;
                    }
                    else
                    {
                        message = "Something went wrong.";
                        statusCode = 500;
                    }
                    ex = ex.InnerException;
                } while (ex != null);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                context.Response.WriteAsync(JsonConvert.SerializeObject(new { Message = message, StatusCode = statusCode }));
            }
        }
    }
}
