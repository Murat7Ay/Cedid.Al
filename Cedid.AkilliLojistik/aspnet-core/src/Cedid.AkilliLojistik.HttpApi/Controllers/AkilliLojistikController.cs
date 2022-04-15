using Cedid.AkilliLojistik.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Cedid.AkilliLojistik.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AkilliLojistikController : AbpControllerBase
{
    protected AkilliLojistikController()
    {
        LocalizationResource = typeof(AkilliLojistikResource);
    }
}
