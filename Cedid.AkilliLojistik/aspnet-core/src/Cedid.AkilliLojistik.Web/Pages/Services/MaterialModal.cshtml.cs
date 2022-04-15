using Cedid.AkilliLojistik.Parameters;
using Cedid.AkilliLojistik.ServiceMaterials;
using Cedid.AkilliLojistik.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Cedid.AkilliLojistik.Web.Pages.Services
{
    public class MaterialModalModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public CreateUpdateMaterialViewModel Material { get; set; }


        private readonly IServiceMaterialAppService _serviceMaterialAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly IParameterAppService _parameterAppService;

        public MaterialModalModel(IServiceMaterialAppService serviceMaterialAppService, IParameterAppService parameterAppService, IServiceAppService serviceAppService)
        {
            _serviceMaterialAppService = serviceMaterialAppService;
            _parameterAppService = parameterAppService;
            _serviceAppService = serviceAppService;
        }
        private Guid? Id { get; set; }
        private Guid ServiceId { get; set; }
        private ServiceMaterialType ServiceMaterialType { get; set; }
        public List<SelectListItem> StockCodes { get; set; }
        public List<SelectListItem> Units { get; set; }
        public List<SelectListItem> WareHouseCodes { get; set; }
        public List<SelectListItem> MaterialTypes { get; set; }
        public List<SelectListItem> Users { get; set; }

        public async Task OnGetAsync(Guid serviceId, ServiceMaterialType serviceMaterialType, Guid? id)
        {
            ServiceId = serviceId;
            ServiceMaterialType = serviceMaterialType;
            Id = id;
            if (id.HasValue)
            {
                var serviceMaterialDto = await _serviceMaterialAppService.GetAsync(id.Value);
                Material = ObjectMapper.Map<ServiceMaterialDto, CreateUpdateMaterialViewModel>(serviceMaterialDto);
            }
            else
            {
                Material = new CreateUpdateMaterialViewModel();
                Material.Type = ServiceMaterialType;
            }
            var stockCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.StockCode);
            StockCodes = Utils.GetSelectListItems(stockCodeParameterDtos, false);
            var unitParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.Unit);
            Units = Utils.GetSelectListItems(unitParameterDtos, false);
            var wareHouseCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.WareHouseCode);
            WareHouseCodes = Utils.GetSelectListItems(wareHouseCodeParameterDtos);
            var materialTypeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.MaterialType);
            MaterialTypes = Utils.GetSelectListItems(materialTypeParameterDtos, false);
            var userLookups = await _serviceAppService.GetUserLookups();
            Users = Utils.GetUserSelectListItem(userLookups);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Id.HasValue)
            {
                await _serviceMaterialAppService.UpdateAsync(Material.Id, ObjectMapper.Map<CreateUpdateMaterialViewModel, CreateUpdateServiceMaterialDto>(Material));
            }
            else
            {
                await _serviceMaterialAppService.CreateAsync(ObjectMapper.Map<CreateUpdateMaterialViewModel, CreateUpdateServiceMaterialDto>(Material));
            }
            return NoContent();
        }

        public class CreateUpdateMaterialViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [HiddenInput]
            public Guid ServiceId { get; set; }
            [HiddenInput]
            public ServiceMaterialType Type { get; set; }
            [SelectItems(nameof(StockCodes))]
            public string StockCode { get; set; }
            [SelectItems(nameof(Units))]
            public int Unit { get; set; }
            public float Quantity { get; set; }
            public float Price { get; set; }
            public float Amount { get; set; }
            public bool IsKDVIncluded { get; set; }
            public float KDV { get; set; }
            public float KDVAmount { get; set; }
            [Range(0, 100)]
            public float Discount { get; set; }
            public float DiscountAmount { get; set; }
            [Range(0, 100)]
            public float DiscountTwo { get; set; }
            [DisabledInput]
            public float DiscountTwoAmount { get; set; }
            [DisabledInput]
            public float NetAmount { get; set; }
            [SelectItems(nameof(WareHouseCodes))]
            public int? WareHouseCode { get; set; }
            [TextArea(Rows = 4)]
            [MaxLength(ServiceMaterialConsts.DescriptionMaxLength)]
            public string Description { get; set; }
            [SelectItems(nameof(MaterialTypes))]
            public int MaterialTypeId { get; set; }
            [SelectItems(nameof(Users))]
            public Guid? User { get; set; }
        }
    }
}
