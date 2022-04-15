using System;
using System.Collections.Generic;
using System.Text;

namespace Cedid.AkilliLojistik.Vehicles
{
    public class CreateUpdateVehicleDto
    {
        public string PlateNo { get; set; }
        public int? ColorCodeId { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? EngineTypeId { get; set; }
        public int? GearBoxId { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string GearBoxNumber { get; set; }
        public DateTime TrafficReleaseDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
        public DateTime? InsuranceFinishDate { get; set; }
        public DateTime? TrafficInsuranceFinishDate { get; set; }
        public DateTime? InspectionFinishDate { get; set; }
        public DateTime? ExhaustInspectionFinishDate { get; set; }
        public string LicenseNumber { get; set; }
        public string Radio { get; set; }
        public string Flooring { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
