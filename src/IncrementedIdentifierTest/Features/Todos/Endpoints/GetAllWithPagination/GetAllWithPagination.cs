using IncrementedIdentifierTest.Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.GetAllWithPagination;

[ApiController, Route("/api/todos")]
public class GetAllWithPaginationEndpoint(GetAllWithPagination.Handler handler) : ControllerBase
{
    [HttpGet]
    public async Task<PaginationResult<GetAllWithPagination.Response>> HandleAsync(
        [FromQuery] GetAllWithPagination.Query request,
        CancellationToken cancellationToken = new()
    ) => await handler.HandleAsync(request, cancellationToken);
}