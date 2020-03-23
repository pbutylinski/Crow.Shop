using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crow.Shop.Data.Migrations
{
    public partial class ProductOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "ProductTranslations",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductOptionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptionGroup_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    PriceDifference = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOption_ProductOptionGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ProductOptionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionGroupTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductOptionGroupId = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionGroupTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptionGroupTranslation_ProductOptionGroup_ProductOptionGroupId",
                        column: x => x.ProductOptionGroupId,
                        principalTable: "ProductOptionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductOptionId = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptionTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOptionTranslation_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOption_GroupId",
                table: "ProductOption",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionGroup_ProductId",
                table: "ProductOptionGroup",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionGroupTranslation_ProductOptionGroupId",
                table: "ProductOptionGroupTranslation",
                column: "ProductOptionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOptionTranslation_ProductOptionId",
                table: "ProductOptionTranslation",
                column: "ProductOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOptionGroupTranslation");

            migrationBuilder.DropTable(
                name: "ProductOptionTranslation");

            migrationBuilder.DropTable(
                name: "ProductOption");

            migrationBuilder.DropTable(
                name: "ProductOptionGroup");

            migrationBuilder.AlterColumn<string>(
                name: "Culture",
                table: "ProductTranslations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
