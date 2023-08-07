using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using TrackingOrders.Core.Repositories;
using TrackingOrders.Infrastructure.Messaging;
using TrackingOrders.Infrastructure.Persistence;
using TrackingOrders.Infrastructure.Persistence.Repositories;

namespace TrackingOrders.Infrastructure
{
    public static class InfrastructureModule
    {
        [Obsolete]
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddMongo()
                .AddRepositories()
                .AddMessageBus();

            return services;
        }

        [Obsolete]
        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration.GetSection("MongoDb").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options.ConnectionString);
                var db = client.GetDatabase(options.Database);

                return client;
            });

            services.AddTransient(sp =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.Database);

                return db;
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IShippingOrderUpdateRepository, ShippingOrderUpdateRepositoryImp>();

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBusService, RabbitMqService>();

            return services;
        }
    }
}