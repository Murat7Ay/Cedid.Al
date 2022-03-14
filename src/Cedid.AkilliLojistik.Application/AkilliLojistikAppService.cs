using System;
using System.Collections.Generic;
using System.Text;
using Cedid.AkilliLojistik.Localization;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik;

/* Inherit your application services from this class.
 */
public abstract class AkilliLojistikAppService : ApplicationService
{
    protected AkilliLojistikAppService()
    {
        LocalizationResource = typeof(AkilliLojistikResource);
    }
}
