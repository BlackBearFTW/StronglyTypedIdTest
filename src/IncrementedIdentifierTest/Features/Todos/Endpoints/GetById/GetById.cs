using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.GetById;

[ApiController, Route("/api/todos/{Id}")]
public class GetByIdEndpoint(GetById.Handler handler) : ControllerBase
{
    [HttpGet]
    public async Task<GetById.Response> HandleAsync(
        [FromRoute] GetById.Query request,
        CancellationToken cancellationToken = new()
    ) => await handler.HandleAsync(request, cancellationToken);
}