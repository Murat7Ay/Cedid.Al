using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.ServiceAccessories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Cedid.AkilliLojistik.Web.Pages.Services
{
    public class AccessoryModalModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public CreateUpdateAcccessoryViewModel Accessory { get; set; }


        private readonly IServiceAccessoryAppService _serviceAccessoryAppService;
        private readonly IParameterAppService _parameterAppService;

        public AccessoryModalModel(IServiceAccessoryAppService serviceAccessoryAppService, IParameterAppService parameterAppService)
        {
            _serviceAccessoryAppService = serviceAccessoryAppService;
            _parameterAppService = parameterAppService;
        }
        public List<SelectListItem> Accessories { get; set; }

        public async Task OnGetAsync(Guid serviceId, Guid? id)
        {
            if (id.HasValue)
            {
                var serviceAccessorylDto = await _serviceAccessoryAppService.GetAsync(id.Value);
                Accessory = ObjectMapper.Map<ServiceAccessoryDto, CreateUpdateAcccessoryViewModel>(serviceAccessorylDto);
            }
            else
            {
                Accessory = new CreateUpdateAcccessoryViewModel();
            }
            Accessory.ServiceId = serviceId;
            var accessoryParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.Accessory);
            Accessories = Utils.GetSelectListItems(accessoryParameterDtos, false);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Accessory.Id == default)
            {
                await _serviceAccessoryAppService.CreateAsync(ObjectMapper.Map<CreateUpdateAcccessoryViewModel, CreateUpdateServiceAccessoryDto>(Accessory));
            }
            else
            {
                await _serviceAccessoryAppService.UpdateAsync(Accessory.Id, ObjectMapper.Map<CreateUpdateAcccessoryViewModel, CreateUpdateServiceAccessoryDto>(Accessory));
            }
            return NoContent();
        }

        public class CreateUpdateAcccessoryViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [HiddenInput]
            public Guid ServiceId { get; set; }
            [SelectItems(nameof(Accessories))]
            public int AccessoryId { get; set; }
            public string SerialNumber { get; set; }
        }
    }
}
