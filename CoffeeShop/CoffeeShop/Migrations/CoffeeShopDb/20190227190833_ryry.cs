using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.CoffeeShopDb
{
    public partial class ryry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 5,
                column: "URL",
                value: "/Assets/macchiato.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "ID",
                keyValue: 5,
                column: "URL",
                value: "/Assets/macchiatto.jpg");
        }
    }
}
