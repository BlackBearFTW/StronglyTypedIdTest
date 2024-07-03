using FluentValidation;

namespace IncrementedIdentifierTest.Features.Todos.Endpoints.Create;

public class CreateValidator : AbstractValidator<Create.Command>
{
    public CreateValidator()
    {
    }       
}
