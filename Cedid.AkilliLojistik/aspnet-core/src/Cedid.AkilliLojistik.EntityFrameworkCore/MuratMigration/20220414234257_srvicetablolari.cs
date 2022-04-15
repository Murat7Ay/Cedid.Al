using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cedid.AkilliLojistik.MuratMigration
{
    public partial class srvicetablolari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CedidVehicles",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CedidServiceAccessories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_CedidServiceAccessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CedidServiceMaterials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockCodeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    KDV = table.Column<float>(type: "real", nullable: false),
                    KDVAmount = table.Column<float>(type: "real", nullable: false),
                    IsKDVIncluded = table.Column<bool>(type: "bit", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    DiscountAmount = table.Column<float>(type: "real", nullable: false),
                    DiscountTwo = table.Column<float>(type: "real", nullable: false),
                    DiscountTwoAmount = table.Column<float>(type: "real", nullable: false),
                    NetAmount = table.Column<float>(type: "real", nullable: false),
                    WareHouseCodeId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CedidServiceMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CedidServiceOperations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TechnicianId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusCodeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
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
                    table.PrimaryKey("PK_CedidServiceOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CedidServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirmCodeId = table.Column<int>(type: "int", nullable: true),
                    ProcessDetailId = table.Column<int>(type: "int", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: true),
                    KilometersDriven = table.Column<float>(type: "real", nullable: true),
                    ReportedFault = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicianOneId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicianTwoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicianThreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TechnicianFourId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ServiceResult = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Detection = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServiceKindId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    InvoiceStatuId = table.Column<int>(type: "int", nullable: true),
                    ProcessTypeId = table.Column<int>(type: "int", nullable: true),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: true),
                    VehicleStatuId = table.Column<int>(type: "int", nullable: true),
                    InvoiceDescriptionStatuId = table.Column<int>(type: "int", nullable: true),
                    RepairedCityId = table.Column<int>(type: "int", nullable: true),
                    OperationCodeId = table.Column<int>(type: "int", nullable: true),
                    AppointmentStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WarningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Signer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SignerContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ServiceStatuTypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CedidServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CedidServiceAccessories_ServiceId",
                table: "CedidServiceAccessories",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CedidServiceMaterials_ServiceId",
                table: "CedidServiceMaterials",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CedidServiceMaterials_ServiceId_Type",
                table: "CedidServiceMaterials",
                columns: new[] { "ServiceId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_CedidServiceOperations_ServiceId",
                table: "CedidServiceOperations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CedidServices_VehicleId",
                table: "CedidServices",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CedidServiceAccessories");

            migrationBuilder.DropTable(
                name: "CedidServiceMaterials");

            migrationBuilder.DropTable(
                name: "CedidServiceOperations");

            migrationBuilder.DropTable(
                name: "CedidServices");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CedidVehicles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
