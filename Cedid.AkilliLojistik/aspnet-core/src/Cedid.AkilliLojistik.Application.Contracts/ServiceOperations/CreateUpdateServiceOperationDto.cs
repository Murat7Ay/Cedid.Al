using System;
using System.Collections.Generic;
using System.Text;

namespace Cedid.AkilliLojistik.ServiceOperations
{
    public class CreateUpdateServiceOperationDto
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
