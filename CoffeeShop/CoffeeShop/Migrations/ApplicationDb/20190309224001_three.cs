using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.ApplicationDb
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
