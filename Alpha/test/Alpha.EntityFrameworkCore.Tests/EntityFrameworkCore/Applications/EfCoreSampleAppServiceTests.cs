using Alpha.Samples;
using Xunit;

namespace Alpha.EntityFrameworkCore.Applications;

[Collection(AlphaTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AlphaEntityFrameworkCoreTestModule>
{

}
