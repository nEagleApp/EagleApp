using Microsoft.AspNetCore.Http;

namespace Eagle.Config.Middleware
{
    public abstract class BaseMiddleware
    {
        protected readonly RequestDelegate _next;

        protected BaseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public abstract Task Invoke(HttpContext context);
    }
}
