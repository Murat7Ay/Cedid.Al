using Volo.Abp.Modularity;

namespace Cedid.AkilliLojistik;

[DependsOn(
    typeof(AkilliLojistikApplicationModule),
    typeof(AkilliLojistikDomainTestModule)
    )]
public class AkilliLojistikApplicationTestModule : AbpModule
{

}
