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

namespace Cedid.AkilliLojistik.ServiceMaterials
{
    public class ServiceMaterialAppService : CrudAppService<ServiceMaterial, ServiceMaterialDto, Guid, GetServiceFilterListDto,
                        CreateUpdateServiceMaterialDto, CreateUpdateServiceMaterialDto>, IServiceMaterialAppService
    {
        public ServiceMaterialAppService(IRepository<ServiceMaterial, Guid> repository) : base(repository)
        {
        }

        public async override Task<PagedResultDto<ServiceMaterialDto>> GetListAsync(GetServiceFilterListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(ServiceMaterial.CreationTime);
            }
            else
            {
                input.Sorting = NormalizeSorting(input.Sorting);
            }

            var queryable = await Repository.GetQueryableAsync();
            queryable = queryable.Where(x => x.ServiceId == input.ServiceId && x.Type == input.ServiceMaterialType)
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
            return new PagedResultDto<ServiceMaterialDto>(
               totalCount,
               ObjectMapper.Map<List<ServiceMaterial>, List<ServiceMaterialDto>>(queryResult)
           );
        }

        private string NormalizeSorting(string sortParam)
        {
            if (sortParam.Contains("Text"))
            {
                sortParam = sortParam.Replace("Text","Id");
            }
            return sortParam;
        }
    }
}
