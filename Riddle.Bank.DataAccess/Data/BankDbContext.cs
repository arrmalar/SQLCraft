using Microsoft.EntityFrameworkCore;
using Riddle.Bank.Models;

namespace Riddle.Bank.TestCases.DataAccess.Data
{
    public class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
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

            // Seed data for Branches
            modelBuilder.Entity<Branch>().HasData(
                new Branch { BranchID = 1, BranchName = "Main Branch", Address = "123 Main St", City = "New York", PostalCode = "10001", Country = "USA" },
                new Branch { BranchID = 2, BranchName = "Downtown Branch", Address = "456 Elm St", City = "New York", PostalCode = "10002", Country = "USA" }
            );

            // Seed data for Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 5, 15), Email = "john.doe@example.com", Phone = "123-456-7890", Address = "123 Main St", City = "New York", PostalCode = "10001", Country = "USA" },
                new Customer { CustomerID = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1990, 7, 20), Email = "jane.smith@example.com", Phone = "987-654-3210", Address = "456 Elm St", City = "New York", PostalCode = "10002", Country = "USA" }
            );

            // Seed data for Accounts
            modelBuilder.Entity<Account>().HasData(
                new Account { AccountID = 1, AccountNumber = "ACC123456", CustomerID = 1, AccountType = "Savings", Balance = 1000.00m, DateOpened = DateTime.Now, BranchID = 1 },
                new Account { AccountID = 2, AccountNumber = "ACC654321", CustomerID = 2, AccountType = "Checking", Balance = 500.00m, DateOpened = DateTime.Now, BranchID = 2 }
            );

            // Seed data for Transactions
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionID = 1, AccountID = 1, TransactionDate = DateTime.Now, TransactionType = "Deposit", Amount = 1000.00m, Description = "Initial deposit" },
                new Transaction { TransactionID = 2, AccountID = 2, TransactionDate = DateTime.Now, TransactionType = "Deposit", Amount = 500.00m, Description = "Initial deposit" }
            );

            // Seed data for Loans
            modelBuilder.Entity<Loan>().HasData(
                new Loan { LoanID = 1, CustomerID = 1, LoanType = "Personal", Amount = 5000.00m, InterestRate = 5.00m, StartDate = DateTime.Now.AddMonths(-6), EndDate = DateTime.Now.AddYears(2) }
            );

            // Seed data for LoanPayments
            modelBuilder.Entity<LoanPayment>().HasData(
                new LoanPayment { PaymentID = 1, LoanID = 1, PaymentDate = DateTime.Now.AddMonths(-5), Amount = 250.00m, InterestPaid = 50.00m, PrincipalPaid = 200.00m }
            );

            // Seed data for Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, FirstName = "Alice", LastName = "Johnson", Position = "Branch Manager", Salary = 75000.00m, HireDate = new DateTime(2015, 3, 1), BranchID = 1 },
                new Employee { EmployeeID = 2, FirstName = "Bob", LastName = "Williams", Position = "Teller", Salary = 40000.00m, HireDate = new DateTime(2018, 6, 15), BranchID = 2 }
            );

            // Seed data for Cards
            modelBuilder.Entity<Card>().HasData(
                new Card { CardID = 1, AccountID = 1, CardNumber = "4111111111111111", CardType = "Credit", ExpirationDate = DateTime.Now.AddYears(2), CVV = "123" },
                new Card { CardID = 2, AccountID = 2, CardNumber = "4222222222222222", CardType = "Debit", ExpirationDate = DateTime.Now.AddYears(2), CVV = "456" }
            );

            // Seed data for CreditScores
            modelBuilder.Entity<CreditScore>().HasData(
                new CreditScore { CreditScoreID = 1, CustomerID = 1, Score = 720, DateChecked = DateTime.Now.AddMonths(-1) },
                new CreditScore { CreditScoreID = 2, CustomerID = 2, Score = 680, DateChecked = DateTime.Now.AddMonths(-1) }
            );
        }
    }
}
