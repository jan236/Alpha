using Volo.Abp.Modularity;

namespace Alpha;

public abstract class AlphaApplicationTestBase<TStartupModule> : AlphaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
