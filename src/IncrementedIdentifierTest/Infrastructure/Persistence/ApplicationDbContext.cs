using IncrementedIdentifierTest.Common.ValueObjects;
using IncrementedIdentifierTest.Features.Todos.Domain;
using Microsoft.EntityFrameworkCore;

namespace IncrementedIdentifierTest.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Todo> Todos => Set<Todo>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Identifier>()
            .HaveConversion<Identifier.EfCoreValueConverter>();
    }
}