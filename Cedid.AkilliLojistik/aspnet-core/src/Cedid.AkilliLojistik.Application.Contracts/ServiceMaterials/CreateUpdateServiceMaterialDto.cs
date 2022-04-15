using System;
using System.Collections.Generic;
using System.Text;

namespace Cedid.AkilliLojistik.ServiceMaterials
{
    public class CreateUpdateServiceMaterialDto
    {
        public Guid ServiceId { get; set; }
        public int StockCodeId { get; set; }
        public float Quantity { get; set; }
        public int UnitId { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public float KDV { get; set; }
        public float KDVAmount { get; set; }
        public bool IsKDVIncluded { get; set; }
        public float Discount { get; set; }
        public float DiscountAmount { get; set; }
        public float DiscountTwo { get; set; }
        public float DiscountTwoAmount { get; set; }
        public float NetAmount { get; set; }
        public int? WareHouseCodeId { get; set; }
        public string Description { get; set; }
        public Guid? UserId { get; set; }
        public int MaterialTypeId { get; set; }
        public ServiceMaterialType Type { get; set; }
    }
}
