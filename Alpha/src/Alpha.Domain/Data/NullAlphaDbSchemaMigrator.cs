using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Alpha.Data;

/* This is used if database provider does't define
 * IAlphaDbSchemaMigrator implementation.
 */
public class NullAlphaDbSchemaMigrator : IAlphaDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
