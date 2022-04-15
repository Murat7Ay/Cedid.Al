using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Cedid.AkilliLojistik.ServiceOperations
{
    public class ServiceOperation : FullAuditedAggregateRoot<Guid>
    {
        public Guid ServiceId { get; set; }
        public Guid TechnicianId { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusCodeId { get; set; }
        public string Description { get; set; }
    }
}
