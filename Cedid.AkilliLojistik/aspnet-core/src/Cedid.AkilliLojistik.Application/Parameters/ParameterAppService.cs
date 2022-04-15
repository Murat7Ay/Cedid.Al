using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Cedid.AkilliLojistik.Permissions;

namespace Cedid.AkilliLojistik.Parameters
{
    public class ParameterAppService : CrudAppService<Parameter, ParameterDto, int, GetParameterFilterListDto,
                        CreateUpdateParameterDto, CreateUpdateParameterDto>, IParameterAppService
    {
        public ParameterAppService(IRepository<Parameter, int> repository) : base(repository)
        {
            GetPolicyName = AkilliLojistikPermissions.Parameters.Default;
            GetListPolicyName = AkilliLojistikPermissions.Parameters.Default;
            CreatePolicyName = AkilliLojistikPermissions.Parameters.Create;
            UpdatePolicyName = AkilliLojistikPermissions.Parameters.Edit;
            DeletePolicyName = AkilliLojistikPermissions.Parameters.Create;
        }

        public async override Task<PagedResultDto<ParameterDto>> GetListAsync(GetParameterFilterListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Parameter.Text);
            }
            var queryable = await Repository.GetQueryableAsync();
            queryable = queryable.WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    c => c.Code.Contains(input.Filter)
                )
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(queryable);
            var totalCount = input.Filter == null
                ? await Repository.CountAsync()
                : await Repository.CountAsync(c => c.Code.Contains(input.Filter));
            return new PagedResultDto<ParameterDto>(
               totalCount,
               ObjectMapper.Map<List<Parameter>, List<ParameterDto>>(queryResult)
           );
        }
        public async Task<List<ParameterDto>> GetParameterItemsByCode(string code)
        {
            List<Parameter> parameters = await Repository.GetListAsync(x => x.Code == code && x.IsActive);
            return ObjectMapper.Map<List<Parameter>, List<ParameterDto>>(parameters);
        }
    }
}
