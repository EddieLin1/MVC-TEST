using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcStore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsRepo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    QuantitySold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsRepo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderList",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State_Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderList", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ItemsRepo",
                columns: new[] { "Id", "Description", "Name", "Price", "QuantitySold" },
                values: new object[,]
                {
                    { 1, "Yellow/Green bananas, high in potassium", "Bananas (Bunch)", 1.95, 0 },
                    { 2, "Long and green and high in minerals good for skin", "English Cucumbers", 2.48, 0 },
                    { 3, "Sweet and red strawberries, very juicy", "Strawberries", 4.9800000000000004, 0 },
                    { 4, "Long green stalks, also called \"Scallions\"", "Green Onion", 0.97999999999999998, 0 },
                    { 5, "Grade A large omega 3 eggs", "Eggs", 3.98, 0 },
                    { 6, "Green Avocados from Mexico", "Avocados (Bag)", 4.5899999999999999, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsRepo");

            migrationBuilder.DropTable(
                name: "OrderList");

            migrationBuilder.DropTable(
                name: "ShoppingCart");
        }
    }
}
