using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.CoffeeShopDb
{
    public partial class dvsvdfgsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 1,
                column: "URL",
                value: "/Assets/latte.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 2,
                column: "URL",
                value: "/Assets/americano.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 3,
                column: "URL",
                value: "/Assets/espresso.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 4,
                column: "URL",
                value: "/Assets/coldBrew.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 6,
                column: "URL",
                value: "/Assets/mocha.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 7,
                column: "URL",
                value: "/Assets/irishCoffee.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 8,
                column: "URL",
                value: "/Assets/longBlack.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 9,
                column: "URL",
                value: "/Assets/flatWhite.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 10,
                column: "URL",
                value: "/Assets/cappucino.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 1,
                column: "URL",
                value: "");

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
                column: "URL",
                value: "../coffee/expresso");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 4,
                column: "URL",
                value: "https://c.pxhere.com/photos/61/fb/drink_glass_cold_ice_milk-45602.jpg!d");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 6,
                column: "URL",
                value: "../coffee/mocha");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 7,
                column: "URL",
                value: "../coffee/irishcoffee");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 8,
                column: "URL",
                value: "https://c.pxhere.com/images/51/03/d2bf98d676caea95894584536d75-1430487.jpg!d");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 9,
                column: "URL",
                value: "../coffee/flatwhite");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 10,
                column: "URL",
                value: "../coffee/cappuccino");
        }
    }
}
