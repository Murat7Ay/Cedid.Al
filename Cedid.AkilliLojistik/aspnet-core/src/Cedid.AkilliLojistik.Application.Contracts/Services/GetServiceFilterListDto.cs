using Cedid.AkilliLojistik.ServiceMaterials;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.Services
{
    public class GetServiceFilterListDto : PagedAndSortedResultRequestDto
    {
        public Guid ServiceId { get; set; }
        public ServiceMaterialType ServiceMaterialType { get; set; }
        public string Filter { get; set; }
    }
}
