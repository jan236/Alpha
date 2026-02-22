using Alpha.Samples;
using Xunit;

namespace Alpha.EntityFrameworkCore.Domains;

[Collection(AlphaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AlphaEntityFrameworkCoreTestModule>
{

}
