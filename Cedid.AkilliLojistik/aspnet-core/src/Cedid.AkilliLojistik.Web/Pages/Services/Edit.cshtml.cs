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
    public class EditModel : AkilliLojistikPageModel
    {
        [BindProperty]
        public EditServiceViewModel Service { get; set; }


        private readonly IParameterAppService _parameterAppService;
        private readonly IVehicleAppService _vehicleAppService;
        private readonly IServiceAppService _serviceAppService;

        public EditModel(IParameterAppService parameterAppService, IVehicleAppService vehicleAppService, IServiceAppService serviceAppService)
        {
            _parameterAppService = parameterAppService;
            _vehicleAppService = vehicleAppService;
            _serviceAppService = serviceAppService;
        }
        public List<SelectListItem> ColorCodes { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> FuelTypes { get; set; }
        public List<SelectListItem> VehicleTypes { get; set; }
        public List<SelectListItem> EngineTypes { get; set; }
        public List<SelectListItem> GearBoxTypes { get; set; }
        public async Task OnGetAsync(Guid id)
        {
            var serviceDto = await _serviceAppService.GetAsync(id);
            Service = ObjectMapper.Map<ServiceDto, EditServiceViewModel>(serviceDto);
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
            await _vehicleAppService.UpdateAsync(
                Vehicle.Id,
                ObjectMapper.Map<EditVehicleViewModel, CreateUpdateVehicleDto>(Vehicle)
            );

            return NoContent();
        }

        public class EditServiceViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            public Guid VehicleId { get; set; }//araç id
            public int? FirmCodeId { get; set; }
            public int? ProcessDetailId { get; set; }//işlem detayı
            public DateTime? ArrivalDate { get; set; }// geliş tarihi
            public Guid? WorkOrderId { get; set; } //iş emri no
            public string Contact { get; set; } //iletişim
            public int? OperationId { get; set; }//Operasyon
            public float? KilometersDriven { get; set; }//getirilen kilometre
            public string ReportedFault { get; set; }//Bildirilen arıza
            public DateTime? RepairDate { get; set; }//onarım tarihi
            public DateTime? RepairStartDate { get; set; }//onarım başlangıç tarihi
            public DateTime? RepairEndDate { get; set; }//onarım bitiş tarihi
            public Guid? TechnicianOneId { get; set; }//teknisyen 1
            public Guid? TechnicianTwoId { get; set; }//teknisyen 2 
            public Guid? TechnicianThreeId { get; set; }//teknisyen 3 
            public Guid? TechnicianFourId { get; set; }//teknisyen 4 
            public string ServiceResult { get; set; }//servis sonucu
            public string Detection { get; set; }//tespit
            public string ExpenseDescription { get; set; }//masraf açıklaması
            public string Description { get; set; }//açıklama
            public DateTime? InvoiceDate { get; set; }//fatura tarihi
            public string InvoiceNumber { get; set; }//fatura numarası
            public int? ServiceKindId { get; set; }//servis türü
            public int? ServiceId { get; set; }//servisId 
            public int? InvoiceStatuId { get; set; }//Fatura Durumu
            public int? ProcessTypeId { get; set; }//işlem tipi Id
            public int? ServiceTypeId { get; set; }//servis tipi id
            public int? VehicleStatuId { get; set; }//araç durumu id
            public int? InvoiceDescriptionStatuId { get; set; }//fatura acıklama durumu id
            public int? RepairedCityId { get; set; }//onarım yapılan il id
            public int? OperationCodeId { get; set; }//operasyon kodu id
            public DateTime? AppointmentStartDate { get; set; }//randevu baslangıc
            public DateTime? AppointmentEndDate { get; set; }//randevu bitiş
            public Guid? AppointmentUserId { get; set; }//randevu alan id
            public DateTime? WarningDate { get; set; }//uyarı tarihi
            public string Signer { get; set; }//imzalayan
            public string SignerContact { get; set; }//imzalayan iletişim
            public ServiceStatuType ServiceStatuTypeId { get; set; }//servis listesi tipi id
        }
    }
}
