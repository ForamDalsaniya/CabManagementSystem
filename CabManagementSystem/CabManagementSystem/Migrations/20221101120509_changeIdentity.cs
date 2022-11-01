using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabManagementSystem.Migrations
{
    public partial class changeIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDriver",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDriver",
                table: "AspNetUsers");
        }
    }
}
