using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Cedid.AkilliLojistik.Vehicles
{
    public interface IVehicleAppService : ICrudAppService<
            VehicleDto,
            Guid,
            GetVehicleFilterListDto,
            CreateUpdateVehicleDto>
    {
        Task<List<VehicleDto>> GetAll();
    }
}
