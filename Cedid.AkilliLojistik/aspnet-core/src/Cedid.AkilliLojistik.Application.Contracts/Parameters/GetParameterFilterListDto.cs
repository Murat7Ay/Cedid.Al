using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.Parameters
{
    public class GetParameterFilterListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
