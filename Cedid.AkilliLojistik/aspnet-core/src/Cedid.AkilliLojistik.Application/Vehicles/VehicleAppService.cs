using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.Lookups;

namespace Cedid.AkilliLojistik.Vehicles
{
    public class VehicleAppService : CrudAppService<Vehicle, VehicleDto, Guid, GetVehicleFilterListDto,
                        CreateUpdateVehicleDto, CreateUpdateVehicleDto>, IVehicleAppService
    {
        private readonly IRepository<Parameter, int> parameterRepository;

        public VehicleAppService(IRepository<Vehicle, Guid> repository, IRepository<Parameter, int> parameterRepository) : base(repository)
        {
            this.parameterRepository = parameterRepository;
        }

        public async Task<List<VehicleLookup>> GetVehicleLookups()
        {
            List<Vehicle> vehicles = await Repository.GetListAsync();
            return vehicles.Select(s => new VehicleLookup { Id = s.Id, PlateNo = s.PlateNo }).ToList();
        }

        public async override Task<PagedResultDto<VehicleDto>> GetListAsync(GetVehicleFilterListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Vehicle.PlateNo);
            }
            var queryable = await Repository.GetQueryableAsync();
            queryable = queryable.WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    c => c.PlateNo.Contains(input.Filter)
                )
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(queryable);
            var totalCount = input.Filter == null
                ? await Repository.CountAsync()
                : await Repository.CountAsync(c => c.PlateNo.Contains(input.Filter));

            var result = ObjectMapper.Map<List<Vehicle>, List<VehicleDto>>(queryResult);
            List<int> brandIds = result.Where(x => x.BrandId.HasValue).Select(s => s.BrandId.Value).ToList();

            var brandParemeters = await parameterRepository.GetListAsync(x => brandIds.Contains(x.Id));

            foreach (var vehicle in result)
            {
                if (vehicle.BrandId.HasValue)
                {
                    var parameterDto = brandParemeters.FirstOrDefault(x => x.Id == vehicle.BrandId);
                    vehicle.BrandText = parameterDto?.Text;
                }
            }

            return new PagedResultDto<VehicleDto>(
               totalCount,
               result
           );
        }
    }
}
