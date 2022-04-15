using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.ServiceOperations
{
    public class ServiceOperationDto : FullAuditedEntityDto<Guid>
    {
        public Guid ServiceId { get; set; }
        public Guid TechnicianId { get; set; }
        public string TechnicianText { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusCodeId { get; set; }
        public string StatusCodeText { get; set; }
        public string Description { get; set; }
    }
}
