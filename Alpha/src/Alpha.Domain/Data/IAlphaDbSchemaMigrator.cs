using System.Threading.Tasks;

namespace Alpha.Data;

public interface IAlphaDbSchemaMigrator
{
    Task MigrateAsync();
}
