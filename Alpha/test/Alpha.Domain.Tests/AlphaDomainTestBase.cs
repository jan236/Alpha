using Volo.Abp.Modularity;

namespace Alpha;

/* Inherit from this class for your domain layer tests. */
public abstract class AlphaDomainTestBase<TStartupModule> : AlphaTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
