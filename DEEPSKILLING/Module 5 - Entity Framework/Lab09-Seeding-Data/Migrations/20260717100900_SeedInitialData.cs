using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab09_Seeding_Data.Migrations;

public partial class SeedInitialData : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "Categories",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Electronics" },
                { 2, "Groceries" }
            });

        migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Id", "Name", "Price", "CategoryId", "StockQuantity" },
            values: new object[,]
            {
                { 1, "Smartphone", 25000m, 1, 50 },
                { 2, "Wheat Flour", 800m, 2, 100 }
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData("Products", "Id", 1);
        migrationBuilder.DeleteData("Products", "Id", 2);
        migrationBuilder.DeleteData("Categories", "Id", 1);
        migrationBuilder.DeleteData("Categories", "Id", 2);
    }
}
