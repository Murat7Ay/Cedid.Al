using AutoMapper;
using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.ServiceMaterials;
using Cedid.AkilliLojistik.Services;
using Cedid.AkilliLojistik.Vehicles;

namespace Cedid.AkilliLojistik.Web;

public class AkilliLojistikWebAutoMapperProfile : Profile
{
    public AkilliLojistikWebAutoMapperProfile()
    {
        //Parameters
        CreateMap<ParameterDto, CreateUpdateParameterDto>();
        CreateMap<ParameterDto, Pages.Parameters.EditModalModel.EditParameterViewModel>();
        CreateMap<Pages.Parameters.EditModalModel.EditParameterViewModel, CreateUpdateParameterDto>();
        CreateMap<Pages.Parameters.CreateModalModel.CreateParameterViewModel, CreateUpdateParameterDto>();

        //Vehicles
        CreateMap<VehicleDto, CreateUpdateVehicleDto>();
        CreateMap<VehicleDto, Pages.Vehicles.EditModalModel.EditVehicleViewModel>();
        CreateMap<Pages.Vehicles.EditModalModel.EditVehicleViewModel, CreateUpdateVehicleDto>();
        CreateMap<Pages.Vehicles.CreateModalModel.CreateVehicleViewModel, CreateUpdateVehicleDto>();

        //Services
        CreateMap<ServiceDto, CreateUpdateServiceDto>();
        CreateMap<ServiceDto, Pages.Services.EditModel.EditServiceViewModel>();
        CreateMap<Pages.Services.EditModel.EditServiceViewModel, CreateUpdateServiceDto>();
        CreateMap<Pages.Services.CreateModalModel.CreateServiceViewModel, CreateUpdateServiceDto>();

        CreateMap<ServiceMaterialDto, Pages.Services.MaterialModalModel.CreateUpdateMaterialViewModel>();
        CreateMap<Pages.Services.MaterialModalModel.CreateUpdateMaterialViewModel, CreateUpdateServiceMaterialDto>();
    }
}
