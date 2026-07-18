using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab15_Concurrency_RowVersion.Migrations;

public partial class AddProductRowVersion : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<byte[]>(
            name: "RowVersion",
            table: "Products",
            type: "rowversion",
            rowVersion: true,
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "RowVersion",
            table: "Products");
    }
}
