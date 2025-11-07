using FoodManager.CrossCutting.Models;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace FoodManager.CrossCutting.Extentions
{
    public static class MongoExtentions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, MongoSettings mongoSettings)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            var conventionPack = new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String)
            };

            ConventionRegistry.Register(
                "EnumStringConvention",
                conventionPack,
                t => true
            );

            var clientSettings = MongoClientSettings.FromConnectionString(mongoSettings.ConnectionString);

            var mongoClient = new MongoClient(clientSettings);

            services.AddSingleton<IMongoClient>(_ => mongoClient);

            services.AddSingleton(sp =>
            {
                var mongoClient = sp.GetService<IMongoClient>()!;
                var db = mongoClient.GetDatabase(mongoSettings.Database);
                return db;
            });

            return services;
        }
    }
}
