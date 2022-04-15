using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.Services
{
    public class ServiceDto : FullAuditedEntityDto<Guid>
    {
        public Guid VehicleId { get; set; }//araç id
        public int? FirmCodeId { get; set; }
        public string FirmCodeText { get; set; }
        public string PlateNoText { get; set; }//plaka no
        public int TotalVehicleServiceCount { get; set; }//Araç için verilen toplam servis sayısı
        public int? ProcessDetailId { get; set; }//işlem detayı
        public string ProcessDetailText { get; set; } //işlem detayı metni
        public DateTime? ArrivalDate { get; set; }// geliş tarihi
        public Guid? WorkOrderId { get; set; } //iş emri no
        public string Contact { get; set; } //iletişim
        public int? OperationId { get; set; }//Operasyon
        public string OperationText { get; set; }//operasyon metni
        public float? KilometersDriven { get; set; }//getirilen kilometre
        public string ReportedFault { get; set; }//Bildirilen arıza
        public DateTime? RepairDate { get; set; }//onarım tarihi
        public DateTime? RepairStartDate { get; set; }//onarım başlangıç tarihi
        public DateTime? RepairEndDate { get; set; }//onarım bitiş tarihi
        public Guid? TechnicianOneId { get; set; }//teknisyen 1
        public string TechnicianOneText { get; set; }//teknisyen 1 adı
        public Guid? TechnicianTwoId { get; set; }//teknisyen 2 
        public string TechnicianTwoText { get; set; }//teknisyen 2 adı
        public Guid? TechnicianThreeId { get; set; }//teknisyen 3 
        public string TechnicianThreeText { get; set; }//teknisyen3 adı
        public Guid? TechnicianFourId { get; set; }//teknisyen 4 
        public string TechnicianFourText { get; set; }//teknisyen 4 adı
        public string ServiceResult { get; set; }//servis sonucu
        public string Detection { get; set; }//tespit
        public string ExpenseDescription { get; set; }//masraf açıklaması
        public string Description { get; set; }//açıklama
        public DateTime? InvoiceDate { get; set; }//fatura tarihi
        public string InvoiceNumber { get; set; }//fatura numarası
        public int? ServiceKindId { get; set; }//servis türü
        public string ServiceKindText { get; set; }//servis türü metni
        public int? ServiceId { get; set; }//servisId 
        public string ServiceText { get; set; }//servis adı
        public int? InvoiceStatuId { get; set; }//Fatura Durumu
        public string InvoiceStatuText { get; set; }// fatura durumu metni
        public int? ProcessTypeId { get; set; }//işlem tipi Id
        public string ProcessTypeText { get; set; }//işlem tipi metni
        public int? ServiceTypeId { get; set; }//servis tipi id
        public string ServiceTypeText { get; set; }//servis tipi metni
        public int? VehicleStatuId { get; set; }//araç durumu id
        public string VehicleStatuText { get; set; }//araç durumu metni
        public int? InvoiceDescriptionStatuId { get; set; }//fatura acıklama durumu id
        public string InvoiceDescriptionStatuText { get; set; }//fatura acıklama durumu metni
        public int? RepairedCityId { get; set; }//onarım yapılan il id
        public string RepairedCityText { get; set; }// onarım yapılan il metni
        public int? OperationCodeId { get; set; }//operasyon kodu id
        public string OperationCodeText { get; set; }//operasyon kodu metni
        public DateTime? AppointmentStartDate { get; set; }//randevu baslangıc
        public DateTime? AppointmentEndDate { get; set; }//randevu bitiş
        public Guid? AppointmentUserId { get; set; }//randevu alan id
        public string AppointmentUserText { get; set; }//randevu alan metni
        public DateTime? WarningDate { get; set; }//uyarı tarihi
        public string Signer { get; set; }//imzalayan
        public string SignerContact { get; set; }//imzalayan iletişim
        public ServiceStatuType ServiceStatuTypeId { get; set; }//servis listesi tipi id

    }
}
