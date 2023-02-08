using Alura.Challenge.Core.Interfaces;
using Alura.Challenge.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Alura.Challenge.Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyMappings(this ModelBuilder builder)
        {

            builder.ApplyConfiguration(new VideoMap());
            builder.ApplyConfiguration(new CategoriaMap());

            return builder;
        }

        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(IBaseEntity.Id):
                            property.IsKey();
                            break;
                        default:
                            break;
                    }
                }
            }

            return builder;
        }

    }
}