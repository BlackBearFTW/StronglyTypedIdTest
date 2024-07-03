using IncrementedIdentifierTest.Common.Interfaces;
using IncrementedIdentifierTest.Infrastructure.Exceptions.Handlers;
using IncrementedIdentifierTest.Infrastructure.Persistence;
using FluentValidation;

namespace IncrementedIdentifierTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHandlers();
        services.AddBehaviors();

        services.AddExceptionHandler<ApplicationExceptionHandler>();
        services.AddExceptionHandler<FluentValidationExceptionHandler>();
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
           var connectionString = configuration.GetConnectionString("DbConnection");
           options.UseNpgsql(connectionString);
        });

        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
       
        return services;
    }
}