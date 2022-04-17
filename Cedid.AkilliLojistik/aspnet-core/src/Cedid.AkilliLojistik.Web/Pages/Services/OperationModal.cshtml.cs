using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.ServiceOperations;
using Cedid.AkilliLojistik.Services;
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
    public class OperationModalModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public CreateUpdateOperationViewModel Operation { get; set; }


        private readonly IServiceOperationAppService _serviceOperationAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IParameterAppService _parameterAppService;

        public OperationModalModel(IServiceOperationAppService serviceOperationAppService, IParameterAppService parameterAppService, IServiceAppService serviceAppService)
        {
            _serviceOperationAppService = serviceOperationAppService;
            _parameterAppService = parameterAppService;
            _serviceAppService = serviceAppService;
        }
        public List<SelectListItem> StatuCodes { get; set; }
        public List<SelectListItem> Units { get; set; }
        public List<SelectListItem> WareHouseCodes { get; set; }
        public List<SelectListItem> MaterialTypes { get; set; }
        public List<SelectListItem> Users { get; set; }

        public async Task OnGetAsync(Guid serviceId, Guid? id)
        {
            if (id.HasValue)
            {
                var serviceMaterialDto = await _serviceOperationAppService.GetAsync(id.Value);
                Operation = ObjectMapper.Map<ServiceOperationDto, CreateUpdateOperationViewModel>(serviceMaterialDto);
            }
            else
            {
                Operation = new CreateUpdateOperationViewModel();
            }
            Operation.ServiceId = serviceId;
            var statuCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.StatuCode);
            StatuCodes = Utils.GetSelectListItems(statuCodeParameterDtos, false);
            var userLookups = await _serviceAppService.GetUserLookups();
            Users = Utils.GetUserSelectListItem(userLookups);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Operation.Id == default)
            {
                await _serviceOperationAppService.CreateAsync(ObjectMapper.Map<CreateUpdateOperationViewModel, CreateUpdateServiceOperationDto>(Operation));
            }
            else
            {
                await _serviceOperationAppService.UpdateAsync(Operation.Id, ObjectMapper.Map<CreateUpdateOperationViewModel, CreateUpdateServiceOperationDto>(Operation));
            }
            return NoContent();
        }

        public class CreateUpdateOperationViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [HiddenInput]
            public Guid ServiceId { get; set; }
            [DataType(DataType.Date)]
            public DateTime OperationDate { get; set; }
            [DataType(DataType.Time)]
            public DateTime StartDate { get; set; }
            [DataType(DataType.Time)]
            public DateTime EndDate { get; set; }
            [SelectItems(nameof(Users))]
            public Guid TechnicianId { get; set; }
            [SelectItems(nameof(StatuCodes))]
            public int StatusCodeId { get; set; }
            [TextArea(Rows = 4)]
            public string Description { get; set; }
        }
    }
}
