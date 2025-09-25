using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdustsShops",
                columns: table => new
                {
                    ShopID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdustsShops", x => new { x.ProductID, x.ShopID });
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsinStock = table.Column<bool>(type: "bit", nullable: false),
                    ProductShopProductID = table.Column<int>(type: "int", nullable: true),
                    ProductShopShopID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProdustsShops_ProductShopProductID_ProductShopShopID",
                        columns: x => new { x.ProductShopProductID, x.ProductShopShopID },
                        principalTable: "ProdustsShops",
                        principalColumns: new[] { "ProductID", "ShopID" });
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    ParkingArea = table.Column<int>(type: "int", nullable: false),
                    ProductShopProductID = table.Column<int>(type: "int", nullable: true),
                    ProductShopShopID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_ProdustsShops_ProductShopProductID_ProductShopShopID",
                        columns: x => new { x.ProductShopProductID, x.ProductShopShopID },
                        principalTable: "ProdustsShops",
                        principalColumns: new[] { "ProductID", "ShopID" });
                });

            migrationBuilder.CreateTable(
                name: "ProductShop",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ShopsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShop", x => new { x.ProductsId, x.ShopsId });
                    table.ForeignKey(
                        name: "FK_ProductShop_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShop_Shops_ShopsId",
                        column: x => x.ShopsId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    ShopID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meat" },
                    { 2, "Dairy products" },
                    { 3, "drink" },
                    { 4, "Snack" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The USA" },
                    { 2, "Canada" },
                    { 3, "Brasil" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cashier" },
                    { 2, "Mover" },
                    { 3, "Security" },
                    { 4, "Manager" },
                    { 5, "Director" }
                });

            migrationBuilder.InsertData(
                table: "ProdustsShops",
                columns: new[] { "ProductID", "ShopID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Miami" },
                    { 2, 1, "Las Vegas" },
                    { 3, 2, "Toronto" },
                    { 4, 1, "San Diego" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryID", "Discount", "IsinStock", "Name", "Price", "ProductShopProductID", "ProductShopShopID", "Quantity" },
                values: new object[,]
                {
                    { 1, 3, 10f, true, "Coca Cola", 3.10m, null, null, 100 },
                    { 2, 3, 10f, true, "Pepsi Cola", 3.10m, null, null, 100 },
                    { 3, 1, 10f, true, "Chicken", 4.10m, null, null, 100 },
                    { 4, 4, 30f, true, "Pringles", 2.50m, null, null, 100 },
                    { 5, 2, 30f, true, "Milk", 2.10m, null, null, 100 }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "CityID", "Name", "ParkingArea", "ProductShopProductID", "ProductShopShopID" },
                values: new object[,]
                {
                    { 1, "3200 NW 79th St, FL 33147", 1, "Walmart", 1000, null, null },
                    { 2, "4505 W Charleston Blvd, NV 89102", 2, "Walmart", 1000, null, null },
                    { 3, "3412 College Ave, CA 92115 (Walmart Supercenter)", 4, "Walmart", 1000, null, null }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "PositionID", "Salary", "ShopID", "Surname" },
                values: new object[,]
                {
                    { 1, "Michael@outlook.com", "Michael", "+1(213) 555-0198", 1, 15m, 1, "Thompson" },
                    { 2, "Martinez@outlook.com", "Sarah", "+1(305) 555-4477", 3, 18.50m, 1, "Martinez" },
                    { 3, "Lee@outlook.com", "Jonathan", "+1(415) 555-7321", 4, 38.50m, 1, "Lee" },
                    { 4, "Davis@outlook.com", "Angela", "+1(646) 555-1184", 1, 14.50m, 2, "Davis" },
                    { 5, "Brown@outlook.com", "Christopher", "+1(702) 555-9033", 2, 24m, 2, "Brown" },
                    { 6, "Brown@outlook.com", "Jessica", "+1(312) 555-2765", 3, 19m, 2, "Johnson" },
                    { 7, "Wilson@outlook.com", "Robert", "+1(617) 555-8449", 4, 38.50m, 2, "Wilson" },
                    { 8, "Garcia@outlook.com", "Emily", "+1(818) 555-6620", 1, 15.50m, 3, "Garcia" },
                    { 9, "Miller@outlook.com", "David", "+1(480) 555-3917", 2, 23m, 3, "Miller" },
                    { 10, "Rodriguez@outlook.com", "Ashley", "+1(917) 555-0456", 3, 17.75m, 3, "Rodriguez" },
                    { 11, "White@outlook.com", "Daniel", "+1(214) 555-7832", 1, 14.80m, 1, "White" },
                    { 12, "Lewis@outlook.com", "Megan", "+1(503) 555-1290", 4, 38.80m, 1, "Lewis" },
                    { 13, "Harris@outlook.com", "Benjamin", "+1(404) 555-6814", 3, 20m, 1, "Harris" },
                    { 14, "Clark@outlook.com", "Rachel", "+1(619) 555-2245", 1, 16m, 2, "Clark" },
                    { 15, "Taylor@outlook.com", "Anthony", "+1(713) 555-9301", 2, 25m, 2, "Taylor" },
                    { 16, "Allen@outlook.com", "Lauren", "+1(720) 555-5789", 3, 18m, 2, "Allen" },
                    { 17, "Young@outlook.com", "Brian", "+1(323) 555-4472", 4, 38.18m, 2, "Young" },
                    { 18, "King@outlook.com", "Stephanie", "+1(801) 555-3640", 1, 14.70m, 3, "King" },
                    { 19, "Scott@outlook.com", "Joshua", "+1(916) 555-7128", 3, 19m, 3, "Scott" },
                    { 20, "Baker@outlook.com", "Laura", "+1(954) 555-2083", 3, 22.50m, 3, "Baker" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductShopProductID_ProductShopShopID",
                table: "Products",
                columns: new[] { "ProductShopProductID", "ProductShopShopID" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductShop_ShopsId",
                table: "ProductShop",
                column: "ShopsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CityID",
                table: "Shops",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ProductShopProductID_ProductShopShopID",
                table: "Shops",
                columns: new[] { "ProductShopProductID", "ProductShopShopID" });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_PositionID",
                table: "Workers",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ShopID",
                table: "Workers",
                column: "ShopID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductShop");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "ProdustsShops");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
