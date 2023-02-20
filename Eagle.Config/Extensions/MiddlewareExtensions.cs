using Eagle.Config.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Eagle.Config.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void AddErrorMiddleware(this IApplicationBuilder services)
        {
            services.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }

        public static void AddAuthMiddleware(this IApplicationBuilder services)
        {
            services.UseMiddleware<AuthMiddleware>();
        }
    }
}
