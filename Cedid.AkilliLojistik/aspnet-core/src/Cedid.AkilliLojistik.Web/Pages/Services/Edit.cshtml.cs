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
        public List<SelectListItem> FirmCodes { get; set; }
        public List<SelectListItem> Vehicles { get; set; }
        public List<SelectListItem> ProcessDetails { get; set; }
        public List<SelectListItem> Operations { get; set; }
        public List<SelectListItem> ServiceKinds { get; set; }
        public List<SelectListItem> Services { get; set; }
        public List<SelectListItem> InvoiceStatus { get; set; }
        public List<SelectListItem> ProcessTypes { get; set; }
        public List<SelectListItem> ServiceTypes { get; set; }
        public List<SelectListItem> VehicleStatus { get; set; }
        public List<SelectListItem> InvoiceDescriptionStatus { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> OperationCodes { get; set; }
        public List<SelectListItem> Users { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            var serviceDto = await _serviceAppService.GetAsync(id);
            Service = ObjectMapper.Map<ServiceDto, EditServiceViewModel>(serviceDto);
            var colorCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.ColorCode);
            var vehicleLookups = await _vehicleAppService.GetVehicleLookups();
            Vehicles = Utils.GetVehicleSelectListItem(vehicleLookups, false);
            var firmCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.FirmCode);
            FirmCodes = Utils.GetSelectListItems(firmCodeParameterDtos, false);
            var processDetailParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.ProcessDetail);
            ProcessDetails = Utils.GetSelectListItems(processDetailParameterDtos, false);
            var operationParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.Operation);
            Operations = Utils.GetSelectListItems(operationParameterDtos);
            var serviceKindParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.ServiceKind);
            ServiceKinds = Utils.GetSelectListItems(serviceKindParameterDtos);
            var serviceParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.Service);
            Services = Utils.GetSelectListItems(serviceParameterDtos);
            var invoiceStatuParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.InvoiceStatu);
            InvoiceStatus = Utils.GetSelectListItems(invoiceStatuParameterDtos);
            var processTypeStatuParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.ProcessType);
            ProcessTypes = Utils.GetSelectListItems(processTypeStatuParameterDtos);
            var serviceTypeStatuParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.ServiceType);
            ServiceTypes = Utils.GetSelectListItems(serviceTypeStatuParameterDtos);
            var vehicleStatuStatuParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.VehicleStatu);
            VehicleStatus = Utils.GetSelectListItems(vehicleStatuStatuParameterDtos);
            var invoiceDescriptionStatuParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.InvoiceDescriptionStatus);
            InvoiceDescriptionStatus = Utils.GetSelectListItems(invoiceDescriptionStatuParameterDtos);
            var cityParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.City);
            Cities = Utils.GetSelectListItems(cityParameterDtos);
            var operationCodeParameterDtos = await _parameterAppService.GetParameterItemsByCode(ParameterConsts.OperationCode);
            OperationCodes = Utils.GetSelectListItems(operationCodeParameterDtos);
            var userLookups = await _serviceAppService.GetUserLookups();
            Users = Utils.GetUserSelectListItem(userLookups);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _serviceAppService.UpdateAsync(
                Service.Id,
                ObjectMapper.Map<EditServiceViewModel, CreateUpdateServiceDto>(Service)
            );

            return NoContent();
        }

        public class EditServiceViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }
            [SelectItems(nameof(Vehicles))]
            public Guid VehicleId { get; set; }//araç id
            [SelectItems(nameof(FirmCodes))]
            public int? FirmCodeId { get; set; }
            [SelectItems(nameof(ProcessDetails))]
            public int? ProcessDetailId { get; set; }//işlem detayı
            [DataType(DataType.DateTime)]
            public DateTime? ArrivalDate { get; set; }// geliş tarihi
            [DisabledInput]
            public Guid? WorkOrderId { get; set; } //iş emri no
            [MaxLength(ServiceConsts.ContactMaxLength)]
            public string Contact { get; set; } //iletişim
            [SelectItems(nameof(Operations))]
            public int? OperationId { get; set; }//Operasyon
            public float? KilometersDriven { get; set; }//getirilen kilometre
            [MaxLength(ServiceConsts.ReportedFaultMaxLength)]
            [TextArea(Rows = 4)]
            public string ReportedFault { get; set; }//Bildirilen arıza
            [DataType(DataType.Date)]
            public DateTime? RepairDate { get; set; }//onarım tarihi
            [DataType(DataType.DateTime)]
            public DateTime? RepairStartDate { get; set; }//onarım başlangıç tarihi
            [DataType(DataType.DateTime)]
            public DateTime? RepairEndDate { get; set; }//onarım bitiş tarihi
            [SelectItems(nameof(Users))]
            public Guid? TechnicianOneId { get; set; }//teknisyen 1
            [SelectItems(nameof(Users))]
            public Guid? TechnicianTwoId { get; set; }//teknisyen 2 
            [SelectItems(nameof(Users))]
            public Guid? TechnicianThreeId { get; set; }//teknisyen 3 
            [SelectItems(nameof(Users))]
            public Guid? TechnicianFourId { get; set; }//teknisyen 4 
            [MaxLength(ServiceConsts.ServiceResultMaxLength)]
            [TextArea(Rows = 4)]
            public string ServiceResult { get; set; }//servis sonucu
            [MaxLength(ServiceConsts.DetectionMaxLength)]
            [TextArea(Rows = 4)]
            public string Detection { get; set; }//tespit
            [MaxLength(ServiceConsts.ExpenseDescriptionMaxLength)]
            [TextArea(Rows = 4)]
            public string ExpenseDescription { get; set; }//masraf açıklaması
            [MaxLength(ServiceConsts.DescriptionMaxLength)]
            [TextArea(Rows = 4)]
            public string Description { get; set; }//açıklama
            [DataType(DataType.Date)]
            public DateTime? InvoiceDate { get; set; }//fatura tarihi
            [MaxLength(ServiceConsts.InvoiceNumberMaxLength)]
            public string InvoiceNumber { get; set; }//fatura numarası
            [SelectItems(nameof(ServiceKinds))]
            public int? ServiceKindId { get; set; }//servis türü
            [SelectItems(nameof(Services))]
            public int? ServiceId { get; set; }//servisId 
            [SelectItems(nameof(InvoiceStatus))]
            public int? InvoiceStatuId { get; set; }//Fatura Durumu
            [SelectItems(nameof(ProcessTypes))]
            public int? ProcessTypeId { get; set; }//işlem tipi Id
            [SelectItems(nameof(ServiceTypes))]
            public int? ServiceTypeId { get; set; }//servis tipi id
            [SelectItems(nameof(VehicleStatus))]
            public int? VehicleStatuId { get; set; }//araç durumu id
            [SelectItems(nameof(InvoiceDescriptionStatus))]
            public int? InvoiceDescriptionStatuId { get; set; }//fatura acıklama durumu id
            [SelectItems(nameof(Cities))]
            public int? RepairedCityId { get; set; }//onarım yapılan il id
            [SelectItems(nameof(OperationCodes))]
            public int? OperationCodeId { get; set; }//operasyon kodu id
            [DataType(DataType.DateTime)]
            public DateTime? AppointmentStartDate { get; set; }//randevu baslangıc
            [DataType(DataType.DateTime)]
            public DateTime? AppointmentEndDate { get; set; }//randevu bitiş
            [SelectItems(nameof(Users))]
            public Guid? AppointmentUserId { get; set; }//randevu alan id
            [DataType(DataType.Date)]
            public DateTime? WarningDate { get; set; }//uyarı tarihi
            [MaxLength(ServiceConsts.SignerMaxLength)]
            public string Signer { get; set; }//imzalayan
            [MaxLength(ServiceConsts.SignerContactMaxLength)]
            public string SignerContact { get; set; }//imzalayan iletişim
            public ServiceStatuType ServiceStatuTypeId { get; set; }//servis listesi tipi id
        }
    }
}
