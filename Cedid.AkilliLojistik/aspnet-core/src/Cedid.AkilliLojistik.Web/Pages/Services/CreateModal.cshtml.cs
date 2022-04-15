using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.Services;
using Cedid.AkilliLojistik.Vehicles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Cedid.AkilliLojistik.Web.Pages.Services
{
    public class CreateModalModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public CreateServiceViewModel Service { get; set; }


        private readonly IServiceAppService _serviceAppService;
        private readonly IParameterAppService _parameterAppService;
        private readonly IVehicleAppService _vehicleAppService;

        public CreateModalModel(IServiceAppService serviceAppService, IParameterAppService parameterAppService, IVehicleAppService vehicleAppService)
        {
            _serviceAppService = serviceAppService;
            _parameterAppService = parameterAppService;
            _vehicleAppService = vehicleAppService;
        }
        public List<SelectListItem> FirmCodes { get; set; }
        public List<SelectListItem> Vehicles { get; set; }

        public async Task OnGetAsync()
        {
            Service = new CreateServiceViewModel();
            Service.ServiceStatuType = ServiceStatuType.Entry;

            var firmCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.FirmCode);
            FirmCodes = Utils.GetSelectListItems(firmCodeParameterDtos, false);

            var vehicleDtos = await _vehicleAppService.GetAll();

            Vehicles = Utils.GetVehicleSelectListItem(vehicleDtos, false);

        }

        public async Task<IActionResult> OnPostAsync()
        {
            ServiceDto serviceDto = await _serviceAppService.CreateAsync(
              ObjectMapper.Map<CreateServiceViewModel, CreateUpdateServiceDto>(Service)
              );
            return NoContent();
        }

        public class CreateServiceViewModel
        {
            [Required]
            [SelectItems(nameof(Vehicles))]
            public Guid VehicleId { get; set; }
            [Required]
            [SelectItems(nameof(FirmCodes))]
            public int FirmCodeId { get; set; }
            [DisabledInput]
            public ServiceStatuType ServiceStatuType { get; set; }
        }

    }
}
