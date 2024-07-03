using IncrementedIdentifierTest.Common.Dto;
using IncrementedIdentifierTest.Common.Extensions;
using IncrementedIdentifierTest.Common.Interfaces;
using IncrementedIdentifierTest.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using IncrementedIdentifierTest.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.GetAllWithPagination;

[Handler]
public static partial class GetAllWithPagination
{
    public record Query(int PageSize = 100, int PageIndex = 1);

    public record Response(Identifier Id, int RawId, string Title);

    private static async ValueTask<PaginationResult<Response>> HandleAsync(
        Query request,
        ApplicationDbContext dbContext,
        CancellationToken token)
    {
        var todos = await dbContext.Todos
            .Paginate(request.PageIndex, request.PageSize)
            .Select(x => new Response(x.Id, x.Id.Value, x.Title))
            .ToListAsync(token);

        return new PaginationResult<Response>
        {
            Data = todos,
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            TotalRecords = await dbContext.Todos.CountAsync(token)
        };

        
    }
}