using Eagle.Logic.Services;
using Eagle.Logic.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Eagle.Config.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddEagleLogicService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
