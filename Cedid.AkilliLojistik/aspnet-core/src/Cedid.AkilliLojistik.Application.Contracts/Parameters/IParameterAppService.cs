using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik.Parameters
{
    public interface IParameterAppService : ICrudAppService< 
            ParameterDto, 
            int,
            GetParameterFilterListDto, 
            CreateUpdateParameterDto> 
    {
        Task<List<ParameterDto>> GetParameterItemsByCode(string code);
    }
}
