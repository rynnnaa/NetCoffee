using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.CoffeeShopDb
{
    public partial class sd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 1,
                column: "URL",
                value: "https://c.pxhere.com/images/51/03/d2bf98d676caea95894584536d75-1430487.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 2,
                column: "URL",
                value: "https://get.pxhere.com/photo/coffee-cup-latte-dish-meal-food-produce-ceramic-drink-breakfast-coffee-cup-pastry-21080.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Espresso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 1,
                column: "URL",
                value: "../coffee/latte");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 2,
                column: "URL",
                value: "../coffee/americano");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Expresso");
        }
    }
}
