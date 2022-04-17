using Cedid.AkilliLojistik.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cedid.AkilliLojistik.ServiceMaterials
{
    public class ServiceMaterialDto : FullAuditedEntityDto<Guid>
    {
        public Guid ServiceId { get; set; }
        public int StockCodeId { get; set; }
        [ParamaterRef(nameof(StockCodeId), "Text")]
        public string StockCodeText { get; set; }
        public int Quantity { get; set; }
        public int UnitId { get; set; }
        [ParamaterRef(nameof(UnitId), "Text")]
        public string UnitText { get; set; }
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
        [ParamaterRef(nameof(WareHouseCodeId), "Text")]
        public string WareHouseCodeText { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public string UserText { get; set; }
        public int MaterialTypeId { get; set; }
        [ParamaterRef(nameof(MaterialTypeId), "Text")]
        public string MaterialTypeText { get; set; }
        public ServiceMaterialType Type { get; set; }
    }
}
