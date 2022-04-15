using Cedid.AkilliLojistik.Lookups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik.Services
{
    public interface IServiceAppService : ICrudAppService<
            ServiceDto,
            Guid,
            GetServiceFilterListDto,
            CreateUpdateServiceDto>
    {
        public Task<List<UserLookup>> GetUserLookups();
    }
}
