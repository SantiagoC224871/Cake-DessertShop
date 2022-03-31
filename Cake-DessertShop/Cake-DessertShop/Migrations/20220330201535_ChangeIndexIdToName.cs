using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeDessertShop.Migrations
{
    public partial class ChangeIndexIdToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_States_Id",
                table: "States");

            migrationBuilder.CreateIndex(
                name: "IX_States_Name",
                table: "States",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_States_Name",
                table: "States");

            migrationBuilder.CreateIndex(
                name: "IX_States_Id",
                table: "States",
                column: "Id",
                unique: true);
        }
    }
}
