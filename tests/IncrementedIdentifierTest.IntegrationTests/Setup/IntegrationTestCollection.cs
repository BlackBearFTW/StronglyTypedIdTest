
using IncrementedIdentifierTest.IntegrationTests.Setup;

namespace IncrementedIdentifierTest.IntegrationTesting.Setup;

[CollectionDefinition(nameof(IntegrationTestCollection), DisableParallelization = true)]
public class IntegrationTestCollection : ICollectionFixture<WebAppFactory>
{
}
