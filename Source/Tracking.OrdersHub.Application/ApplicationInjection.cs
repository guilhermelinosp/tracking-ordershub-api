using Microsoft.Extensions.DependencyInjection;
using Tracking.OrdersHub.Application.Services;
using Tracking.OrdersHub.Infrastructure;

namespace Tracking.OrdersHub.Application
{
    public static class ApplicationInjection
    {
        public static void AddApplicationInjection(this IServiceCollection services)
        {
            services
                .AddScopeds()
                .AddInfrastructureInjection();
        }

        private static IServiceCollection AddScopeds(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderUpdateService, ShippingOrderUpdateServiceImp>();

            return services;
        }
    }
}