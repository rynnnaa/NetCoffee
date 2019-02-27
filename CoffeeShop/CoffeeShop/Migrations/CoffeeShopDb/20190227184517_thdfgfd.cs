using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.CoffeeShopDb
{
    public partial class thdfgfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 4,
                column: "URL",
                value: "https://c.pxhere.com/photos/61/fb/drink_glass_cold_ice_milk-45602.jpg!d");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 5,
                column: "URL",
                value: "~Assets/macchiatto.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 4,
                column: "URL",
                value: "../coffee/coldbrew");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 5,
                column: "URL",
                value: "../coffee/machiatto");
        }
    }
}
