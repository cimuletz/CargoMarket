using Microsoft.EntityFrameworkCore.Migrations;

namespace BursaTransport.DAL.Migrations
{
    public partial class FixedClientTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CliendId",
                table: "ClientTransports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CliendId",
                table: "ClientTransports",
                type: "int",
                nullable: true);
        }
    }
}
