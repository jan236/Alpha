using Alpha.Books;
using Xunit;

namespace Alpha.EntityFrameworkCore.Applications.Books;

[Collection(AlphaTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<AlphaEntityFrameworkCoreTestModule>
{

}