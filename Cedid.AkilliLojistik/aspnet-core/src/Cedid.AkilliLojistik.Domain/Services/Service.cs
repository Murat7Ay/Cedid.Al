using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Cedid.AkilliLojistik.Services
{
    public class Service : FullAuditedAggregateRoot<Guid>
    {
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
