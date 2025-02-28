﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.Create;

[ApiController, Route("/api/todos")]
public class CreateEndpoint(Create.Handler handler) : ControllerBase
{
    [HttpPost]
    public async Task<Create.Response> HandleAsync(
        [FromBody] Create.Command request,
        CancellationToken cancellationToken = new()
    ) => await handler.HandleAsync(request, cancellationToken);
}