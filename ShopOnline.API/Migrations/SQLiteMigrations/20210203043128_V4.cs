using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.API.Migrations.SQLiteMigrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUri",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PictureUri = table.Column<string>(type: "TEXT", nullable: true),
                    IsMainPicture = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductRefId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductRefId",
                        column: x => x.ProductRefId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 1, true, "assets/images/product/product-2.jpg", 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 28, false, "assets\\images\\product-single\\product-2.jpg", 8 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 29, false, "assets\\images\\product-single\\product-2.jpg", 9 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 31, false, "assets\\images\\product-single\\product-3.jpg", 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 32, false, "assets\\images\\product-single\\product-3.jpg", 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 33, false, "assets\\images\\product-single\\product-3.jpg", 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 34, false, "assets\\images\\product-single\\product-3.jpg", 4 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 35, false, "assets\\images\\product-single\\product-3.jpg", 5 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 36, false, "assets\\images\\product-single\\product-3.jpg", 6 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 37, false, "assets\\images\\product-single\\product-3.jpg", 7 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 38, false, "assets\\images\\product-single\\product-3.jpg", 8 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 27, false, "assets\\images\\product-single\\product-2.jpg", 7 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 39, false, "assets\\images\\product-single\\product-3.jpg", 9 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 41, false, "assets\\images\\product-single\\product-4.jpg", 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 42, false, "assets\\images\\product-single\\product-4.jpg", 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 43, false, "assets\\images\\product-single\\product-4.jpg", 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 44, false, "assets\\images\\product-single\\product-4.jpg", 4 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 45, false, "assets\\images\\product-single\\product-4.jpg", 5 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 46, false, "assets\\images\\product-single\\product-4.jpg", 6 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 47, false, "assets\\images\\product-single\\product-4.jpg", 7 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 48, false, "assets\\images\\product-single\\product-4.jpg", 8 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 49, false, "assets\\images\\product-single\\product-4.jpg", 9 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 50, false, "assets\\images\\product-single\\product-4.jpg", 10 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 40, false, "assets\\images\\product-single\\product-3.jpg", 10 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 26, false, "assets\\images\\product-single\\product-2.jpg", 6 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 30, false, "assets\\images\\product-single\\product-2.jpg", 10 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 24, false, "assets\\images\\product-single\\product-2.jpg", 4 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 2, true, "assets/images/product/product-2.jpg", 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 3, true, "assets/images/product/product-3.jpg", 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 4, true, "assets/images/product/product-4.jpg", 4 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 5, true, "assets/images/product/product-5.jpg", 5 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 6, true, "assets/images/product/product-6.jpg", 6 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 7, true, "assets/images/product/product-7.jpg", 7 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 8, true, "assets/images/product/product-8.jpg", 8 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 25, false, "assets\\images\\product-single\\product-2.jpg", 5 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 10, true, "assets/images/product/product-10.jpg", 10 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 11, false, "assets\\images\\product-single\\product-1.jpg", 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 12, false, "assets\\images\\product-single\\product-1.jpg", 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 9, true, "assets/images/product/product-9.jpg", 9 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 14, false, "assets\\images\\product-single\\product-1.jpg", 4 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 13, false, "assets\\images\\product-single\\product-1.jpg", 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 22, false, "assets\\images\\product-single\\product-2.jpg", 2 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 21, false, "assets\\images\\product-single\\product-2.jpg", 1 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 20, false, "assets\\images\\product-single\\product-1.jpg", 10 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 23, false, "assets\\images\\product-single\\product-2.jpg", 3 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 18, false, "assets\\images\\product-single\\product-1.jpg", 8 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 17, false, "assets\\images\\product-single\\product-1.jpg", 7 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 16, false, "assets\\images\\product-single\\product-1.jpg", 6 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 15, false, "assets\\images\\product-single\\product-1.jpg", 5 });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "IsMainPicture", "PictureUri", "ProductRefId" },
                values: new object[] { 19, false, "assets\\images\\product-single\\product-1.jpg", 9 });

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "SalePercent",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "SalePercent",
                value: 22m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 3,
                column: "SalePercent",
                value: 12m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 4,
                column: "SalePercent",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "SalePercent",
                value: 19m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 6,
                column: "SalePercent",
                value: 6m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 7,
                column: "SalePercent",
                value: 11m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 8,
                column: "SalePercent",
                value: 16m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 9,
                column: "SalePercent",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 10,
                column: "SalePercent",
                value: 19m);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductRefId",
                table: "ProductImages",
                column: "ProductRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "PictureUri",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 1,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 2,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 3,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 4,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 5,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 6,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 7,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 8,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 9,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 10,
                column: "SalePercent",
                value: 50m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "PictureUri",
                value: "assets/images/product/product-5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "PictureUri",
                value: "assets/images/product/product-4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "PictureUri",
                value: "assets/images/product/product-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "PictureUri",
                value: "assets/images/product/product-2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "PictureUri",
                value: "assets/images/product/product-3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "PictureUri",
                value: "assets/images/product/product-4.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "PictureUri",
                value: "assets/images/product/product-5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "PictureUri",
                value: "assets/images/product/product-6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "PictureUri",
                value: "assets/images/product/product-7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "PictureUri",
                value: "assets/images/product/product-8.jpg");
        }
    }
}
