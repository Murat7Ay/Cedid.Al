using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cedid.AkilliLojistik.MuratMigration
{
    public partial class Vehicletablosu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CedidVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlateNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ColorCodeId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    EngineTypeId = table.Column<int>(type: "int", nullable: false),
                    GearBoxId = table.Column<int>(type: "int", nullable: false),
                    ChassisNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EngineNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    GearBoxNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TrafficReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarrantyEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InsuranceFinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrafficInsuranceFinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InspectionFinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExhaustInspectionFinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Radio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Flooring = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CedidVehicles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CedidVehicles_PlateNo",
                table: "CedidVehicles",
                column: "PlateNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CedidVehicles");
        }
    }
}
