using Microsoft.Extensions.DependencyInjection;
using TrackingOrders.Application.Services;

namespace TrackingOrders.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderUpdateService, ShippingOrderUpdateServiceImp>();

            return services;
        }
    }
}