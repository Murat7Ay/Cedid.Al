using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Cedid.AkilliLojistik.Parameters
{
    public class Parameter : FullAuditedAggregateRoot<int>
    {
        public string Code { get; set; }
        public string Text { get; set; }
        public bool IsActive { get; set; }
        public string Spec1 { get; set; }
        public string Spec2 { get; set; }
        public string Spec3 { get; set; }
        public string Spec4 { get; set; }
        public string Spec5 { get; set; }
    }
}
