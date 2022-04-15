using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Cedid.AkilliLojistik.ServiceAccessories
{
    public class ServiceAccessory : FullAuditedAggregateRoot<Guid>
    {
        public Guid ServiceId { get; set; }
        public int AccessoryId { get; set; }
        public string SerialNumber { get; set; }
    }
}
