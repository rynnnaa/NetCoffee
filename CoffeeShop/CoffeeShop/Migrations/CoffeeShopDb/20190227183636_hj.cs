using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.CoffeeShopDb
{
    public partial class hj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 8,
                column: "URL",
                value: "https://c.pxhere.com/images/51/03/d2bf98d676caea95894584536d75-1430487.jpg!d");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 8,
                column: "URL",
                value: "../coffee/longblack");
        }
    }
}
