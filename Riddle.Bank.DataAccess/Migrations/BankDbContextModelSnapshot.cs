﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Riddle.Bank.TestCases.DataAccess.Data;

#nullable disable

namespace Riddle.Bank.DataAccess.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Riddle.Bank.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountID");

                    b.HasIndex("BranchID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            AccountNumber = "ACC123456",
                            AccountType = "Savings",
                            Balance = 1000.00m,
                            BranchID = 1,
                            CustomerID = 1,
                            DateOpened = new DateTime(2024, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7533)
                        },
                        new
                        {
                            AccountID = 2,
                            AccountNumber = "ACC654321",
                            AccountType = "Checking",
                            Balance = 500.00m,
                            BranchID = 2,
                            CustomerID = 2,
                            DateOpened = new DateTime(2024, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7611)
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BranchID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BranchID");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            BranchID = 1,
                            Address = "123 Main St",
                            BranchName = "Main Branch",
                            City = "New York",
                            Country = "USA",
                            PostalCode = "10001"
                        },
                        new
                        {
                            BranchID = 2,
                            Address = "456 Elm St",
                            BranchName = "Downtown Branch",
                            City = "New York",
                            Country = "USA",
                            PostalCode = "10002"
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CardID");

                    b.HasIndex("AccountID");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardID = 1,
                            AccountID = 1,
                            CVV = "123",
                            CardNumber = "4111111111111111",
                            CardType = "Credit",
                            ExpirationDate = new DateTime(2026, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7815)
                        },
                        new
                        {
                            CardID = 2,
                            AccountID = 2,
                            CVV = "456",
                            CardNumber = "4222222222222222",
                            CardType = "Debit",
                            ExpirationDate = new DateTime(2026, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7822)
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.CreditScore", b =>
                {
                    b.Property<int>("CreditScoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditScoreID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateChecked")
                        .HasColumnType("datetime2");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("CreditScoreID");

                    b.HasIndex("CustomerID");

                    b.ToTable("CreditScores");

                    b.HasData(
                        new
                        {
                            CreditScoreID = 1,
                            CustomerID = 1,
                            DateChecked = new DateTime(2024, 7, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7849),
                            Score = 720
                        },
                        new
                        {
                            CreditScoreID = 2,
                            CustomerID = 2,
                            DateChecked = new DateTime(2024, 7, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7854),
                            Score = 680
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Address = "123 Main St",
                            City = "New York",
                            Country = "USA",
                            DateOfBirth = new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "123-456-7890",
                            PostalCode = "10001"
                        },
                        new
                        {
                            CustomerID = 2,
                            Address = "456 Elm St",
                            City = "New York",
                            Country = "USA",
                            DateOfBirth = new DateTime(1990, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "987-654-3210",
                            PostalCode = "10002"
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("BranchID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            BranchID = 1,
                            FirstName = "Alice",
                            HireDate = new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Johnson",
                            Position = "Branch Manager",
                            Salary = 75000.00m
                        },
                        new
                        {
                            EmployeeID = 2,
                            BranchID = 2,
                            FirstName = "Bob",
                            HireDate = new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Williams",
                            Position = "Teller",
                            Salary = 40000.00m
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("LoanType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("LoanID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanID = 1,
                            Amount = 5000.00m,
                            CustomerID = 1,
                            EndDate = new DateTime(2026, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7711),
                            InterestRate = 5.00m,
                            LoanType = "Personal",
                            StartDate = new DateTime(2024, 2, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7704)
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.LoanPayment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InterestPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LoanID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PrincipalPaid")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PaymentID");

                    b.HasIndex("LoanID");

                    b.ToTable("LoanPayments");

                    b.HasData(
                        new
                        {
                            PaymentID = 1,
                            Amount = 250.00m,
                            InterestPaid = 50.00m,
                            LoanID = 1,
                            PaymentDate = new DateTime(2024, 3, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7749),
                            PrincipalPaid = 200.00m
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountID");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionID = 1,
                            AccountID = 1,
                            Amount = 1000.00m,
                            Description = "Initial deposit",
                            TransactionDate = new DateTime(2024, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7656),
                            TransactionType = "Deposit"
                        },
                        new
                        {
                            TransactionID = 2,
                            AccountID = 2,
                            Amount = 500.00m,
                            Description = "Initial deposit",
                            TransactionDate = new DateTime(2024, 8, 26, 14, 22, 18, 238, DateTimeKind.Local).AddTicks(7662),
                            TransactionType = "Deposit"
                        });
                });

            modelBuilder.Entity("Riddle.Bank.Models.Account", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Riddle.Bank.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Riddle.Bank.Models.Card", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Riddle.Bank.Models.CreditScore", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Riddle.Bank.Models.Employee", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Riddle.Bank.Models.Loan", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Riddle.Bank.Models.LoanPayment", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");
                });

            modelBuilder.Entity("Riddle.Bank.Models.Transaction", b =>
                {
                    b.HasOne("Riddle.Bank.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
