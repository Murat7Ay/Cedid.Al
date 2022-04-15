using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.Parameters
{
    public class ParameterDto : FullAuditedEntityDto<int>
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
