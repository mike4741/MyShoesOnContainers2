using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalogAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "catalogBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalogSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catalogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_catalogItems_catalogBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "catalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_catalogItems_catalogSizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "catalogSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_catalogItems_catalogTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "catalogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_catalogItems_BrandId",
                table: "catalogItems",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_catalogItems_SizeId",
                table: "catalogItems",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_catalogItems_TypeId",
                table: "catalogItems",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "catalogItems");

            migrationBuilder.DropTable(
                name: "catalogBrands");

            migrationBuilder.DropTable(
                name: "catalogSizes");

            migrationBuilder.DropTable(
                name: "catalogTypes");
        }
    }
}
