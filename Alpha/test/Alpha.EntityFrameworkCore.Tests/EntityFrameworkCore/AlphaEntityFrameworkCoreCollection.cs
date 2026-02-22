using Xunit;

namespace Alpha.EntityFrameworkCore;

[CollectionDefinition(AlphaTestConsts.CollectionDefinitionName)]
public class AlphaEntityFrameworkCoreCollection : ICollectionFixture<AlphaEntityFrameworkCoreFixture>
{

}
