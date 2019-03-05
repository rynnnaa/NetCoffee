using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeShop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    URL = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoffeeID = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Coffee_CoffeeID",
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
                    { 1, "Strong or bold coffee (sometimes espresso) mixed with scalded milk", "Latte", 4.00m, "/Assets/latte.jpg" },
                    { 2, "Is a type of coffee drink prepared by diluting an espresso with hot water, giving it a similar strength to, but different flavor from traditionally brewed coffee.", "Americano", 3.00m, "/Assets/americano.jpg" },
                    { 3, "Is a full-flavored, concentrated form of coffee that is served in “shots.” It is made by forcing pressurized, hot water through very finely ground coffee beans.", "Espresso", 1.00m, "/Assets/espresso.jpg" },
                    { 4, "Goes through a brewing process to become better", "Cold Brew", 5.00m, "/Assets/coldBrew.jpg" },
                    { 5, " It's basically an espresso (served in a demitasse cup) with a small amount of foamed milk on top -- the name macchiato means marked", "Machiatto", 3.50m, "/Assets/macchiato.jpg" },
                    { 6, "Like a caffe latte, it is typically one third espresso and two thirds steamed milk, but a portion of chocolate is added", "Mocha", 4.50m, "/Assets/mocha.jpg" },
                    { 7, " Is a cocktail consisting of hot coffee, Irish whiskey, and sugar, stirred, and topped with cream. The coffee is drunk through the cream.", "Irish Coffee", 7.00m, "/Assets/irishCoffee.jpg" },
                    { 8, "It is similar to an Americano, but with a stronger aroma and taste. A long black is made by pouring a double-shot of espresso or ristretto over hot water", "Long Black", 3.75m, "/Assets/longBlack.jpg" },
                    { 9, "A flat white is a coffee drink consisting of espresso with microfoam It is comparable to a latte, but smaller in volume and with less microfoam", "Flat White", 5.75m, "/Assets/flatWhite.jpg" },
                    { 10, " cappuccino is an espresso-based coffee drink that originated in Italy, and is traditionally prepared with an espresso shot and steamed milk foam. Variations of the drink involve the use of cream instead of milk, and flavoring with cinnamon or chocolate powder", "Cappuccino", 4.00m, "/Assets/cappucino.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CoffeeID",
                table: "ShoppingCartItems",
                column: "CoffeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Coffee");
        }
    }
}
