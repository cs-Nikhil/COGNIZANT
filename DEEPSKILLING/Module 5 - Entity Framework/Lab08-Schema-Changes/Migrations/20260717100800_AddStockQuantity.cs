using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab08_Schema_Changes.Migrations;

public partial class AddStockQuantity : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "StockQuantity",
            table: "Products",
            type: "int",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "StockQuantity",
            table: "Products");
    }
}
