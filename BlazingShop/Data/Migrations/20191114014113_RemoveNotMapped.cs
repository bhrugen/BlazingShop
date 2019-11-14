using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazingShop.Data.Migrations
{
    public partial class RemoveNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProductId",
                table: "Appointments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Products_ProductId",
                table: "Appointments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Products_ProductId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ProductId",
                table: "Appointments");
        }
    }
}
