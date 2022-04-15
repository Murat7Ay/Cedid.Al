using System;
using System.Collections.Generic;
using System.Text;

namespace Cedid.AkilliLojistik.ServiceAccessories
{
    public class CreateUpdateServiceAccessoryDto
    {
        public Guid ServiceId { get; set; }
        public int AccessoryId { get; set; }
        public string SerialNumber { get; set; }
    }
}
