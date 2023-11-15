using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using ProductService.DataAccess.DataConfig.Configuration;
using ProductService.Domain;

namespace ProductService.DataAccess.DataConfig
{
    public static class MongoConfigure
    {
        public static void Configure()
        {
            ProductConfig.Configure();

            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;
            //BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.CSharpLegacy));

            // Conventions
            var pack = new ConventionPack
                {
                    new IgnoreExtraElementsConvention(true),
                    new IgnoreIfDefaultConvention(true)
            };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
