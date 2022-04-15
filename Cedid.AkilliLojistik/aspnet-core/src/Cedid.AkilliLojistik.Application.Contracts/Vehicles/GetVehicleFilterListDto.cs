using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.Vehicles
{
    public class GetVehicleFilterListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
