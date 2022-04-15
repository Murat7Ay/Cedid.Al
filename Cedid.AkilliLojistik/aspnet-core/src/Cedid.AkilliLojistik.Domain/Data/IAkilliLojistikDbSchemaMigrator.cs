using System.Threading.Tasks;

namespace Cedid.AkilliLojistik.Data;

public interface IAkilliLojistikDbSchemaMigrator
{
    Task MigrateAsync();
}
