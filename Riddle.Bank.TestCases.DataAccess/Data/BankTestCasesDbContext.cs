using Microsoft.EntityFrameworkCore;
using Riddle.Bank.Models;
using System;

namespace Riddle.Warehouse.TestCases.DataAccess.Data
{
    public class BankTestCasesDbContext : DbContext
    {
        public BankTestCasesDbContext(DbContextOptions<BankTestCasesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanPayment> LoanPayments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CreditScore> CreditScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1985, 6, 15), Email = "john.doe@example.com", Phone = "555-1234", Address = "123 Elm St", City = "Springfield", PostalCode = "62701", Country = "USA" },
                new Customer { CustomerID = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1990, 8, 22), Email = "jane.smith@example.com", Phone = "555-5678", Address = "456 Oak St", City = "Springfield", PostalCode = "62702", Country = "USA" },
                new Customer { CustomerID = 3, FirstName = "Michael", LastName = "Johnson", DateOfBirth = new DateTime(1978, 12, 5), Email = "michael.johnson@example.com", Phone = "555-8765", Address = "789 Pine St", City = "Springfield", PostalCode = "62703", Country = "USA" },
                new Customer { CustomerID = 4, FirstName = "Emily", LastName = "Davis", DateOfBirth = new DateTime(1982, 11, 30), Email = "emily.davis@example.com", Phone = "555-4321", Address = "101 Maple St", City = "Springfield", PostalCode = "62704", Country = "USA" },
                new Customer { CustomerID = 5, FirstName = "Robert", LastName = "Brown", DateOfBirth = new DateTime(1995, 4, 18), Email = "robert.brown@example.com", Phone = "555-9876", Address = "202 Birch St", City = "Springfield", PostalCode = "62705", Country = "USA" },
                new Customer { CustomerID = 6, FirstName = "Sophia", LastName = "Martinez", DateOfBirth = new DateTime(1988, 1, 10), Email = "sophia.martinez@example.com", Phone = "555-6789", Address = "303 Cedar St", City = "Springfield", PostalCode = "62706", Country = "USA" },
                new Customer { CustomerID = 7, FirstName = "James", LastName = "Garcia", DateOfBirth = new DateTime(1975, 7, 20), Email = "james.garcia@example.com", Phone = "555-2345", Address = "404 Walnut St", City = "Springfield", PostalCode = "62707", Country = "USA" },
                new Customer { CustomerID = 8, FirstName = "Olivia", LastName = "Rodriguez", DateOfBirth = new DateTime(1992, 9, 25), Email = "olivia.rodriguez@example.com", Phone = "555-3456", Address = "505 Spruce St", City = "Springfield", PostalCode = "62708", Country = "USA" },
                new Customer { CustomerID = 9, FirstName = "Liam", LastName = "Wilson", DateOfBirth = new DateTime(1980, 11, 12), Email = "liam.wilson@example.com", Phone = "555-4567", Address = "606 Ash St", City = "Springfield", PostalCode = "62709", Country = "USA" },
                new Customer { CustomerID = 10, FirstName = "Emma", LastName = "Lee", DateOfBirth = new DateTime(1994, 5, 30), Email = "emma.lee@example.com", Phone = "555-5670", Address = "707 Redwood St", City = "Springfield", PostalCode = "62710", Country = "USA" }
            );

            // Seed data for Branches
            modelBuilder.Entity<Branch>().HasData(
                new Branch { BranchID = 1, BranchName = "Downtown Branch", Address = "100 Main St", City = "Springfield", PostalCode = "62701", Country = "USA" },
                new Branch { BranchID = 2, BranchName = "Northside Branch", Address = "200 North St", City = "Springfield", PostalCode = "62702", Country = "USA" },
                new Branch { BranchID = 3, BranchName = "Southside Branch", Address = "300 South St", City = "Springfield", PostalCode = "62703", Country = "USA" },
                new Branch { BranchID = 4, BranchName = "Eastside Branch", Address = "400 East St", City = "Springfield", PostalCode = "62704", Country = "USA" },
                new Branch { BranchID = 5, BranchName = "Westside Branch", Address = "500 West St", City = "Springfield", PostalCode = "62705", Country = "USA" }
            );


            // Seed data for Accounts
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountID = 1, AccountNumber = "AC123456789", CustomerID = 1, AccountType = "Checking", Balance = 1500.75m, DateOpened = new DateTime(2022, 1, 15), BranchID = 1 },
                new Account { AccountID = 2, AccountNumber = "AC987654321", CustomerID = 2, AccountType = "Savings", Balance = 3200.50m, DateOpened = new DateTime(2023, 3, 22), BranchID = 2 },
                new Account { AccountID = 3, AccountNumber = "AC456789123", CustomerID = 3, AccountType = "Checking", Balance = 800.25m, DateOpened = new DateTime(2021, 5, 30), BranchID = 1 },
                new Account { AccountID = 4, AccountNumber = "AC321654987", CustomerID = 4, AccountType = "Business", Balance = 50000.00m, DateOpened = new DateTime(2020, 7, 10), BranchID = 3 },
                new Account { AccountID = 5, AccountNumber = "AC654321789", CustomerID = 5, AccountType = "Savings", Balance = 1500.00m, DateOpened = new DateTime(2024, 2, 19), BranchID = 2 },
                new Account { AccountID = 6, AccountNumber = "AC111222333", CustomerID = 6, AccountType = "Checking", Balance = 1200.00m, DateOpened = new DateTime(2022, 4, 12), BranchID = 1 },
                new Account { AccountID = 7, AccountNumber = "AC444555666", CustomerID = 7, AccountType = "Savings", Balance = 2000.00m, DateOpened = new DateTime(2023, 6, 18), BranchID = 2 },
                new Account { AccountID = 8, AccountNumber = "AC777888999", CustomerID = 8, AccountType = "Business", Balance = 7500.00m, DateOpened = new DateTime(2022, 11, 23), BranchID = 3 },
                new Account { AccountID = 9, AccountNumber = "AC999888777", CustomerID = 9, AccountType = "Checking", Balance = 3000.00m, DateOpened = new DateTime(2021, 10, 5), BranchID = 1 },
                new Account { AccountID = 10, AccountNumber = "AC555444333", CustomerID = 10, AccountType = "Savings", Balance = 1800.00m, DateOpened = new DateTime(2023, 8, 8), BranchID = 2 }
            );


            // Seed data for Transactions
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionID = 1, AccountID = 1, TransactionDate = new DateTime(2024, 8, 10), TransactionType = "Deposit", Amount = 500.00m, Description = "Paycheck deposit" },
                new Transaction { TransactionID = 2, AccountID = 1, TransactionDate = new DateTime(2024, 8, 15), TransactionType = "Withdrawal", Amount = 100.00m, Description = "ATM withdrawal" },
                new Transaction { TransactionID = 3, AccountID = 2, TransactionDate = new DateTime(2024, 8, 20), TransactionType = "Transfer", Amount = 200.00m, Description = "Transfer to savings account" },
                new Transaction { TransactionID = 4, AccountID = 3, TransactionDate = new DateTime(2024, 8, 25), TransactionType = "Deposit", Amount = 300.00m, Description = "Deposit from freelance work" },
                new Transaction { TransactionID = 5, AccountID = 4, TransactionDate = new DateTime(2024, 8, 30), TransactionType = "Payment", Amount = 2000.00m, Description = "Business expense payment" },
                new Transaction { TransactionID = 6, AccountID = 5, TransactionDate = new DateTime(2024, 8, 5), TransactionType = "Deposit", Amount = 150.00m, Description = "Cash deposit" },
                new Transaction { TransactionID = 7, AccountID = 6, TransactionDate = new DateTime(2024, 8, 15), TransactionType = "Withdrawal", Amount = 50.00m, Description = "Grocery shopping" },
                new Transaction { TransactionID = 8, AccountID = 7, TransactionDate = new DateTime(2024, 8, 20), TransactionType = "Deposit", Amount = 500.00m, Description = "Transfer from another account" },
                new Transaction { TransactionID = 9, AccountID = 8, TransactionDate = new DateTime(2024, 8, 25), TransactionType = "Payment", Amount = 1000.00m, Description = "Supplier payment" },
                new Transaction { TransactionID = 10, AccountID = 9, TransactionDate = new DateTime(2024, 8, 30), TransactionType = "Transfer", Amount = 1000.00m, Description = "Transfer to savings account" }
            );


            // Seed data for Loans
            modelBuilder.Entity<Loan>().HasData(
                 new Loan { LoanID = 1, CustomerID = 1, LoanType = "Personal", Amount = 5000.00m, InterestRate = 5.5m, StartDate = new DateTime(2022, 1, 15), EndDate = new DateTime(2025, 1, 15) },
                 new Loan { LoanID = 2, CustomerID = 2, LoanType = "Auto", Amount = 15000.00m, InterestRate = 3.8m, StartDate = new DateTime(2023, 3, 22), EndDate = new DateTime(2027, 3, 22) },
                 new Loan { LoanID = 3, CustomerID = 3, LoanType = "Mortgage", Amount = 200000.00m, InterestRate = 4.2m, StartDate = new DateTime(2021, 5, 30), EndDate = new DateTime(2041, 5, 30) },
                 new Loan { LoanID = 4, CustomerID = 4, LoanType = "Business", Amount = 50000.00m, InterestRate = 6.0m, StartDate = new DateTime(2020, 7, 10), EndDate = new DateTime(2025, 7, 10) },
                 new Loan { LoanID = 5, CustomerID = 5, LoanType = "Education", Amount = 10000.00m, InterestRate = 3.5m, StartDate = new DateTime(2024, 2, 19), EndDate = new DateTime(2030, 2, 19) },
                 new Loan { LoanID = 6, CustomerID = 6, LoanType = "Personal", Amount = 7000.00m, InterestRate = 5.0m, StartDate = new DateTime(2022, 4, 12), EndDate = new DateTime(2026, 4, 12) },
                 new Loan { LoanID = 7, CustomerID = 7, LoanType = "Auto", Amount = 12000.00m, InterestRate = 4.0m, StartDate = new DateTime(2023, 6, 18), EndDate = new DateTime(2027, 6, 18) },
                 new Loan { LoanID = 8, CustomerID = 8, LoanType = "Mortgage", Amount = 250000.00m, InterestRate = 4.5m, StartDate = new DateTime(2022, 11, 23), EndDate = new DateTime(2042, 11, 23) },
                 new Loan { LoanID = 9, CustomerID = 9, LoanType = "Business", Amount = 60000.00m, InterestRate = 6.2m, StartDate = new DateTime(2021, 10, 5), EndDate = new DateTime(2026, 10, 5) },
                 new Loan { LoanID = 10, CustomerID = 10, LoanType = "Education", Amount = 12000.00m, InterestRate = 3.7m, StartDate = new DateTime(2023, 8, 8), EndDate = new DateTime(2029, 8, 8) }
             );


            // Seed data for LoanPayments
            modelBuilder.Entity<LoanPayment>().HasData(
                new LoanPayment { PaymentID = 1, LoanID = 1, PaymentDate = new DateTime(2024, 2, 1), Amount = 500.00m, InterestPaid = 22.50m, PrincipalPaid = 477.50m },
                new LoanPayment { PaymentID = 2, LoanID = 1, PaymentDate = new DateTime(2024, 3, 1), Amount = 500.00m, InterestPaid = 21.75m, PrincipalPaid = 478.25m },
                new LoanPayment { PaymentID = 3, LoanID = 2, PaymentDate = new DateTime(2024, 4, 1), Amount = 600.00m, InterestPaid = 40.00m, PrincipalPaid = 560.00m },
                new LoanPayment { PaymentID = 4, LoanID = 3, PaymentDate = new DateTime(2024, 5, 1), Amount = 2000.00m, InterestPaid = 750.00m, PrincipalPaid = 1250.00m },
                new LoanPayment { PaymentID = 5, LoanID = 4, PaymentDate = new DateTime(2024, 6, 1), Amount = 1000.00m, InterestPaid = 300.00m, PrincipalPaid = 700.00m },
                new LoanPayment { PaymentID = 6, LoanID = 5, PaymentDate = new DateTime(2024, 7, 1), Amount = 300.00m, InterestPaid = 87.50m, PrincipalPaid = 212.50m },
                new LoanPayment { PaymentID = 7, LoanID = 6, PaymentDate = new DateTime(2024, 8, 1), Amount = 700.00m, InterestPaid = 35.00m, PrincipalPaid = 665.00m },
                new LoanPayment { PaymentID = 8, LoanID = 7, PaymentDate = new DateTime(2024, 9, 1), Amount = 700.00m, InterestPaid = 48.00m, PrincipalPaid = 652.00m },
                new LoanPayment { PaymentID = 9, LoanID = 8, PaymentDate = new DateTime(2024, 10, 1), Amount = 2500.00m, InterestPaid = 1125.00m, PrincipalPaid = 1375.00m },
                new LoanPayment { PaymentID = 10, LoanID = 9, PaymentDate = new DateTime(2024, 11, 1), Amount = 1500.00m, InterestPaid = 930.00m, PrincipalPaid = 570.00m }
            );


            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, FirstName = "John", LastName = "Smith", Position = "Branch Manager", Salary = 75000.00m, HireDate = new DateTime(2015, 1, 1), BranchID = 1 },
                new Employee { EmployeeID = 2, FirstName = "Alice", LastName = "Johnson", Position = "Teller", Salary = 35000.00m, HireDate = new DateTime(2018, 6, 15), BranchID = 2 },
                new Employee { EmployeeID = 3, FirstName = "Charlie", LastName = "Wilson", Position = "Loan Officer", Salary = 60000.00m, HireDate = new DateTime(2019, 10, 10), BranchID = 3 },
                new Employee { EmployeeID = 4, FirstName = "Diana", LastName = "Taylor", Position = "Customer Service", Salary = 40000.00m, HireDate = new DateTime(2022, 5, 25), BranchID = 1 },
                new Employee { EmployeeID = 5, FirstName = "Edward", LastName = "Anderson", Position = "Financial Advisor", Salary = 65000.00m, HireDate = new DateTime(2020, 8, 5), BranchID = 2 },
                new Employee { EmployeeID = 6, FirstName = "Fiona", LastName = "Clark", Position = "Loan Officer", Salary = 62000.00m, HireDate = new DateTime(2018, 11, 12), BranchID = 3 },
                new Employee { EmployeeID = 7, FirstName = "George", LastName = "Roberts", Position = "Teller", Salary = 36000.00m, HireDate = new DateTime(2021, 2, 15), BranchID = 4 },
                new Employee { EmployeeID = 8, FirstName = "Hannah", LastName = "Lopez", Position = "Branch Manager", Salary = 77000.00m, HireDate = new DateTime(2017, 3, 1), BranchID = 5 },
                new Employee { EmployeeID = 9, FirstName = "Isaac", LastName = "Walker", Position = "Customer Service", Salary = 42000.00m, HireDate = new DateTime(2022, 6, 10), BranchID = 4 },
                new Employee { EmployeeID = 10, FirstName = "Jasmine", LastName = "Young", Position = "Financial Advisor", Salary = 67000.00m, HireDate = new DateTime(2019, 4, 20), BranchID = 5 }
            );


            // Seed data for Cards
            modelBuilder.Entity<Card>().HasData(
                new Card { CardID = 1, AccountID = 1, CardNumber = "1234 5678 9012 3456", CardType = "Visa", ExpirationDate = new DateTime(2026, 1, 31), CVV = "123" },
                new Card { CardID = 2, AccountID = 2, CardNumber = "9876 5432 1098 7654", CardType = "MasterCard", ExpirationDate = new DateTime(2025, 7, 31), CVV = "456" },
                new Card { CardID = 3, AccountID = 3, CardNumber = "4567 8901 2345 6789", CardType = "American Express", ExpirationDate = new DateTime(2027, 11, 30), CVV = "7890" },
                new Card { CardID = 4, AccountID = 4, CardNumber = "6789 0123 4567 8901", CardType = "Discover", ExpirationDate = new DateTime(2026, 6, 30), CVV = "234" },
                new Card { CardID = 5, AccountID = 5, CardNumber = "8901 2345 6789 0123", CardType = "Visa", ExpirationDate = new DateTime(2025, 12, 31), CVV = "567" }
            );

            // Seed data for CreditScores
            modelBuilder.Entity<CreditScore>().HasData(
                new CreditScore { CreditScoreID = 1, CustomerID = 1, Score = 750, DateChecked = new DateTime(2024, 1, 15) },
                new CreditScore { CreditScoreID = 2, CustomerID = 2, Score = 680, DateChecked = new DateTime(2024, 2, 20) },
                new CreditScore { CreditScoreID = 3, CustomerID = 3, Score = 720, DateChecked = new DateTime(2024, 3, 25) },
                new CreditScore { CreditScoreID = 4, CustomerID = 4, Score = 690, DateChecked = new DateTime(2024, 4, 30) },
                new CreditScore { CreditScoreID = 5, CustomerID = 5, Score = 710, DateChecked = new DateTime(2024, 5, 10) }
            );

        }
    }
}
