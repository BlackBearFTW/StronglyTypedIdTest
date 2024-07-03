/*using IncrementedIdentifierTest.Common.ValueObjects;
using IncrementedIdentifierTest.Infrastructure.Persistence.ValueGenerators;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncrementedIdentifierTest.Infrastructure.Persistence.Extensions;

public static class EntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<TEntity> HasAutoIncrementingPrimaryKey<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        Func<TEntity, Identifier> idSelector) where TEntity : class
    {
        // Configure the property to use the custom value generator
        builder.Property(typeof(Identifier), "Id")
            .HasValueGenerator(() => new IdentifierValueGenerator<TEntity>(idSelector));

        return builder;
    }
}*/