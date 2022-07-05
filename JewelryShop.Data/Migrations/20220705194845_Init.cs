using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoURIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    ProductBaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoURIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoURIs_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeProductId = table.Column<int>(type: "int", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ForSell = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Length = table.Column<float>(type: "real", nullable: true),
                    Width = table.Column<float>(type: "real", nullable: true),
                    Caliber = table.Column<float>(type: "real", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sizes_ProductBases_ProductBaseId",
                        column: x => x.ProductBaseId,
                        principalTable: "ProductBases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductBaseId",
                table: "Categories",
                column: "ProductBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SizeItemId",
                table: "Materials",
                column: "SizeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURIs_MaterialId",
                table: "PhotoURIs",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoURIs_ProductBaseId",
                table: "PhotoURIs",
                column: "ProductBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBases_SizeProductId",
                table: "ProductBases",
                column: "SizeProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBases_SupplierId",
                table: "ProductBases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ProductBaseId",
                table: "Sizes",
                column: "ProductBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ProductBases_ProductBaseId",
                table: "Categories",
                column: "ProductBaseId",
                principalTable: "ProductBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Sizes_SizeItemId",
                table: "Materials",
                column: "SizeItemId",
                principalTable: "Sizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoURIs_ProductBases_ProductBaseId",
                table: "PhotoURIs",
                column: "ProductBaseId",
                principalTable: "ProductBases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBases_Sizes_SizeProductId",
                table: "ProductBases",
                column: "SizeProductId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_ProductBases_ProductBaseId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "PhotoURIs");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ProductBases");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
