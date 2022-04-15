using Cedid.AkilliLojistik.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik.ServiceMaterials
{
    public interface IServiceMaterialAppService: ICrudAppService<
            ServiceMaterialDto,
            Guid,
            GetServiceFilterListDto,
            CreateUpdateServiceMaterialDto>
    {
    }
}
