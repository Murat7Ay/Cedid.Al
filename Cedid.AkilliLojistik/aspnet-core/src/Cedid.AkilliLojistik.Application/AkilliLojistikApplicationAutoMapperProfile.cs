using AutoMapper;
using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.ServiceAccessories;
using Cedid.AkilliLojistik.ServiceMaterials;
using Cedid.AkilliLojistik.ServiceOperations;
using Cedid.AkilliLojistik.Services;
using Cedid.AkilliLojistik.Vehicles;

namespace Cedid.AkilliLojistik;

public class AkilliLojistikApplicationAutoMapperProfile : Profile
{
    public AkilliLojistikApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        //Parameters
        CreateMap<Parameter, ParameterDto>();
        CreateMap<CreateUpdateParameterDto, Parameter>();

        //Vehicles
        CreateMap<Vehicle, VehicleDto>();
        CreateMap<CreateUpdateVehicleDto, Vehicle>();

        //Services
        CreateMap<Service, ServiceDto>();
        CreateMap<CreateUpdateServiceDto, Service>();

        //ServiceMaterials
        CreateMap<ServiceMaterial, ServiceMaterialDto>();
        CreateMap<CreateUpdateServiceMaterialDto, ServiceMaterial>();

        //ServiceAccessories
        CreateMap<ServiceAccessory, ServiceAccessoryDto>();
        CreateMap<CreateUpdateServiceAccessoryDto, ServiceAccessory>();

        //ServiceOperations
        CreateMap<ServiceOperation, ServiceOperationDto>();
        CreateMap<CreateUpdateServiceOperationDto, ServiceOperation>();

    }
}
