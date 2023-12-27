using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using Tracking.OrdersHub.Domain.Repositories;
using Tracking.OrdersHub.Infrastructure.Messaging;
using Tracking.OrdersHub.Infrastructure.Persistence;
using Tracking.OrdersHub.Infrastructure.Persistence.Repositories;

namespace Tracking.OrdersHub.Infrastructure
{
    public static class InfrastructureInjection
    {
        public static void AddInfrastructureInjection(this IServiceCollection services)
        {
            services
                .AddMongo()
                .AddRepositories()
                .AddMessageBus();
        }

        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration!.GetSection("MongoDb").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                sp.GetService<IConfiguration>();
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options!.ConnectionString);
                
                client.GetDatabase(options.Database);

                return client;
            });

            services.AddTransient(sp =>
            {
                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient!.GetDatabase(options!.Database);

                return db;
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderUpdateRepository, ShippingOrderUpdateRepositoryImp>();

            return services;
        }

        private static void AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBusService, RabbitMqService>();
        }
    }
}