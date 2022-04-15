using Cedid.AkilliLojistik.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik.ServiceAccessories
{
    public interface IServiceAccessoryAppService : ICrudAppService<
            ServiceAccessoryDto,
            Guid,
            GetServiceFilterListDto,
            CreateUpdateServiceAccessoryDto>
    {
    }
}
