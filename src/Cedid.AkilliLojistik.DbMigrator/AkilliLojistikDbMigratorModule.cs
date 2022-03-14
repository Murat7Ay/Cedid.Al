using Cedid.AkilliLojistik.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Cedid.AkilliLojistik.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AkilliLojistikEntityFrameworkCoreModule),
    typeof(AkilliLojistikApplicationContractsModule)
    )]
public class AkilliLojistikDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
