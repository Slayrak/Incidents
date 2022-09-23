using Microsoft.EntityFrameworkCore.Migrations;

namespace Incidents.Infrastructure.Migrations
{
    public partial class GetRidOfIdForIncidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Incidents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Incidents",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
