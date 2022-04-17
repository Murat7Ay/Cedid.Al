using Cedid.AkilliLojistik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;

namespace Cedid.AkilliLojistik.ServiceAccessories
{
    public class ServiceAccessoryAppService : CrudAppService<ServiceAccessory, ServiceAccessoryDto, Guid, GetServiceFilterListDto,
                        CreateUpdateServiceAccessoryDto, CreateUpdateServiceAccessoryDto>, IServiceAccessoryAppService
    {
        public ServiceAccessoryAppService(IRepository<ServiceAccessory, Guid> repository) : base(repository)
        {
        }

        public async override Task<PagedResultDto<ServiceAccessoryDto>> GetListAsync(GetServiceFilterListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(ServiceAccessory.CreationTime);
            }
            else
            {
                input.Sorting = NormalizeSorting(input.Sorting);
            }
            var queryable = await Repository.GetQueryableAsync();
            queryable = queryable.Where(x=>x.ServiceId == input.ServiceId)
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    c => c.SerialNumber.Contains(input.Filter)
                )
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(queryable);
            var totalCount = input.Filter == null
                ? await Repository.CountAsync()
                : await Repository.CountAsync(c => c.SerialNumber.Contains(input.Filter));
            return new PagedResultDto<ServiceAccessoryDto>(
               totalCount,
               ObjectMapper.Map<List<ServiceAccessory>, List<ServiceAccessoryDto>>(queryResult)
           );
        }

        private string NormalizeSorting(string sortParam)
        {
            if (sortParam.Contains("Text"))
            {
                sortParam = sortParam.Replace("Text", "Id");
            }
            return sortParam;
        }
    }
}
