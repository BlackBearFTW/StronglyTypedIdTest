using IncrementedIdentifierTest.Common.ValueObjects;
using IncrementedIdentifierTest.Features.Todos.Domain;
using IncrementedIdentifierTest.Infrastructure.Persistence.ValueGenerators;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncrementedIdentifierTest.Infrastructure.Persistence.EntityConfiguration;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValue(Identifier.From(1)).ValueGeneratedOnAdd();
    }
}