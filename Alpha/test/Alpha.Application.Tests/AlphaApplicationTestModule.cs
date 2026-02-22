using Volo.Abp.Modularity;

namespace Alpha;

[DependsOn(
    typeof(AlphaApplicationModule),
    typeof(AlphaDomainTestModule)
)]
public class AlphaApplicationTestModule : AbpModule
{

}
