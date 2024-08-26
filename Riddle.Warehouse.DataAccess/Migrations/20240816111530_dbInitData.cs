using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Riddle.Warehouse.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Furniture" }
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "ShipmentID", "Carrier", "ShipmentDate", "Status", "TrackingNumber" },
                values: new object[] { 1, "FedEx", new DateTime(2024, 8, 16, 13, 15, 29, 852, DateTimeKind.Local).AddTicks(8143), "Shipped", "TRACK123456" });

            migrationBuilder.InsertData(
                table: "StockLocations",
                columns: new[] { "LocationID", "Description", "LocationName" },
                values: new object[,]
                {
                    { 1, "Main warehouse for electronics", "Warehouse A" },
                    { 2, "Secondary warehouse for books", "Warehouse B" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierID", "Address", "City", "ContactName", "Country", "Email", "Phone", "PostalCode", "SupplierName" },
                values: new object[,]
                {
                    { 1, "123 Tech Road", "Techville", "John Doe", "USA", "contact@techsupplies.com", "123-456-7890", "12345", "Tech Supplies Inc." },
                    { 2, "456 Book St", "Readville", "Jane Smith", "USA", "info@booksandmore.com", "987-654-3210", "67890", "Books and More" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "DateAdded", "ProductName", "QuantityInStock", "ReorderLevel", "SKU", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 16, 13, 15, 29, 852, DateTimeKind.Local).AddTicks(7917), "Laptop", 50, 10, "LPT123", 999.99m },
                    { 2, 3, new DateTime(2024, 8, 16, 13, 15, 29, 852, DateTimeKind.Local).AddTicks(7930), "Desk Chair", 20, 5, "DCH456", 149.99m }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrders",
                columns: new[] { "PurchaseOrderID", "ExpectedDeliveryDate", "OrderDate", "Status", "SupplierID", "TotalAmount" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 16, 13, 15, 29, 852, DateTimeKind.Local).AddTicks(8033), "Pending", 1, 4999.95m },
                    { 2, null, new DateTime(2024, 8, 16, 13, 15, 29, 852, DateTimeKind.Local).AddTicks(8046), "Completed", 2, 299.98m }
                });

            migrationBuilder.InsertData(
                table: "ProductStocks",
                columns: new[] { "LocationID", "ProductID", "ProductStockID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0, 50 },
                    { 2, 2, 0, 20 }
                });

            migrationBuilder.InsertData(
                table: "PurchaseOrderDetails",
                columns: new[] { "PurchaseOrderDetailID", "ProductID", "PurchaseOrderID", "Quantity", "Total", "UnitPrice" },
                values: new object[] { 1, 1, 1, 5, 4999.95m, 999.99m });

            migrationBuilder.InsertData(
                table: "ShipmentDetails",
                columns: new[] { "ShipmentDetailID", "ProductID", "Quantity", "ShipmentID", "Total", "UnitPrice" },
                values: new object[] { 1, 1, 5, 1, 4999.95m, 999.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumns: new[] { "LocationID", "ProductID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductStocks",
                keyColumns: new[] { "LocationID", "ProductID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PurchaseOrderDetails",
                keyColumn: "PurchaseOrderDetailID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PurchaseOrders",
                keyColumn: "PurchaseOrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShipmentDetails",
                keyColumn: "ShipmentDetailID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PurchaseOrders",
                keyColumn: "PurchaseOrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shipments",
                keyColumn: "ShipmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockLocations",
                keyColumn: "LocationID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockLocations",
                keyColumn: "LocationID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "SupplierID",
                keyValue: 1);
        }
    }
}
