using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Riddle.Warehouse.TestCases.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Carrier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentID);
                });

            migrationBuilder.CreateTable(
                name: "StockLocations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocations", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    ReorderLevel = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpectedDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStocks",
                columns: table => new
                {
                    ProductStockID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStocks", x => new { x.ProductID, x.LocationID });
                    table.ForeignKey(
                        name: "FK_ProductStocks_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStocks_StockLocations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "StockLocations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentDetails",
                columns: table => new
                {
                    ShipmentDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentDetails", x => x.ShipmentDetailID);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentDetails_Shipments_ShipmentID",
                        column: x => x.ShipmentID,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetails",
                columns: table => new
                {
                    PurchaseOrderDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetails", x => x.PurchaseOrderDetailID);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetails_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderID",
                        column: x => x.PurchaseOrderID,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Furniture" },
                    { 4, "Clothing" },
                    { 5, "Toys" },
                    { 6, "Groceries" },
                    { 7, "Health & Beauty" },
                    { 8, "Sports & Outdoors" },
                    { 9, "Home Appliances" },
                    { 10, "Automotive" },
                    { 11, "Jewelry" },
                    { 12, "Pet Supplies" },
                    { 13, "Office Supplies" },
                    { 14, "Baby Products" },
                    { 15, "Garden & Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "ShipmentID", "Carrier", "ShipmentDate", "Status", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, "FedEx", new DateTime(2024, 8, 18, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2970), "Shipped", "TRACK123456" },
                    { 2, "UPS", new DateTime(2024, 8, 17, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2977), "In Transit", "TRACK654321" },
                    { 3, "DHL", new DateTime(2024, 8, 16, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2984), "Delivered", "TRACK987654" },
                    { 4, "FedEx", new DateTime(2024, 8, 15, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2988), "Pending", "TRACK456789" },
                    { 5, "UPS", new DateTime(2024, 8, 14, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2993), "Cancelled", "TRACK789123" },
                    { 6, "DHL", new DateTime(2024, 8, 13, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2998), "In Transit", "TRACK098765" },
                    { 7, "FedEx", new DateTime(2024, 8, 12, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(3005), "Delivered", "TRACK543210" },
                    { 8, "UPS", new DateTime(2024, 8, 11, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(3010), "Shipped", "TRACK876543" },
                    { 9, "DHL", new DateTime(2024, 8, 10, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(3015), "Pending", "TRACK345678" },
                    { 10, "FedEx", new DateTime(2024, 8, 9, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(3020), "Cancelled", "TRACK123789" }
                });

            migrationBuilder.InsertData(
                table: "StockLocations",
                columns: new[] { "LocationID", "Description", "LocationName" },
                values: new object[,]
                {
                    { 1, "Main warehouse for electronics", "Warehouse A" },
                    { 2, "Secondary warehouse for books", "Warehouse B" },
                    { 3, "Warehouse for furniture", "Warehouse C" },
                    { 4, "Clothing warehouse", "Warehouse D" },
                    { 5, "Toys warehouse", "Warehouse E" },
                    { 6, "Groceries storage", "Warehouse F" },
                    { 7, "Health & Beauty products", "Warehouse G" },
                    { 8, "Sports equipment", "Warehouse H" },
                    { 9, "Home appliances", "Warehouse I" },
                    { 10, "Automotive parts storage", "Warehouse J" },
                    { 11, "Jewelry storage", "Warehouse K" },
                    { 12, "Pet supplies storage", "Warehouse L" },
                    { 13, "Office supplies storage", "Warehouse M" },
                    { 14, "Baby products storage", "Warehouse N" },
                    { 15, "Garden & outdoor storage", "Warehouse O" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "Address", "City", "ContactName", "Country", "Email", "Phone", "PostalCode", "SupplierName" },
                values: new object[,]
                {
                    { 1, "123 Tech Road", "Techville", "John Doe", "USA", "contact@techsupplies.com", "123-456-7890", "12345", "Tech Supplies Inc." },
                    { 2, "456 Book St", "Readville", "Jane Smith", "USA", "info@booksandmore.com", "987-654-3210", "67890", "Books and More" },
                    { 3, "789 Furnish Ave", "Furniture City", "Mike Johnson", "USA", "sales@furnishingsdepot.com", "555-123-4567", "23456", "Furnishings Depot" },
                    { 4, "101 Fashion Blvd", "Style Town", "Emily Davis", "USA", "info@apparelworld.com", "555-234-5678", "34567", "Apparel World" },
                    { 5, "202 Play St", "Toyland", "Kevin Brown", "USA", "contact@toykingdom.com", "555-345-6789", "45678", "Toy Kingdom" },
                    { 6, "303 Farm Road", "AgriCity", "Sarah Green", "USA", "info@freshfoods.com", "555-456-7890", "56789", "Fresh Foods Ltd." },
                    { 7, "404 Health Ave", "Wellness", "Tom White", "USA", "support@healthcorp.com", "555-567-8901", "67890", "HealthCorp" },
                    { 8, "505 Sports Blvd", "Athletica", "Rachel Brown", "USA", "sales@sportinggoods.com", "555-678-9012", "78901", "Sporting Goods Co." },
                    { 9, "606 Home Lane", "Appliancetown", "Gary Gray", "USA", "contact@hometech.com", "555-789-0123", "89012", "HomeTech" },
                    { 10, "707 Car St", "Motor City", "Linda Black", "USA", "sales@autoparts.com", "555-890-1234", "90123", "Auto Parts Inc." },
                    { 11, "808 Jewel Ave", "Bling City", "Sophia Rose", "USA", "support@glamourjewels.com", "555-789-4567", "23457", "Glamour Jewels" },
                    { 12, "909 Pet Lane", "Pawtown", "Brian Gold", "USA", "info@petessentials.com", "555-890-5678", "34568", "Pet Essentials" },
                    { 13, "101 Office Blvd", "Worksville", "Nina Green", "USA", "sales@officepro.com", "555-901-6789", "45679", "OfficePro" },
                    { 14, "202 Baby St", "Nurture City", "Laura White", "USA", "support@babycare.com", "555-012-7890", "56780", "Baby Care Ltd." },
                    { 15, "303 Garden Ave", "Growtown", "Henry Black", "USA", "info@greenthumb.com", "555-123-8901", "67891", "Green Thumb" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "DateAdded", "ProductName", "QuantityInStock", "ReorderLevel", "SKU", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2468), "Laptop", 50, 10, "LPT123", 999.99m },
                    { 2, 3, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2476), "Desk Chair", 20, 5, "DCH456", 149.99m },
                    { 3, 1, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2483), "Smartphone", 200, 50, "SPH789", 799.99m },
                    { 4, 3, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2490), "Bookshelf", 30, 10, "BSH123", 89.99m },
                    { 5, 4, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2495), "T-Shirt", 100, 20, "TSH456", 19.99m },
                    { 6, 5, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2501), "Action Figure", 150, 30, "AFG789", 29.99m },
                    { 7, 8, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2506), "Basketball", 80, 15, "BKB123", 24.99m },
                    { 8, 8, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2512), "Running Shoes", 120, 25, "RSH456", 59.99m },
                    { 9, 9, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2518), "Refrigerator", 15, 3, "RFG789", 499.99m },
                    { 10, 10, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2523), "Car Tire", 300, 50, "TIR123", 74.99m },
                    { 11, 1, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2530), "Tablet", 120, 20, "TBL001", 399.99m },
                    { 12, 3, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2535), "Sofa", 25, 5, "SFA234", 499.99m },
                    { 13, 4, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2540), "Dress", 80, 15, "DRS345", 39.99m },
                    { 14, 5, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2546), "Board Game", 60, 10, "BGM567", 29.99m },
                    { 15, 6, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2551), "Organic Milk", 500, 100, "GRY678", 3.99m },
                    { 16, 7, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2557), "Vitamin C", 200, 50, "HLT890", 9.99m },
                    { 17, 8, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2562), "Soccer Ball", 90, 15, "SCR345", 19.99m },
                    { 18, 9, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2567), "Washing Machine", 10, 2, "WMC123", 649.99m },
                    { 19, 10, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2573), "Car Battery", 70, 10, "CBT456", 99.99m },
                    { 20, 1, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2579), "Gaming Console", 50, 10, "GMC678", 399.99m },
                    { 21, 11, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2585), "Diamond Necklace", 25, 5, "JWL123", 2999.99m },
                    { 22, 12, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2590), "Dog Food", 300, 50, "PET456", 29.99m },
                    { 23, 13, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2595), "Office Chair", 100, 20, "OFC789", 149.99m },
                    { 24, 14, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2601), "Baby Stroller", 50, 10, "BBY123", 299.99m },
                    { 25, 15, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2607), "Garden Shovel", 200, 30, "GRD456", 19.99m }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrders",
                columns: new[] { "PurchaseOrderID", "ExpectedDeliveryDate", "OrderDate", "Status", "SupplierID", "TotalAmount" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2739), "Pending", 1, 4999.95m },
                    { 2, null, new DateTime(2024, 8, 19, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2746), "Completed", 2, 299.98m },
                    { 3, null, new DateTime(2024, 8, 17, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2751), "Pending", 3, 5999.99m },
                    { 4, null, new DateTime(2024, 8, 14, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2758), "Shipped", 4, 1199.85m },
                    { 5, null, new DateTime(2024, 8, 9, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2802), "Cancelled", 5, 749.75m },
                    { 6, null, new DateTime(2024, 8, 4, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2807), "Completed", 6, 2999.40m },
                    { 7, null, new DateTime(2024, 7, 30, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2813), "Pending", 7, 1999.80m },
                    { 8, null, new DateTime(2024, 7, 25, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2818), "Completed", 8, 1499.50m },
                    { 9, null, new DateTime(2024, 7, 20, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2824), "Pending", 9, 7499.85m },
                    { 10, null, new DateTime(2024, 7, 15, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2830), "Shipped", 10, 3749.50m },
                    { 11, null, new DateTime(2024, 7, 10, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2835), "Pending", 11, 29999.90m },
                    { 12, null, new DateTime(2024, 7, 5, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2840), "Shipped", 12, 899.70m },
                    { 13, null, new DateTime(2024, 6, 30, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2846), "Completed", 13, 14999.00m },
                    { 14, null, new DateTime(2024, 6, 25, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2852), "Cancelled", 14, 14999.50m },
                    { 15, null, new DateTime(2024, 6, 20, 13, 13, 28, 937, DateTimeKind.Local).AddTicks(2857), "Pending", 15, 3999.80m }
                });

            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "LocationID", "ProductID", "ProductStockID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0, 50 },
                    { 3, 2, 0, 20 },
                    { 1, 3, 0, 200 },
                    { 3, 4, 0, 30 },
                    { 4, 5, 0, 100 },
                    { 5, 6, 0, 150 },
                    { 8, 7, 0, 80 },
                    { 8, 8, 0, 120 },
                    { 9, 9, 0, 15 },
                    { 10, 10, 0, 300 },
                    { 1, 11, 0, 120 },
                    { 3, 12, 0, 25 },
                    { 4, 13, 0, 80 },
                    { 5, 14, 0, 60 },
                    { 6, 15, 0, 500 },
                    { 7, 16, 0, 200 },
                    { 8, 17, 0, 90 },
                    { 9, 18, 0, 10 },
                    { 10, 19, 0, 70 },
                    { 1, 20, 0, 50 },
                    { 11, 21, 0, 25 },
                    { 12, 22, 0, 300 },
                    { 13, 23, 0, 100 },
                    { 14, 24, 0, 50 },
                    { 15, 25, 0, 200 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderDetails",
                columns: new[] { "PurchaseOrderDetailID", "ProductID", "PurchaseOrderID", "Quantity", "Total", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 5, 4999.95m, 999.99m },
                    { 2, 5, 2, 15, 299.85m, 19.99m },
                    { 3, 12, 3, 10, 5999.90m, 599.99m },
                    { 4, 13, 4, 30, 1199.70m, 39.99m },
                    { 5, 6, 5, 25, 749.75m, 29.99m },
                    { 6, 15, 6, 750, 2992.50m, 3.99m },
                    { 7, 16, 7, 200, 1998.00m, 9.99m },
                    { 8, 14, 8, 50, 1499.50m, 29.99m },
                    { 9, 18, 9, 15, 7499.85m, 499.99m },
                    { 10, 19, 10, 50, 3749.50m, 74.99m },
                    { 11, 21, 11, 10, 29999.90m, 2999.99m },
                    { 12, 22, 12, 30, 899.70m, 29.99m },
                    { 13, 23, 13, 100, 14999.00m, 149.99m },
                    { 14, 24, 14, 50, 14999.50m, 299.99m },
                    { 15, 25, 15, 200, 3999.80m, 19.99m }
                });

            migrationBuilder.InsertData(
                table: "ShipmentDetails",
                columns: new[] { "ShipmentDetailID", "ProductID", "Quantity", "ShipmentID", "Total", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 5, 1, 4999.95m, 999.99m },
                    { 2, 3, 20, 2, 15999.80m, 799.99m },
                    { 3, 4, 10, 3, 899.90m, 89.99m },
                    { 4, 7, 15, 4, 374.85m, 24.99m },
                    { 5, 10, 25, 5, 1874.75m, 74.99m },
                    { 6, 11, 30, 6, 11999.70m, 399.99m },
                    { 7, 15, 300, 7, 1197.00m, 3.99m },
                    { 8, 21, 10, 8, 29999.90m, 2999.99m },
                    { 9, 25, 50, 9, 999.50m, 19.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStocks_LocationID",
                table: "ProductStocks",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_ProductID",
                table: "PurchaseOrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetails_PurchaseOrderID",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierID",
                table: "PurchaseOrders",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_ProductID",
                table: "ShipmentDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDetails_ShipmentID",
                table: "ShipmentDetails",
                column: "ShipmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStocks");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "ShipmentDetails");

            migrationBuilder.DropTable(
                name: "StockLocations");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
