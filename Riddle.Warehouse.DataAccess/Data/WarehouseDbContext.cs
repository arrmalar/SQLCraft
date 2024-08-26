using Microsoft.EntityFrameworkCore;
using Riddle.Warehouse.Models;

namespace Riddle.Warehouse.DataAccess.Data
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) 
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

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Electronics" },
                new Category { CategoryID = 2, CategoryName = "Books" },
                new Category { CategoryID = 3, CategoryName = "Furniture" }
            );

            // Dodanie danych do tabeli Supplier
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierID = 1, SupplierName = "Tech Supplies Inc.", ContactName = "John Doe", Address = "123 Tech Road", City = "Techville", PostalCode = "12345", Country = "USA", Phone = "123-456-7890", Email = "contact@techsupplies.com" },
                new Supplier { SupplierID = 2, SupplierName = "Books and More", ContactName = "Jane Smith", Address = "456 Book St", City = "Readville", PostalCode = "67890", Country = "USA", Phone = "987-654-3210", Email = "info@booksandmore.com" }
            );

            // Dodanie danych do tabeli StockLocation
            modelBuilder.Entity<StockLocation>().HasData(
                new StockLocation { LocationID = 1, LocationName = "Warehouse A", Description = "Main warehouse for electronics" },
                new StockLocation { LocationID = 2, LocationName = "Warehouse B", Description = "Secondary warehouse for books" }
            );

            // Dodanie danych do tabeli Product
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Laptop", SKU = "LPT123", CategoryID = 1, QuantityInStock = 50, ReorderLevel = 10, UnitPrice = 999.99m, DateAdded = DateTime.Now },
                new Product { ProductID = 2, ProductName = "Desk Chair", SKU = "DCH456", CategoryID = 3, QuantityInStock = 20, ReorderLevel = 5, UnitPrice = 149.99m, DateAdded = DateTime.Now }
            );

            // Dodanie danych do tabeli ProductStock
            modelBuilder.Entity<ProductStock>().HasData(
                new ProductStock { ProductID = 1, LocationID = 1, Quantity = 50 },
                new ProductStock { ProductID = 2, LocationID = 2, Quantity = 20 }
            );

            // Dodanie danych do tabeli PurchaseOrder
            modelBuilder.Entity<PurchaseOrder>().HasData(
                new PurchaseOrder { PurchaseOrderID = 1, SupplierID = 1, OrderDate = DateTime.Now, TotalAmount = 4999.95m, Status = "Pending" },
                new PurchaseOrder { PurchaseOrderID = 2, SupplierID = 2, OrderDate = DateTime.Now, TotalAmount = 299.98m, Status = "Completed" }
            );

            // Dodanie danych do tabeli PurchaseOrderDetail
            modelBuilder.Entity<PurchaseOrderDetail>().HasData(
                new PurchaseOrderDetail { PurchaseOrderDetailID = 1, PurchaseOrderID = 1, ProductID = 1, Quantity = 5, UnitPrice = 999.99m, Total = 4999.95m }
            );

            // Dodanie danych do tabeli Shipment
            modelBuilder.Entity<Shipment>().HasData(
                new Shipment { ShipmentID = 1, ShipmentDate = DateTime.Now, Carrier = "FedEx", TrackingNumber = "TRACK123456", Status = "Shipped" }
            );

            // Dodanie danych do tabeli ShipmentDetail
            modelBuilder.Entity<ShipmentDetail>().HasData(
                new ShipmentDetail { ShipmentDetailID = 1, ShipmentID = 1, ProductID = 1, Quantity = 5, UnitPrice = 999.99m, Total = 4999.95m }
            );
        }
    }
}
