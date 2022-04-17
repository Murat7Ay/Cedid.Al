using Cedid.AkilliLojistik.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.ServiceAccessories
{
    public class ServiceAccessoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid ServiceId { get; set; }        
        public int AccessoryId { get; set; }
        public string SerialNumber { get; set; }
        [ParamaterRef(nameof(AccessoryId), "Text")]
        public string AccessoryText { get; set; }
        
    }
}
