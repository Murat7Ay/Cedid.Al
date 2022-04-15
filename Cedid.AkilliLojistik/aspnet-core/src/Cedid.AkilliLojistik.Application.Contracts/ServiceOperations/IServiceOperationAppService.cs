using Cedid.AkilliLojistik.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Cedid.AkilliLojistik.ServiceOperations
{

    public interface IServiceOperationAppService : ICrudAppService<
            ServiceOperationDto,
            Guid,
            GetServiceFilterListDto,
            CreateUpdateServiceOperationDto>
    {
    }
}
