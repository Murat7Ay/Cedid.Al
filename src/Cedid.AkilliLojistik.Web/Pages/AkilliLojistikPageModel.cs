using Cedid.AkilliLojistik.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Cedid.AkilliLojistik.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class AkilliLojistikPageModel : AbpPageModel
{
    protected AkilliLojistikPageModel()
    {
        LocalizationResourceType = typeof(AkilliLojistikResource);
    }
}
