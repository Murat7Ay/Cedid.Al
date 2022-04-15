using Cedid.AkilliLojistik.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Cedid.AkilliLojistik;

[DependsOn(
    typeof(AkilliLojistikEntityFrameworkCoreTestModule)
    )]
public class AkilliLojistikDomainTestModule : AbpModule
{

}
