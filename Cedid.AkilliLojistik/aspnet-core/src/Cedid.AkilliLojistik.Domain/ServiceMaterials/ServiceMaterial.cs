using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Cedid.AkilliLojistik.ServiceMaterials
{
    public class ServiceMaterial : FullAuditedAggregateRoot<Guid>
    {
        public Guid ServiceId { get; set; }
        public int StockCodeId { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public int KDV { get; set; }
        public decimal KDVAmount { get; set; }
        public bool IsKDVIncluded { get; set; }
        public int Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int DiscountTwo { get; set; }
        public decimal DiscountTwoAmount { get; set; }
        public decimal NetAmount { get; set; }
        public int? WareHouseCodeId { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public int MaterialTypeId { get; set; }
        public ServiceMaterialType Type { get; set; }
    }
}
