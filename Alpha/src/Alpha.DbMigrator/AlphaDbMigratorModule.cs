using Alpha.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Alpha.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AlphaEntityFrameworkCoreModule),
    typeof(AlphaApplicationContractsModule)
)]
public class AlphaDbMigratorModule : AbpModule
{
}
