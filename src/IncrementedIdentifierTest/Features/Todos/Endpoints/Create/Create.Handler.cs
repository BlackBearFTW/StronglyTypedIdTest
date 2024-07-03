using IncrementedIdentifierTest.Common.ValueObjects;
using IncrementedIdentifierTest.Features.Todos.Domain;
using IncrementedIdentifierTest.Infrastructure.Persistence;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.Create;

[Handler]
public static partial class Create
{
    public record Command(string Title);

    public record Response(Identifier Id, string Title);
    
    private static async ValueTask<Response> HandleAsync(
        Command request,
        ApplicationDbContext dbContext,
        CancellationToken token)
    {

        var todo = new Todo
        {
            Title = request.Title
        };
        
        await dbContext.Todos.AddAsync(todo, token);
        await dbContext.SaveChangesAsync(token);
        
        return new Response(todo.Id, todo.Title);
    }
}

