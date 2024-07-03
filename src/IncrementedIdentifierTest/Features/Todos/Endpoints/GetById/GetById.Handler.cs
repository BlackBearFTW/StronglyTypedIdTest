using IncrementedIdentifierTest.Features.Todos.Domain;
using IncrementedIdentifierTest.Infrastructure.Exceptions;
using IncrementedIdentifierTest.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using IncrementedIdentifierTest.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.GetById;

[Handler]
public static partial class GetById
{
    public record Query(Guid Id);
    public record Response(Identifier Id, string Title);

    private static async ValueTask<Response> HandleAsync(
        Query request,
        ApplicationDbContext dbContext,
        CancellationToken token)
    {
        Todo? todo = await dbContext.Todos.FindAsync(request.Id, token);
        if (todo is null) throw Error.NotFound<Todo>();

        return new Response(todo.Id, todo.Title);
    }
}

