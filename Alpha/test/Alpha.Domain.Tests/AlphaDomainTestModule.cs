using Volo.Abp.Modularity;

namespace Alpha;

[DependsOn(
    typeof(AlphaDomainModule),
    typeof(AlphaTestBaseModule)
)]
public class AlphaDomainTestModule : AbpModule
{

}
