using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Cedid.AkilliLojistik.Web.Pages.Vehicles
{
    public class CreateModalModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public CreateVehicleViewModel Vehicle { get; set; }


        private readonly IParameterAppService _parameterAppService;
        private readonly IVehicleAppService _vehicleAppService;

        public CreateModalModel(IParameterAppService parameterAppService, IVehicleAppService vehicleAppService)
        {
            _parameterAppService = parameterAppService;
            _vehicleAppService = vehicleAppService;
        }

        public List<SelectListItem> ColorCodes { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> FuelTypes { get; set; }
        public List<SelectListItem> VehicleTypes { get; set; }
        public List<SelectListItem> EngineTypes { get; set; }
        public List<SelectListItem> GearBoxTypes { get; set; }


        public async Task OnGetAsync()
        {
            Vehicle = new CreateVehicleViewModel();
            Vehicle.TrafficReleaseDate = DateTime.Now.AddYears(-1);

            var colorCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.ColorCode);
            var brandParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.Brand);
            var modelParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.Model);
            var fuelTypeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.FuelType);
            var vehicleTypeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.VehicleType);
            var engineTypeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.EngineType);
            var gearBoxTypeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.GearBoxType);

            ColorCodes = Utils.GetSelectListItems(colorCodeParameterDtos);
            Brands = Utils.GetSelectListItems(brandParameterDtos);
            Models = Utils.GetSelectListItems(modelParameterDtos);
            FuelTypes = Utils.GetSelectListItems(fuelTypeParameterDtos);
            VehicleTypes = Utils.GetSelectListItems(vehicleTypeParameterDtos);
            EngineTypes = Utils.GetSelectListItems(engineTypeParameterDtos);
            GearBoxTypes = Utils.GetSelectListItems(gearBoxTypeParameterDtos);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _vehicleAppService.CreateAsync(ObjectMapper.Map<CreateVehicleViewModel, CreateUpdateVehicleDto>(Vehicle));
            return NoContent();
        }

        public class CreateVehicleViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [Required]
            [MaxLength(VehicleConsts.PlateNoMaxLength)]
            public string PlateNo { get; set; }
            [SelectItems(nameof(ColorCodes))]
            public int? ColorCodeId { get; set; }
            [SelectItems(nameof(Brands))]
            public int? BrandId { get; set; }
            [SelectItems(nameof(Models))]
            public int? ModelId { get; set; }
            [SelectItems(nameof(FuelTypes))]
            public int? FuelTypeId { get; set; }
            [SelectItems(nameof(VehicleTypes))]
            public int? VehicleTypeId { get; set; }
            [SelectItems(nameof(EngineTypes))]
            public int? EngineTypeId { get; set; }
            [SelectItems(nameof(GearBoxTypes))]
            public int? GearBoxId { get; set; }
            [MaxLength(VehicleConsts.ChassisNumberMaxLength)]
            public string ChassisNumber { get; set; }
            [MaxLength(VehicleConsts.EngineNumberMaxLength)]
            public string EngineNumber { get; set; }
            [MaxLength(VehicleConsts.GearBoxNumberMaxLength)]
            public string GearBoxNumber { get; set; }
            [Required]
            [DataType(DataType.Date)]
            public DateTime TrafficReleaseDate { get; set; }
            [DataType(DataType.Date)]
            public DateTime? WarrantyEndDate { get; set; }
            [DataType(DataType.Date)]
            public DateTime? InsuranceFinishDate { get; set; }
            [DataType(DataType.Date)]
            public DateTime? TrafficInsuranceFinishDate { get; set; }
            [DataType(DataType.Date)]
            public DateTime? InspectionFinishDate { get; set; }
            [DataType(DataType.Date)]
            public DateTime? ExhaustInspectionFinishDate { get; set; }
            [Required]
            [MaxLength(VehicleConsts.LicenseNumberMaxLength)]
            public string LicenseNumber { get; set; }
            [MaxLength(VehicleConsts.RadioMaxLength)]
            public string Radio { get; set; }
            [MaxLength(VehicleConsts.FlooringMaxLength)]
            public string Flooring { get; set; }
            [TextArea(Rows = 4)]
            [MaxLength(VehicleConsts.DescriptionMaxLength)]
            public string Description { get; set; }
            [HiddenInput]
            [MaxLength(VehicleConsts.ImageUrlMaxLength)]
            public string ImageUrl { get; set; }
        }

    }
}
