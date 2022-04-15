using Cedid.AkilliLojistik.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories;

namespace Cedid.AkilliLojistik.Services
{
    public class ServiceAppService : CrudAppService<Service, ServiceDto, Guid, GetServiceFilterListDto,
                        CreateUpdateServiceDto, CreateUpdateServiceDto>, IServiceAppService
    {
        public ServiceAppService(IRepository<Service, Guid> repository, IRepository<Vehicle, Guid> vehicleRepository) : base(repository)
        {
            VehicleRepository = vehicleRepository;
        }

        public IRepository<Vehicle, Guid> VehicleRepository { get; }

        public async override Task<PagedResultDto<ServiceDto>> GetListAsync(GetServiceFilterListDto input)
        {
            //todo: filtre duzenlenmeli
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Service.CreationTime);
            }
            var queryable = await Repository.GetQueryableAsync();
            queryable = queryable
                .OrderBy(input.Sorting)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(queryable);
            var totalCount = input.Filter == null
                ? await Repository.CountAsync()
                : await Repository.CountAsync();

            var result = ObjectMapper.Map<List<Service>, List<ServiceDto>>(queryResult);
            List<Guid> vehicleIds = result.Select(s => s.VehicleId).ToList();

            var vehicles = await VehicleRepository.GetListAsync(x => vehicleIds.Contains(x.Id));

            foreach (var service in result)
            {
                
                var vehicleDto = vehicles.FirstOrDefault(x => x.Id == service.VehicleId);
                service.PlateNoText = vehicleDto?.PlateNo;
               
            }

            return new PagedResultDto<ServiceDto>(
               totalCount,
               result
           );
        }
    }
}
