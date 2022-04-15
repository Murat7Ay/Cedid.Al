using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cedid.AkilliLojistik.MuratMigration
{
    public partial class Vehicletablosukolonaciklama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CedidVehicles",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CedidVehicles");
        }
    }
}
