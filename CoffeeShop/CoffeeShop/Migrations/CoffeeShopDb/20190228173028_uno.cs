using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations.CoffeeShopDb
{
    public partial class uno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    CartID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CoffeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Carts_CartID",
                        column: x => x.CartID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Coffee_CoffeeID",
                        column: x => x.CoffeeID,
                        principalTable: "Coffee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Coffee",
                columns: new[] { "ID", "Description", "Name", "Price", "URL" },
                values: new object[,]
                {
                    { 1, "Strong or bold coffee (sometimes espresso) mixed with scalded milk", "Latte", 4.00m, "../coffee/latte" },
                    { 2, "Is a type of coffee drink prepared by diluting an espresso with hot water, giving it a similar strength to, but different flavor from traditionally brewed coffee.", "Americano", 3.00m, "../coffee/americano" },
                    { 3, "Is a full-flavored, concentrated form of coffee that is served in “shots.” It is made by forcing pressurized, hot water through very finely ground coffee beans.", "Espresso", 1.00m, "../coffee/expresso" },
                    { 4, "Goes through a brewing process to become better", "Cold Brew", 5.00m, "../coffee/coldbrew" },
                    { 5, "", "Machiatto", 3.50m, "../coffee/machiatto" },
                    { 6, "Like a caffe latte, it is typically one third espresso and two thirds steamed milk, but a portion of chocolate is added", "Mocha", 4.50m, "../coffee/mocha" },
                    { 7, " Is a cocktail consisting of hot coffee, Irish whiskey, and sugar, stirred, and topped with cream. The coffee is drunk through the cream.", "Irish Coffee", 7.00m, "../coffee/irishcoffee" },
                    { 8, "It is similar to an Americano, but with a stronger aroma and taste. A long black is made by pouring a double-shot of espresso or ristretto over hot water", "Long Black", 3.75m, "../coffee/longblack" },
                    { 9, "A flat white is a coffee drink consisting of espresso with microfoam It is comparable to a latte, but smaller in volume and with less microfoam", "Flat White", 5.75m, "../coffee/flatwhite" },
                    { 10, " cappuccino is an espresso-based coffee drink that originated in Italy, and is traditionally prepared with an espresso shot and steamed milk foam. Variations of the drink involve the use of cream instead of milk, and flavoring with cinnamon or chocolate powder", "Cappuccino", 4.00m, "../coffee/cappuccino" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CartID",
                table: "Products",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CoffeeID",
                table: "Products",
                column: "CoffeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Coffee");
        }
    }
}
