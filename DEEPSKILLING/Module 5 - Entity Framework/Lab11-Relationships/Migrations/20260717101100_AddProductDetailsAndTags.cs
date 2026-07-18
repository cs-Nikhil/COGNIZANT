using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab11_Relationships.Migrations;

public partial class AddProductDetailsAndTags : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ProductDetails",
            columns: table => new
            {
                ProductDetailId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                WarrantyInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ProductId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailId);
                table.ForeignKey("FK_ProductDetails_Products_ProductId", x => x.ProductId, "Products", "Id", onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Tags",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Tags", x => x.Id));

        migrationBuilder.CreateTable(
            name: "ProductTag",
            columns: table => new
            {
                ProductsId = table.Column<int>(type: "int", nullable: false),
                TagsId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProductTag", x => new { x.ProductsId, x.TagsId });
                table.ForeignKey("FK_ProductTag_Products_ProductsId", x => x.ProductsId, "Products", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_ProductTag_Tags_TagsId", x => x.TagsId, "Tags", "Id", onDelete: ReferentialAction.Cascade);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable("ProductDetails");
        migrationBuilder.DropTable("ProductTag");
        migrationBuilder.DropTable("Tags");
    }
}
