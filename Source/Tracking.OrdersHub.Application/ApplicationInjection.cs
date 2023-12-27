using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracking.OrdersHub.Application.Services;
using Tracking.OrdersHub.Infrastructure;

namespace Tracking.OrdersHub.Application
{
    public static class ApplicationInjection
    {
        public static void AddApplicationInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScopeds()
                .AddInfrastructureInjection(configuration);
        }

        private static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            services.AddScoped<ITrakingOrderService, TrakingOrderService>();

            return services;
        }
    }
}