﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Riddle.University.TestCases.DataAccess.Data;

#nullable disable

namespace Riddle.University.TestCases.DataAccess.Migrations
{
    [DbContext(typeof(UniversityTestCasesDbContext))]
    [Migration("20240826130511_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Class", b =>
                {
                    b.Property<int>("ClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassID"));

                    b.Property<string>("ClassRoom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("FacultyID")
                        .HasColumnType("int");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ClassID");

                    b.HasIndex("CourseID");

                    b.HasIndex("FacultyID");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassID = 1,
                            ClassRoom = "Room 101",
                            CourseID = 1,
                            FacultyID = 1,
                            Schedule = "Mon/Wed/Fri 10:00-11:00",
                            Semester = "Fall",
                            Year = 2024
                        },
                        new
                        {
                            ClassID = 2,
                            ClassRoom = "Room 102",
                            CourseID = 2,
                            FacultyID = 2,
                            Schedule = "Tue/Thu 14:00-15:30",
                            Semester = "Spring",
                            Year = 2024
                        },
                        new
                        {
                            ClassID = 3,
                            ClassRoom = "Room 103",
                            CourseID = 3,
                            FacultyID = 3,
                            Schedule = "Mon/Wed/Fri 11:00-12:00",
                            Semester = "Fall",
                            Year = 2024
                        },
                        new
                        {
                            ClassID = 4,
                            ClassRoom = "Room 104",
                            CourseID = 4,
                            FacultyID = 4,
                            Schedule = "Tue/Thu 09:00-10:30",
                            Semester = "Spring",
                            Year = 2024
                        },
                        new
                        {
                            ClassID = 5,
                            ClassRoom = "Room 105",
                            CourseID = 5,
                            FacultyID = 1,
                            Schedule = "Mon/Wed 13:00-14:30",
                            Semester = "Fall",
                            Year = 2024
                        },
                        new
                        {
                            ClassID = 6,
                            ClassRoom = "Room 106",
                            CourseID = 6,
                            FacultyID = 2,
                            Schedule = "Tue/Thu 15:00-16:30",
                            Semester = "Spring",
                            Year = 2024
                        });
                });

            modelBuilder.Entity("Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseID = 1,
                            CourseCode = "CS101",
                            CourseName = "Introduction to Programming",
                            Credits = 4,
                            DepartmentID = 1
                        },
                        new
                        {
                            CourseID = 2,
                            CourseCode = "MATH101",
                            CourseName = "Calculus I",
                            Credits = 3,
                            DepartmentID = 2
                        },
                        new
                        {
                            CourseID = 3,
                            CourseCode = "PHYS101",
                            CourseName = "Physics I",
                            Credits = 4,
                            DepartmentID = 3
                        },
                        new
                        {
                            CourseID = 4,
                            CourseCode = "BIO101",
                            CourseName = "Biology I",
                            Credits = 4,
                            DepartmentID = 4
                        },
                        new
                        {
                            CourseID = 5,
                            CourseCode = "CS201",
                            CourseName = "Data Structures",
                            Credits = 4,
                            DepartmentID = 1
                        },
                        new
                        {
                            CourseID = 6,
                            CourseCode = "MATH201",
                            CourseName = "Linear Algebra",
                            Credits = 3,
                            DepartmentID = 2
                        },
                        new
                        {
                            CourseID = 7,
                            CourseCode = "CHEM101",
                            CourseName = "Organic Chemistry",
                            Credits = 4,
                            DepartmentID = 4
                        });
                });

            modelBuilder.Entity("Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 1,
                            DepartmentName = "Computer Science"
                        },
                        new
                        {
                            DepartmentID = 2,
                            DepartmentName = "Mathematics"
                        },
                        new
                        {
                            DepartmentID = 3,
                            DepartmentName = "Physics"
                        },
                        new
                        {
                            DepartmentID = 4,
                            DepartmentName = "Biology"
                        });
                });

            modelBuilder.Entity("Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentID = 1,
                            CourseID = 1,
                            EnrollmentDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = "A",
                            StudentID = 1
                        },
                        new
                        {
                            EnrollmentID = 2,
                            CourseID = 2,
                            EnrollmentDate = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = "B",
                            StudentID = 2
                        },
                        new
                        {
                            EnrollmentID = 3,
                            CourseID = 3,
                            EnrollmentDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = "A",
                            StudentID = 3
                        },
                        new
                        {
                            EnrollmentID = 4,
                            CourseID = 4,
                            EnrollmentDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = "C",
                            StudentID = 4
                        },
                        new
                        {
                            EnrollmentID = 5,
                            CourseID = 5,
                            EnrollmentDate = new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = "B",
                            StudentID = 1
                        },
                        new
                        {
                            EnrollmentID = 6,
                            CourseID = 6,
                            EnrollmentDate = new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Grade = "A",
                            StudentID = 2
                        });
                });

            modelBuilder.Entity("Exam", b =>
                {
                    b.Property<int>("ExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamID"));

                    b.Property<int>("ClassID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.HasKey("ExamID");

                    b.HasIndex("ClassID");

                    b.ToTable("Exams");

                    b.HasData(
                        new
                        {
                            ExamID = 1,
                            ClassID = 1,
                            ExamDate = new DateTime(2024, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ExamType = "Midterm",
                            TotalMarks = 100
                        },
                        new
                        {
                            ExamID = 2,
                            ClassID = 2,
                            ExamDate = new DateTime(2024, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ExamType = "Final",
                            TotalMarks = 100
                        },
                        new
                        {
                            ExamID = 3,
                            ClassID = 3,
                            ExamDate = new DateTime(2024, 11, 10, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ExamType = "Midterm",
                            TotalMarks = 100
                        },
                        new
                        {
                            ExamID = 4,
                            ClassID = 4,
                            ExamDate = new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ExamType = "Final",
                            TotalMarks = 100
                        },
                        new
                        {
                            ExamID = 5,
                            ClassID = 5,
                            ExamDate = new DateTime(2024, 10, 5, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ExamType = "Midterm",
                            TotalMarks = 100
                        },
                        new
                        {
                            ExamID = 6,
                            ClassID = 6,
                            ExamDate = new DateTime(2024, 5, 25, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            ExamType = "Final",
                            TotalMarks = 100
                        });
                });

            modelBuilder.Entity("ExamResult", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultID"));

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<int>("MarksObtained")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ResultID");

                    b.HasIndex("ExamID");

                    b.HasIndex("StudentID");

                    b.ToTable("ExamResults");

                    b.HasData(
                        new
                        {
                            ResultID = 1,
                            ExamID = 1,
                            Grade = "A",
                            MarksObtained = 90,
                            StudentID = 1
                        },
                        new
                        {
                            ResultID = 2,
                            ExamID = 2,
                            Grade = "B",
                            MarksObtained = 85,
                            StudentID = 2
                        },
                        new
                        {
                            ResultID = 3,
                            ExamID = 3,
                            Grade = "A",
                            MarksObtained = 92,
                            StudentID = 3
                        },
                        new
                        {
                            ResultID = 4,
                            ExamID = 4,
                            Grade = "C",
                            MarksObtained = 75,
                            StudentID = 4
                        },
                        new
                        {
                            ResultID = 5,
                            ExamID = 5,
                            Grade = "B",
                            MarksObtained = 88,
                            StudentID = 1
                        },
                        new
                        {
                            ResultID = 6,
                            ExamID = 6,
                            Grade = "A",
                            MarksObtained = 90,
                            StudentID = 2
                        },
                        new
                        {
                            ResultID = 7,
                            ExamID = 1,
                            Grade = "B",
                            MarksObtained = 85,
                            StudentID = 3
                        },
                        new
                        {
                            ResultID = 8,
                            ExamID = 2,
                            Grade = "C",
                            MarksObtained = 70,
                            StudentID = 4
                        });
                });

            modelBuilder.Entity("Faculty", b =>
                {
                    b.Property<int>("FacultyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultyID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

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

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("FacultyID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            FacultyID = 1,
                            DepartmentID = 1,
                            Email = "john.doe@example.com",
                            FirstName = "John",
                            HireDate = new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Doe",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            FacultyID = 2,
                            DepartmentID = 2,
                            Email = "jane.smith@example.com",
                            FirstName = "Jane",
                            HireDate = new DateTime(2018, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Smith",
                            Phone = "987-654-3210"
                        },
                        new
                        {
                            FacultyID = 3,
                            DepartmentID = 3,
                            Email = "alice.johnson@example.com",
                            FirstName = "Alice",
                            HireDate = new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Johnson",
                            Phone = "555-6789"
                        },
                        new
                        {
                            FacultyID = 4,
                            DepartmentID = 4,
                            Email = "bob.williams@example.com",
                            FirstName = "Bob",
                            HireDate = new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Williams",
                            Phone = "555-9876"
                        });
                });

            modelBuilder.Entity("Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

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

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

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

                    b.HasKey("StudentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            Address = "123 Elm St",
                            City = "Somewhere",
                            Country = "USA",
                            DateOfBirth = new DateTime(2000, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "alice.johnson@example.com",
                            EnrollmentDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Phone = "555-1234",
                            PostalCode = "12345"
                        },
                        new
                        {
                            StudentID = 2,
                            Address = "456 Oak St",
                            City = "Anywhere",
                            Country = "USA",
                            DateOfBirth = new DateTime(1999, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "bob.williams@example.com",
                            EnrollmentDate = new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bob",
                            LastName = "Williams",
                            Phone = "555-5678",
                            PostalCode = "67890"
                        },
                        new
                        {
                            StudentID = 3,
                            Address = "789 Pine St",
                            City = "Everywhere",
                            Country = "USA",
                            DateOfBirth = new DateTime(2001, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "charlie.brown@example.com",
                            EnrollmentDate = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Charlie",
                            LastName = "Brown",
                            Phone = "555-8765",
                            PostalCode = "54321"
                        },
                        new
                        {
                            StudentID = 4,
                            Address = "101 Maple St",
                            City = "Nowhere",
                            Country = "USA",
                            DateOfBirth = new DateTime(2000, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "diana.miller@example.com",
                            EnrollmentDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Diana",
                            LastName = "Miller",
                            Phone = "555-3456",
                            PostalCode = "67890"
                        });
                });

            modelBuilder.Entity("Class", b =>
                {
                    b.HasOne("Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("Course", b =>
                {
                    b.HasOne("Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Enrollment", b =>
                {
                    b.HasOne("Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Exam", b =>
                {
                    b.HasOne("Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("ExamResult", b =>
                {
                    b.HasOne("Exam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Faculty", b =>
                {
                    b.HasOne("Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
