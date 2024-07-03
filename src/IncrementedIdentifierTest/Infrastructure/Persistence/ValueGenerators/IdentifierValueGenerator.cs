using IncrementedIdentifierTest.Common.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace IncrementedIdentifierTest.Infrastructure.Persistence.ValueGenerators;

internal class IdentifierValueGenerator<TEntity> : ValueGenerator<Identifier> where TEntity : class
{
    private readonly Func<TEntity, Identifier> _idSelector;

    public IdentifierValueGenerator(Func<TEntity, Identifier> idSelector)
    {
        _idSelector = idSelector;
    }

    public override Identifier Next(EntityEntry entry)
    {
        var entities = ((DbContext)entry.Context).Set<TEntity>();

        var next = Math.Max(
            maxFrom(entities.Local),
            maxFrom(entities)) + 1;

        return Identifier.From(next);

        int maxFrom(IEnumerable<TEntity> es)
        {
            return es.Any() ? es.Max(e => _idSelector(e).Value) : 0;
        }
    }

    public override bool GeneratesTemporaryValues => false;
}