using Cedid.AkilliLojistik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories;

namespace Cedid.AkilliLojistik.ServiceOperations
{
    public class ServiceOperationAppService : CrudAppService<ServiceOperation, ServiceOperationDto, Guid, GetServiceFilterListDto,
                        CreateUpdateServiceOperationDto, CreateUpdateServiceOperationDto>, IServiceOperationAppService
    {
        public ServiceOperationAppService(IRepository<ServiceOperation, Guid> repository) : base(repository)
        {
        }

        public async override Task<PagedResultDto<ServiceOperationDto>> GetListAsync(GetServiceFilterListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(ServiceOperation.CreationTime);
            }
            var queryable = await Repository.GetQueryableAsync();
            queryable = queryable.Where(x => x.ServiceId == input.ServiceId)
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    c => c.Description.Contains(input.Filter)
                )
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(queryable);
            var totalCount = input.Filter == null
                ? await Repository.CountAsync()
                : await Repository.CountAsync(c => c.Description.Contains(input.Filter));
            return new PagedResultDto<ServiceOperationDto>(
               totalCount,
               ObjectMapper.Map<List<ServiceOperation>, List<ServiceOperationDto>>(queryResult)
           );
        }
    }
}
