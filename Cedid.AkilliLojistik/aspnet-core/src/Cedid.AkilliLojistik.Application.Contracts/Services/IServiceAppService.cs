using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik.Services
{
    public interface IServiceAppService : ICrudAppService<
            ServiceDto,
            Guid,
            GetServiceFilterListDto,
            CreateUpdateServiceDto>
    {
    }
}
