using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Cedid.AkilliLojistik.Web;

[Dependency(ReplaceServices = true)]
public class AkilliLojistikBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AkilliLojistik";
}
