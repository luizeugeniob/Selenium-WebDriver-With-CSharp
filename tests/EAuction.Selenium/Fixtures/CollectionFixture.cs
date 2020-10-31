using Xunit;

namespace EAuction.Selenium.Fixtures
{

    [CollectionDefinition(Constants.CollectionDefinitionName)]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}
