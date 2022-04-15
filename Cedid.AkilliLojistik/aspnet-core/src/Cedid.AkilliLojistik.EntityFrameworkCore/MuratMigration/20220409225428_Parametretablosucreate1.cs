using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cedid.AkilliLojistik.MuratMigration
{
    public partial class Parametretablosucreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CedidParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Spec1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spec2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spec3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spec4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spec5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_CedidParameters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CedidParameters_Code",
                table: "CedidParameters",
                column: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CedidParameters");
        }
    }
}
