using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Riddle.University.TestCases.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.FacultyID);
                    table.ForeignKey(
                        name: "FK_Faculties_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ClassRoom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                    table.ForeignKey(
                        name: "FK_Classes_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Faculties_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculties",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_Exams_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    ResultID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    MarksObtained = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.ResultID);
                    table.ForeignKey(
                        name: "FK_ExamResults_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamResults_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Mathematics" },
                    { 3, "Physics" },
                    { 4, "Biology" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Address", "City", "Country", "DateOfBirth", "Email", "EnrollmentDate", "FirstName", "LastName", "Phone", "PostalCode" },
                values: new object[,]
                {
                    { 1, "123 Elm St", "Somewhere", "USA", new DateTime(2000, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice", "Johnson", "555-1234", "12345" },
                    { 2, "456 Oak St", "Anywhere", "USA", new DateTime(1999, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.williams@example.com", new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "Williams", "555-5678", "67890" },
                    { 3, "789 Pine St", "Everywhere", "USA", new DateTime(2001, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlie.brown@example.com", new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charlie", "Brown", "555-8765", "54321" },
                    { 4, "101 Maple St", "Nowhere", "USA", new DateTime(2000, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana.miller@example.com", new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana", "Miller", "555-3456", "67890" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseID", "CourseCode", "CourseName", "Credits", "DepartmentID" },
                values: new object[,]
                {
                    { 1, "CS101", "Introduction to Programming", 4, 1 },
                    { 2, "MATH101", "Calculus I", 3, 2 },
                    { 3, "PHYS101", "Physics I", 4, 3 },
                    { 4, "BIO101", "Biology I", 4, 4 },
                    { 5, "CS201", "Data Structures", 4, 1 },
                    { 6, "MATH201", "Linear Algebra", 3, 2 },
                    { 7, "CHEM101", "Organic Chemistry", 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "FacultyID", "DepartmentID", "Email", "FirstName", "HireDate", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John", new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", "123-456-7890" },
                    { 2, 2, "jane.smith@example.com", "Jane", new DateTime(2018, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "987-654-3210" },
                    { 3, 3, "alice.johnson@example.com", "Alice", new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", "555-6789" },
                    { 4, 4, "bob.williams@example.com", "Bob", new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Williams", "555-9876" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassID", "ClassRoom", "CourseID", "FacultyID", "Schedule", "Semester", "Year" },
                values: new object[,]
                {
                    { 1, "Room 101", 1, 1, "Mon/Wed/Fri 10:00-11:00", "Fall", 2024 },
                    { 2, "Room 102", 2, 2, "Tue/Thu 14:00-15:30", "Spring", 2024 },
                    { 3, "Room 103", 3, 3, "Mon/Wed/Fri 11:00-12:00", "Fall", 2024 },
                    { 4, "Room 104", 4, 4, "Tue/Thu 09:00-10:30", "Spring", 2024 },
                    { 5, "Room 105", 5, 1, "Mon/Wed 13:00-14:30", "Fall", 2024 },
                    { 6, "Room 106", 6, 2, "Tue/Thu 15:00-16:30", "Spring", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentID", "CourseID", "EnrollmentDate", "Grade", "StudentID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 1 },
                    { 2, 2, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", 2 },
                    { 3, 3, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 3 },
                    { 4, 4, new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C", 4 },
                    { 5, 5, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "B", 1 },
                    { 6, 6, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 2 }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "ExamID", "ClassID", "ExamDate", "ExamType", "TotalMarks" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Midterm", 100 },
                    { 2, 2, new DateTime(2024, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), "Final", 100 },
                    { 3, 3, new DateTime(2024, 11, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Midterm", 100 },
                    { 4, 4, new DateTime(2024, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), "Final", 100 },
                    { 5, 5, new DateTime(2024, 10, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "Midterm", 100 },
                    { 6, 6, new DateTime(2024, 5, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), "Final", 100 }
                });

            migrationBuilder.InsertData(
                table: "ExamResults",
                columns: new[] { "ResultID", "ExamID", "Grade", "MarksObtained", "StudentID" },
                values: new object[,]
                {
                    { 1, 1, "A", 90, 1 },
                    { 2, 2, "B", 85, 2 },
                    { 3, 3, "A", 92, 3 },
                    { 4, 4, "C", 75, 4 },
                    { 5, 5, "B", 88, 1 },
                    { 6, 6, "A", 90, 2 },
                    { 7, 1, "B", 85, 3 },
                    { 8, 2, "C", 70, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourseID",
                table: "Classes",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_FacultyID",
                table: "Classes",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseID",
                table: "Enrollments",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamID",
                table: "ExamResults",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_StudentID",
                table: "ExamResults",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ClassID",
                table: "Exams",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_DepartmentID",
                table: "Faculties",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
