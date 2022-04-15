using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cedid.AkilliLojistik.Data;
using Volo.Abp.DependencyInjection;

namespace Cedid.AkilliLojistik.EntityFrameworkCore;

public class EntityFrameworkCoreAkilliLojistikDbSchemaMigrator
    : IAkilliLojistikDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAkilliLojistikDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AkilliLojistikDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AkilliLojistikDbContext>()
            .Database
            .MigrateAsync();
    }
}
