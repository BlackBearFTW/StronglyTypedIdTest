using System.ComponentModel.DataAnnotations.Schema;
using IncrementedIdentifierTest.Common.ValueObjects;

namespace IncrementedIdentifierTest.Features.Todos.Domain;

public class Todo
{
    public Identifier Id { get; set; }
    public string Title { get; set; }
}