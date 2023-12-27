using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Tracking.OrdersHub.Domain.Repositories;
using Tracking.OrdersHub.Infrastructure.Messaging;
using Tracking.OrdersHub.Infrastructure.Persistence;
using Tracking.OrdersHub.Infrastructure.Persistence.Repositories;
using Tracking.OrdersHub.Infrastructure.Services;

namespace Tracking.OrdersHub.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static void AddInfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMongo(configuration)
                .AddRepositories()
                .AddMessageBus();
        }

        private static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(sp =>
            {
                var client = new MongoClient(configuration["MongoDb_ConnectionString"]);
                client.GetDatabase(configuration["MongoDb_Database"]);
                return client;
            });

            services.AddTransient(sp =>
            {
                var mongoClient = sp.GetService<IMongoClient>();
                var db = mongoClient!.GetDatabase(configuration["MongoDb_Database"]);
                return db;
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShippingRepository, ShippingRepository>();

            return services;
        }

        private static void AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMqService, RabbitMqService>();
        }
    }
}