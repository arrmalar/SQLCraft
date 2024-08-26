using Microsoft.EntityFrameworkCore;
using Riddle.Warehouse.Models;

namespace Riddle.Warehouse.TestCases.DataAccess.Data
{
    public class WarehouseTestCasesDbContext : DbContext
    {
        public WarehouseTestCasesDbContext(DbContextOptions<WarehouseTestCasesDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<StockLocation> StockLocations { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductStock>()
            .HasKey(ps => new { ps.ProductID, ps.LocationID });

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Electronics" },
                new Category { CategoryID = 2, CategoryName = "Books" },
                new Category { CategoryID = 3, CategoryName = "Furniture" },
                new Category { CategoryID = 4, CategoryName = "Clothing" },
                new Category { CategoryID = 5, CategoryName = "Toys" },
                new Category { CategoryID = 6, CategoryName = "Groceries" },
                new Category { CategoryID = 7, CategoryName = "Health & Beauty" },
                new Category { CategoryID = 8, CategoryName = "Sports & Outdoors" },
                new Category { CategoryID = 9, CategoryName = "Home Appliances" },
                new Category { CategoryID = 10, CategoryName = "Automotive" },
                new Category { CategoryID = 11, CategoryName = "Jewelry" },
                new Category { CategoryID = 12, CategoryName = "Pet Supplies" },
                new Category { CategoryID = 13, CategoryName = "Office Supplies" },
                new Category { CategoryID = 14, CategoryName = "Baby Products" },
                new Category { CategoryID = 15, CategoryName = "Garden & Outdoor" }
            );

            // Suppliers
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierID = 1, SupplierName = "Tech Supplies Inc.", ContactName = "John Doe", Address = "123 Tech Road", City = "Techville", PostalCode = "12345", Country = "USA", Phone = "123-456-7890", Email = "contact@techsupplies.com" },
                new Supplier { SupplierID = 2, SupplierName = "Books and More", ContactName = "Jane Smith", Address = "456 Book St", City = "Readville", PostalCode = "67890", Country = "USA", Phone = "987-654-3210", Email = "info@booksandmore.com" },
                new Supplier { SupplierID = 3, SupplierName = "Furnishings Depot", ContactName = "Mike Johnson", Address = "789 Furnish Ave", City = "Furniture City", PostalCode = "23456", Country = "USA", Phone = "555-123-4567", Email = "sales@furnishingsdepot.com" },
                new Supplier { SupplierID = 4, SupplierName = "Apparel World", ContactName = "Emily Davis", Address = "101 Fashion Blvd", City = "Style Town", PostalCode = "34567", Country = "USA", Phone = "555-234-5678", Email = "info@apparelworld.com" },
                new Supplier { SupplierID = 5, SupplierName = "Toy Kingdom", ContactName = "Kevin Brown", Address = "202 Play St", City = "Toyland", PostalCode = "45678", Country = "USA", Phone = "555-345-6789", Email = "contact@toykingdom.com" },
                new Supplier { SupplierID = 6, SupplierName = "Fresh Foods Ltd.", ContactName = "Sarah Green", Address = "303 Farm Road", City = "AgriCity", PostalCode = "56789", Country = "USA", Phone = "555-456-7890", Email = "info@freshfoods.com" },
                new Supplier { SupplierID = 7, SupplierName = "HealthCorp", ContactName = "Tom White", Address = "404 Health Ave", City = "Wellness", PostalCode = "67890", Country = "USA", Phone = "555-567-8901", Email = "support@healthcorp.com" },
                new Supplier { SupplierID = 8, SupplierName = "Sporting Goods Co.", ContactName = "Rachel Brown", Address = "505 Sports Blvd", City = "Athletica", PostalCode = "78901", Country = "USA", Phone = "555-678-9012", Email = "sales@sportinggoods.com" },
                new Supplier { SupplierID = 9, SupplierName = "HomeTech", ContactName = "Gary Gray", Address = "606 Home Lane", City = "Appliancetown", PostalCode = "89012", Country = "USA", Phone = "555-789-0123", Email = "contact@hometech.com" },
                new Supplier { SupplierID = 10, SupplierName = "Auto Parts Inc.", ContactName = "Linda Black", Address = "707 Car St", City = "Motor City", PostalCode = "90123", Country = "USA", Phone = "555-890-1234", Email = "sales@autoparts.com" },
                new Supplier { SupplierID = 11, SupplierName = "Glamour Jewels", ContactName = "Sophia Rose", Address = "808 Jewel Ave", City = "Bling City", PostalCode = "23457", Country = "USA", Phone = "555-789-4567", Email = "support@glamourjewels.com" },
                new Supplier { SupplierID = 12, SupplierName = "Pet Essentials", ContactName = "Brian Gold", Address = "909 Pet Lane", City = "Pawtown", PostalCode = "34568", Country = "USA", Phone = "555-890-5678", Email = "info@petessentials.com" },
                new Supplier { SupplierID = 13, SupplierName = "OfficePro", ContactName = "Nina Green", Address = "101 Office Blvd", City = "Worksville", PostalCode = "45679", Country = "USA", Phone = "555-901-6789", Email = "sales@officepro.com" },
                new Supplier { SupplierID = 14, SupplierName = "Baby Care Ltd.", ContactName = "Laura White", Address = "202 Baby St", City = "Nurture City", PostalCode = "56780", Country = "USA", Phone = "555-012-7890", Email = "support@babycare.com" },
                new Supplier { SupplierID = 15, SupplierName = "Green Thumb", ContactName = "Henry Black", Address = "303 Garden Ave", City = "Growtown", PostalCode = "67891", Country = "USA", Phone = "555-123-8901", Email = "info@greenthumb.com" }
            );

            // Stock Locations
            modelBuilder.Entity<StockLocation>().HasData(
                new StockLocation { LocationID = 1, LocationName = "Warehouse A", Description = "Main warehouse for electronics" },
                new StockLocation { LocationID = 2, LocationName = "Warehouse B", Description = "Secondary warehouse for books" },
                new StockLocation { LocationID = 3, LocationName = "Warehouse C", Description = "Warehouse for furniture" },
                new StockLocation { LocationID = 4, LocationName = "Warehouse D", Description = "Clothing warehouse" },
                new StockLocation { LocationID = 5, LocationName = "Warehouse E", Description = "Toys warehouse" },
                new StockLocation { LocationID = 6, LocationName = "Warehouse F", Description = "Groceries storage" },
                new StockLocation { LocationID = 7, LocationName = "Warehouse G", Description = "Health & Beauty products" },
                new StockLocation { LocationID = 8, LocationName = "Warehouse H", Description = "Sports equipment" },
                new StockLocation { LocationID = 9, LocationName = "Warehouse I", Description = "Home appliances" },
                new StockLocation { LocationID = 10, LocationName = "Warehouse J", Description = "Automotive parts storage" },
                new StockLocation { LocationID = 11, LocationName = "Warehouse K", Description = "Jewelry storage" },
                new StockLocation { LocationID = 12, LocationName = "Warehouse L", Description = "Pet supplies storage" },
                new StockLocation { LocationID = 13, LocationName = "Warehouse M", Description = "Office supplies storage" },
                new StockLocation { LocationID = 14, LocationName = "Warehouse N", Description = "Baby products storage" },
                new StockLocation { LocationID = 15, LocationName = "Warehouse O", Description = "Garden & outdoor storage" }
            );

            // Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Laptop", SKU = "LPT123", CategoryID = 1, QuantityInStock = 50, ReorderLevel = 10, UnitPrice = 999.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 2, ProductName = "Desk Chair", SKU = "DCH456", CategoryID = 3, QuantityInStock = 20, ReorderLevel = 5, UnitPrice = 149.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 3, ProductName = "Smartphone", SKU = "SPH789", CategoryID = 1, QuantityInStock = 200, ReorderLevel = 50, UnitPrice = 799.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 4, ProductName = "Bookshelf", SKU = "BSH123", CategoryID = 3, QuantityInStock = 30, ReorderLevel = 10, UnitPrice = 89.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 5, ProductName = "T-Shirt", SKU = "TSH456", CategoryID = 4, QuantityInStock = 100, ReorderLevel = 20, UnitPrice = 19.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 6, ProductName = "Action Figure", SKU = "AFG789", CategoryID = 5, QuantityInStock = 150, ReorderLevel = 30, UnitPrice = 29.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 7, ProductName = "Basketball", SKU = "BKB123", CategoryID = 8, QuantityInStock = 80, ReorderLevel = 15, UnitPrice = 24.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 8, ProductName = "Running Shoes", SKU = "RSH456", CategoryID = 8, QuantityInStock = 120, ReorderLevel = 25, UnitPrice = 59.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 9, ProductName = "Refrigerator", SKU = "RFG789", CategoryID = 9, QuantityInStock = 15, ReorderLevel = 3, UnitPrice = 499.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 10, ProductName = "Car Tire", SKU = "TIR123", CategoryID = 10, QuantityInStock = 300, ReorderLevel = 50, UnitPrice = 74.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 11, ProductName = "Tablet", SKU = "TBL001", CategoryID = 1, QuantityInStock = 120, ReorderLevel = 20, UnitPrice = 399.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 12, ProductName = "Sofa", SKU = "SFA234", CategoryID = 3, QuantityInStock = 25, ReorderLevel = 5, UnitPrice = 499.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 13, ProductName = "Dress", SKU = "DRS345", CategoryID = 4, QuantityInStock = 80, ReorderLevel = 15, UnitPrice = 39.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 14, ProductName = "Board Game", SKU = "BGM567", CategoryID = 5, QuantityInStock = 60, ReorderLevel = 10, UnitPrice = 29.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 15, ProductName = "Organic Milk", SKU = "GRY678", CategoryID = 6, QuantityInStock = 500, ReorderLevel = 100, UnitPrice = 3.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 16, ProductName = "Vitamin C", SKU = "HLT890", CategoryID = 7, QuantityInStock = 200, ReorderLevel = 50, UnitPrice = 9.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 17, ProductName = "Soccer Ball", SKU = "SCR345", CategoryID = 8, QuantityInStock = 90, ReorderLevel = 15, UnitPrice = 19.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 18, ProductName = "Washing Machine", SKU = "WMC123", CategoryID = 9, QuantityInStock = 10, ReorderLevel = 2, UnitPrice = 649.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 19, ProductName = "Car Battery", SKU = "CBT456", CategoryID = 10, QuantityInStock = 70, ReorderLevel = 10, UnitPrice = 99.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 20, ProductName = "Gaming Console", SKU = "GMC678", CategoryID = 1, QuantityInStock = 50, ReorderLevel = 10, UnitPrice = 399.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 21, ProductName = "Diamond Necklace", SKU = "JWL123", CategoryID = 11, QuantityInStock = 25, ReorderLevel = 5, UnitPrice = 2999.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 22, ProductName = "Dog Food", SKU = "PET456", CategoryID = 12, QuantityInStock = 300, ReorderLevel = 50, UnitPrice = 29.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 23, ProductName = "Office Chair", SKU = "OFC789", CategoryID = 13, QuantityInStock = 100, ReorderLevel = 20, UnitPrice = 149.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 24, ProductName = "Baby Stroller", SKU = "BBY123", CategoryID = 14, QuantityInStock = 50, ReorderLevel = 10, UnitPrice = 299.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 25, ProductName = "Garden Shovel", SKU = "GRD456", CategoryID = 15, QuantityInStock = 200, ReorderLevel = 30, UnitPrice = 19.99m, DateAdded = DateTime.Now }
            );

            // ProductStock
            modelBuilder.Entity<ProductStock>().HasData(
                new ProductStock { ProductID = 1, LocationID = 1, Quantity = 50 },
                new ProductStock { ProductID = 2, LocationID = 3, Quantity = 20 },
                new ProductStock { ProductID = 3, LocationID = 1, Quantity = 200 },
                new ProductStock { ProductID = 4, LocationID = 3, Quantity = 30 },
                new ProductStock { ProductID = 5, LocationID = 4, Quantity = 100 },
                new ProductStock { ProductID = 6, LocationID = 5, Quantity = 150 },
                new ProductStock { ProductID = 7, LocationID = 8, Quantity = 80 },
                new ProductStock { ProductID = 8, LocationID = 8, Quantity = 120 },
                new ProductStock { ProductID = 9, LocationID = 9, Quantity = 15 },
                new ProductStock { ProductID = 10, LocationID = 10, Quantity = 300 },
                new ProductStock { ProductID = 11, LocationID = 1, Quantity = 120 },
                new ProductStock { ProductID = 12, LocationID = 3, Quantity = 25 },
                new ProductStock { ProductID = 13, LocationID = 4, Quantity = 80 },
                new ProductStock { ProductID = 14, LocationID = 5, Quantity = 60 },
                new ProductStock { ProductID = 15, LocationID = 6, Quantity = 500 },
                new ProductStock { ProductID = 16, LocationID = 7, Quantity = 200 },
                new ProductStock { ProductID = 17, LocationID = 8, Quantity = 90 },
                new ProductStock { ProductID = 18, LocationID = 9, Quantity = 10 },
                new ProductStock { ProductID = 19, LocationID = 10, Quantity = 70 },
                new ProductStock { ProductID = 20, LocationID = 1, Quantity = 50 },
                new ProductStock { ProductID = 21, LocationID = 11, Quantity = 25 },
                new ProductStock { ProductID = 22, LocationID = 12, Quantity = 300 },
                new ProductStock { ProductID = 23, LocationID = 13, Quantity = 100 },
                new ProductStock { ProductID = 24, LocationID = 14, Quantity = 50 },
                new ProductStock { ProductID = 25, LocationID = 15, Quantity = 200 }
            );

            // PurchaseOrders
            modelBuilder.Entity<PurchaseOrder>().HasData(
                new PurchaseOrder { PurchaseOrderID = 1, SupplierID = 1, OrderDate = DateTime.Now, TotalAmount = 4999.95m, Status = "Pending" },
                new PurchaseOrder { PurchaseOrderID = 2, SupplierID = 2, OrderDate = DateTime.Now, TotalAmount = 299.98m, Status = "Completed" },
                new PurchaseOrder { PurchaseOrderID = 3, SupplierID = 3, OrderDate = DateTime.Now.AddDays(-2), TotalAmount = 5999.99m, Status = "Pending" },
                new PurchaseOrder { PurchaseOrderID = 4, SupplierID = 4, OrderDate = DateTime.Now.AddDays(-5), TotalAmount = 1199.85m, Status = "Shipped" },
                new PurchaseOrder { PurchaseOrderID = 5, SupplierID = 5, OrderDate = DateTime.Now.AddDays(-10), TotalAmount = 749.75m, Status = "Cancelled" },
                new PurchaseOrder { PurchaseOrderID = 6, SupplierID = 6, OrderDate = DateTime.Now.AddDays(-15), TotalAmount = 2999.40m, Status = "Completed" },
                new PurchaseOrder { PurchaseOrderID = 7, SupplierID = 7, OrderDate = DateTime.Now.AddDays(-20), TotalAmount = 1999.80m, Status = "Pending" },
                new PurchaseOrder { PurchaseOrderID = 8, SupplierID = 8, OrderDate = DateTime.Now.AddDays(-25), TotalAmount = 1499.50m, Status = "Completed" },
                new PurchaseOrder { PurchaseOrderID = 9, SupplierID = 9, OrderDate = DateTime.Now.AddDays(-30), TotalAmount = 7499.85m, Status = "Pending" },
                new PurchaseOrder { PurchaseOrderID = 10, SupplierID = 10, OrderDate = DateTime.Now.AddDays(-35), TotalAmount = 3749.50m, Status = "Shipped" },
                new PurchaseOrder { PurchaseOrderID = 11, SupplierID = 11, OrderDate = DateTime.Now.AddDays(-40), TotalAmount = 29999.90m, Status = "Pending" },
                new PurchaseOrder { PurchaseOrderID = 12, SupplierID = 12, OrderDate = DateTime.Now.AddDays(-45), TotalAmount = 899.70m, Status = "Shipped" },
                new PurchaseOrder { PurchaseOrderID = 13, SupplierID = 13, OrderDate = DateTime.Now.AddDays(-50), TotalAmount = 14999.00m, Status = "Completed" },
                new PurchaseOrder { PurchaseOrderID = 14, SupplierID = 14, OrderDate = DateTime.Now.AddDays(-55), TotalAmount = 14999.50m, Status = "Cancelled" },
                new PurchaseOrder { PurchaseOrderID = 15, SupplierID = 15, OrderDate = DateTime.Now.AddDays(-60), TotalAmount = 3999.80m, Status = "Pending" }
            );

            // PurchaseOrderDetails
            modelBuilder.Entity<PurchaseOrderDetail>().HasData(
                new PurchaseOrderDetail { PurchaseOrderDetailID = 1, PurchaseOrderID = 1, ProductID = 1, Quantity = 5, UnitPrice = 999.99m, Total = 4999.95m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 2, PurchaseOrderID = 2, ProductID = 5, Quantity = 15, UnitPrice = 19.99m, Total = 299.85m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 3, PurchaseOrderID = 3, ProductID = 12, Quantity = 10, UnitPrice = 599.99m, Total = 5999.90m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 4, PurchaseOrderID = 4, ProductID = 13, Quantity = 30, UnitPrice = 39.99m, Total = 1199.70m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 5, PurchaseOrderID = 5, ProductID = 6, Quantity = 25, UnitPrice = 29.99m, Total = 749.75m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 6, PurchaseOrderID = 6, ProductID = 15, Quantity = 750, UnitPrice = 3.99m, Total = 2992.50m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 7, PurchaseOrderID = 7, ProductID = 16, Quantity = 200, UnitPrice = 9.99m, Total = 1998.00m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 8, PurchaseOrderID = 8, ProductID = 14, Quantity = 50, UnitPrice = 29.99m, Total = 1499.50m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 9, PurchaseOrderID = 9, ProductID = 18, Quantity = 15, UnitPrice = 499.99m, Total = 7499.85m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 10, PurchaseOrderID = 10, ProductID = 19, Quantity = 50, UnitPrice = 74.99m, Total = 3749.50m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 11, PurchaseOrderID = 11, ProductID = 21, Quantity = 10, UnitPrice = 2999.99m, Total = 29999.90m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 12, PurchaseOrderID = 12, ProductID = 22, Quantity = 30, UnitPrice = 29.99m, Total = 899.70m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 13, PurchaseOrderID = 13, ProductID = 23, Quantity = 100, UnitPrice = 149.99m, Total = 14999.00m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 14, PurchaseOrderID = 14, ProductID = 24, Quantity = 50, UnitPrice = 299.99m, Total = 14999.50m },
                new PurchaseOrderDetail { PurchaseOrderDetailID = 15, PurchaseOrderID = 15, ProductID = 25, Quantity = 200, UnitPrice = 19.99m, Total = 3999.80m }
            );

            // Shipments
            modelBuilder.Entity<Shipment>().HasData(
                new Shipment { ShipmentID = 1, ShipmentDate = DateTime.Now.AddDays(-1), Carrier = "FedEx", TrackingNumber = "TRACK123456", Status = "Shipped" },
                new Shipment { ShipmentID = 2, ShipmentDate = DateTime.Now.AddDays(-2), Carrier = "UPS", TrackingNumber = "TRACK654321", Status = "In Transit" },
                new Shipment { ShipmentID = 3, ShipmentDate = DateTime.Now.AddDays(-3), Carrier = "DHL", TrackingNumber = "TRACK987654", Status = "Delivered" },
                new Shipment { ShipmentID = 4, ShipmentDate = DateTime.Now.AddDays(-4), Carrier = "FedEx", TrackingNumber = "TRACK456789", Status = "Pending" },
                new Shipment { ShipmentID = 5, ShipmentDate = DateTime.Now.AddDays(-5), Carrier = "UPS", TrackingNumber = "TRACK789123", Status = "Cancelled" },
                new Shipment { ShipmentID = 6, ShipmentDate = DateTime.Now.AddDays(-6), Carrier = "DHL", TrackingNumber = "TRACK098765", Status = "In Transit" },
                new Shipment { ShipmentID = 7, ShipmentDate = DateTime.Now.AddDays(-7), Carrier = "FedEx", TrackingNumber = "TRACK543210", Status = "Delivered" },
                new Shipment { ShipmentID = 8, ShipmentDate = DateTime.Now.AddDays(-8), Carrier = "UPS", TrackingNumber = "TRACK876543", Status = "Shipped" },
                new Shipment { ShipmentID = 9, ShipmentDate = DateTime.Now.AddDays(-9), Carrier = "DHL", TrackingNumber = "TRACK345678", Status = "Pending" },
                new Shipment { ShipmentID = 10, ShipmentDate = DateTime.Now.AddDays(-10), Carrier = "FedEx", TrackingNumber = "TRACK123789", Status = "Cancelled" }
            );

            // ShipmentDetails
            modelBuilder.Entity<ShipmentDetail>().HasData(
                new ShipmentDetail { ShipmentDetailID = 1, ShipmentID = 1, ProductID = 1, Quantity = 5, UnitPrice = 999.99m, Total = 4999.95m },
                new ShipmentDetail { ShipmentDetailID = 2, ShipmentID = 2, ProductID = 3, Quantity = 20, UnitPrice = 799.99m, Total = 15999.80m },
                new ShipmentDetail { ShipmentDetailID = 3, ShipmentID = 3, ProductID = 4, Quantity = 10, UnitPrice = 89.99m, Total = 899.90m },
                new ShipmentDetail { ShipmentDetailID = 4, ShipmentID = 4, ProductID = 7, Quantity = 15, UnitPrice = 24.99m, Total = 374.85m },
                new ShipmentDetail { ShipmentDetailID = 5, ShipmentID = 5, ProductID = 10, Quantity = 25, UnitPrice = 74.99m, Total = 1874.75m },
                new ShipmentDetail { ShipmentDetailID = 6, ShipmentID = 6, ProductID = 11, Quantity = 30, UnitPrice = 399.99m, Total = 11999.70m },
                new ShipmentDetail { ShipmentDetailID = 7, ShipmentID = 7, ProductID = 15, Quantity = 300, UnitPrice = 3.99m, Total = 1197.00m },
                new ShipmentDetail { ShipmentDetailID = 8, ShipmentID = 8, ProductID = 21, Quantity = 10, UnitPrice = 2999.99m, Total = 29999.90m },
                new ShipmentDetail { ShipmentDetailID = 9, ShipmentID = 9, ProductID = 25, Quantity = 50, UnitPrice = 19.99m, Total = 999.50m }
            );

        }
    }
}
