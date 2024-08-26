using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Riddle.Bank.TestCases.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditScores",
                columns: table => new
                {
                    CreditScoreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    DateChecked = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditScores", x => x.CreditScoreID);
                    table.ForeignKey(
                        name: "FK_CreditScores_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CardType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardID);
                    table.ForeignKey(
                        name: "FK_Cards_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanPayments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanID = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrincipalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPayments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_LoanPayments_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "LoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchID", "Address", "BranchName", "City", "Country", "PostalCode" },
                values: new object[,]
                {
                    { 1, "100 Main St", "Downtown Branch", "Springfield", "USA", "62701" },
                    { 2, "200 North St", "Northside Branch", "Springfield", "USA", "62702" },
                    { 3, "300 South St", "Southside Branch", "Springfield", "USA", "62703" },
                    { 4, "400 East St", "Eastside Branch", "Springfield", "USA", "62704" },
                    { 5, "500 West St", "Westside Branch", "Springfield", "USA", "62705" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Address", "City", "Country", "DateOfBirth", "Email", "FirstName", "LastName", "Phone", "PostalCode" },
                values: new object[,]
                {
                    { 1, "123 Elm St", "Springfield", "USA", new DateTime(1985, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "Doe", "555-1234", "62701" },
                    { 2, "456 Oak St", "Springfield", "USA", new DateTime(1990, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "Smith", "555-5678", "62702" },
                    { 3, "789 Pine St", "Springfield", "USA", new DateTime(1978, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", "Michael", "Johnson", "555-8765", "62703" },
                    { 4, "101 Maple St", "Springfield", "USA", new DateTime(1982, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", "Emily", "Davis", "555-4321", "62704" },
                    { 5, "202 Birch St", "Springfield", "USA", new DateTime(1995, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.brown@example.com", "Robert", "Brown", "555-9876", "62705" },
                    { 6, "303 Cedar St", "Springfield", "USA", new DateTime(1988, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia.martinez@example.com", "Sophia", "Martinez", "555-6789", "62706" },
                    { 7, "404 Walnut St", "Springfield", "USA", new DateTime(1975, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "james.garcia@example.com", "James", "Garcia", "555-2345", "62707" },
                    { 8, "505 Spruce St", "Springfield", "USA", new DateTime(1992, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia.rodriguez@example.com", "Olivia", "Rodriguez", "555-3456", "62708" },
                    { 9, "606 Ash St", "Springfield", "USA", new DateTime(1980, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam.wilson@example.com", "Liam", "Wilson", "555-4567", "62709" },
                    { 10, "707 Redwood St", "Springfield", "USA", new DateTime(1994, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.lee@example.com", "Emma", "Lee", "555-5670", "62710" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountID", "AccountNumber", "AccountType", "Balance", "BranchID", "CustomerID", "DateOpened" },
                values: new object[,]
                {
                    { 1, "AC123456789", "Checking", 1500.75m, 1, 1, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "AC987654321", "Savings", 3200.50m, 2, 2, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "AC456789123", "Checking", 800.25m, 1, 3, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "AC321654987", "Business", 50000.00m, 3, 4, new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "AC654321789", "Savings", 1500.00m, 2, 5, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "AC111222333", "Checking", 1200.00m, 1, 6, new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "AC444555666", "Savings", 2000.00m, 2, 7, new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "AC777888999", "Business", 7500.00m, 3, 8, new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "AC999888777", "Checking", 3000.00m, 1, 9, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "AC555444333", "Savings", 1800.00m, 2, 10, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CreditScores",
                columns: new[] { "CreditScoreID", "CustomerID", "DateChecked", "Score" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 750 },
                    { 2, 2, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 680 },
                    { 3, 3, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 720 },
                    { 4, 4, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 690 },
                    { 5, 5, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 710 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "BranchID", "FirstName", "HireDate", "LastName", "Position", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "John", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "Branch Manager", 75000.00m },
                    { 2, 2, "Alice", new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "Teller", 35000.00m },
                    { 3, 3, "Charlie", new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wilson", "Loan Officer", 60000.00m },
                    { 4, 1, "Diana", new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taylor", "Customer Service", 40000.00m },
                    { 5, 2, "Edward", new DateTime(2020, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anderson", "Financial Advisor", 65000.00m },
                    { 6, 3, "Fiona", new DateTime(2018, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clark", "Loan Officer", 62000.00m },
                    { 7, 4, "George", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberts", "Teller", 36000.00m },
                    { 8, 5, "Hannah", new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lopez", "Branch Manager", 77000.00m },
                    { 9, 4, "Isaac", new DateTime(2022, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Walker", "Customer Service", 42000.00m },
                    { 10, 5, "Jasmine", new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Young", "Financial Advisor", 67000.00m }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "Amount", "CustomerID", "EndDate", "InterestRate", "LoanType", "StartDate" },
                values: new object[,]
                {
                    { 1, 5000.00m, 1, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.5m, "Personal", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 15000.00m, 2, new DateTime(2027, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.8m, "Auto", new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 200000.00m, 3, new DateTime(2041, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.2m, "Mortgage", new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 50000.00m, 4, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0m, "Business", new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 10000.00m, 5, new DateTime(2030, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5m, "Education", new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 7000.00m, 6, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0m, "Personal", new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 12000.00m, 7, new DateTime(2027, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0m, "Auto", new DateTime(2023, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 250000.00m, 8, new DateTime(2042, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, "Mortgage", new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 60000.00m, 9, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.2m, "Business", new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 12000.00m, 10, new DateTime(2029, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.7m, "Education", new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardID", "AccountID", "CVV", "CardNumber", "CardType", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, 1, "123", "1234 5678 9012 3456", "Visa", new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, "456", "9876 5432 1098 7654", "MasterCard", new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, "7890", "4567 8901 2345 6789", "American Express", new DateTime(2027, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, "234", "6789 0123 4567 8901", "Discover", new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, "567", "8901 2345 6789 0123", "Visa", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LoanPayments",
                columns: new[] { "PaymentID", "Amount", "InterestPaid", "LoanID", "PaymentDate", "PrincipalPaid" },
                values: new object[,]
                {
                    { 1, 500.00m, 22.50m, 1, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 477.50m },
                    { 2, 500.00m, 21.75m, 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 478.25m },
                    { 3, 600.00m, 40.00m, 2, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 560.00m },
                    { 4, 2000.00m, 750.00m, 3, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1250.00m },
                    { 5, 1000.00m, 300.00m, 4, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700.00m },
                    { 6, 300.00m, 87.50m, 5, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212.50m },
                    { 7, 700.00m, 35.00m, 6, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 665.00m },
                    { 8, 700.00m, 48.00m, 7, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 652.00m },
                    { 9, 2500.00m, 1125.00m, 8, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1375.00m },
                    { 10, 1500.00m, 930.00m, 9, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 570.00m }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionID", "AccountID", "Amount", "Description", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, 1, 500.00m, "Paycheck deposit", new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 2, 1, 100.00m, "ATM withdrawal", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal" },
                    { 3, 2, 200.00m, "Transfer to savings account", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" },
                    { 4, 3, 300.00m, "Deposit from freelance work", new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 5, 4, 2000.00m, "Business expense payment", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payment" },
                    { 6, 5, 150.00m, "Cash deposit", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 7, 6, 50.00m, "Grocery shopping", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Withdrawal" },
                    { 8, 7, 500.00m, "Transfer from another account", new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deposit" },
                    { 9, 8, 1000.00m, "Supplier payment", new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Payment" },
                    { 10, 9, 1000.00m, "Transfer to savings account", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Transfer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_BranchID",
                table: "Accounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerID",
                table: "Accounts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AccountID",
                table: "Cards",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CreditScores_CustomerID",
                table: "CreditScores",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_BranchID",
                table: "Employees",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayments_LoanID",
                table: "LoanPayments",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerID",
                table: "Loans",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountID",
                table: "Transactions",
                column: "AccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CreditScores");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LoanPayments");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
