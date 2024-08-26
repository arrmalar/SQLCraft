using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Riddle.University.TestCases.DataAccess.Data
{
    public class UniversityTestCasesDbContext : DbContext
    {
        public UniversityTestCasesDbContext(DbContextOptions<UniversityTestCasesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Faculty)
                .WithMany()
                .HasForeignKey(c => c.FacultyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.Department)
                .WithMany()
                .HasForeignKey(f => f.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "Computer Science"},
                new Department { DepartmentID = 2, DepartmentName = "Mathematics"},
                new Department { DepartmentID = 3, DepartmentName = "Physics"},
                new Department { DepartmentID = 4, DepartmentName = "Biology"}
            );

            // Seed Faculties
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { FacultyID = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "123-456-7890", HireDate = new DateTime(2015, 6, 1), DepartmentID = 1 },
                new Faculty { FacultyID = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Phone = "987-654-3210", HireDate = new DateTime(2018, 8, 15), DepartmentID = 2 },
                new Faculty { FacultyID = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", Phone = "555-6789", HireDate = new DateTime(2019, 1, 10), DepartmentID = 3 },
                new Faculty { FacultyID = 4, FirstName = "Bob", LastName = "Williams", Email = "bob.williams@example.com", Phone = "555-9876", HireDate = new DateTime(2020, 4, 20), DepartmentID = 4 }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1, CourseName = "Introduction to Programming", CourseCode = "CS101", Credits = 4, DepartmentID = 1 },
                new Course { CourseID = 2, CourseName = "Calculus I", CourseCode = "MATH101", Credits = 3, DepartmentID = 2 },
                new Course { CourseID = 3, CourseName = "Physics I", CourseCode = "PHYS101", Credits = 4, DepartmentID = 3 },
                new Course { CourseID = 4, CourseName = "Biology I", CourseCode = "BIO101", Credits = 4, DepartmentID = 4 },
                new Course { CourseID = 5, CourseName = "Data Structures", CourseCode = "CS201", Credits = 4, DepartmentID = 1 },
                new Course { CourseID = 6, CourseName = "Linear Algebra", CourseCode = "MATH201", Credits = 3, DepartmentID = 2 },
                new Course { CourseID = 7, CourseName = "Organic Chemistry", CourseCode = "CHEM101", Credits = 4, DepartmentID = 4 }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(2000, 4, 15), Email = "alice.johnson@example.com", Phone = "555-1234", Address = "123 Elm St", City = "Somewhere", PostalCode = "12345", Country = "USA", EnrollmentDate = new DateTime(2018, 9, 1) },
                new Student { StudentID = 2, FirstName = "Bob", LastName = "Williams", DateOfBirth = new DateTime(1999, 11, 22), Email = "bob.williams@example.com", Phone = "555-5678", Address = "456 Oak St", City = "Anywhere", PostalCode = "67890", Country = "USA", EnrollmentDate = new DateTime(2019, 9, 1) },
                new Student { StudentID = 3, FirstName = "Charlie", LastName = "Brown", DateOfBirth = new DateTime(2001, 2, 10), Email = "charlie.brown@example.com", Phone = "555-8765", Address = "789 Pine St", City = "Everywhere", PostalCode = "54321", Country = "USA", EnrollmentDate = new DateTime(2020, 9, 1) },
                new Student { StudentID = 4, FirstName = "Diana", LastName = "Miller", DateOfBirth = new DateTime(2000, 6, 18), Email = "diana.miller@example.com", Phone = "555-3456", Address = "101 Maple St", City = "Nowhere", PostalCode = "67890", Country = "USA", EnrollmentDate = new DateTime(2018, 9, 1) }
            );

            // Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 1, EnrollmentDate = new DateTime(2018, 9, 1), Grade = "A" },
                new Enrollment { EnrollmentID = 2, StudentID = 2, CourseID = 2, EnrollmentDate = new DateTime(2019, 9, 1), Grade = "B" },
                new Enrollment { EnrollmentID = 3, StudentID = 3, CourseID = 3, EnrollmentDate = new DateTime(2020, 9, 1), Grade = "A" },
                new Enrollment { EnrollmentID = 4, StudentID = 4, CourseID = 4, EnrollmentDate = new DateTime(2018, 9, 1), Grade = "C" },
                new Enrollment { EnrollmentID = 5, StudentID = 1, CourseID = 5, EnrollmentDate = new DateTime(2019, 1, 15), Grade = "B" },
                new Enrollment { EnrollmentID = 6, StudentID = 2, CourseID = 6, EnrollmentDate = new DateTime(2019, 1, 15), Grade = "A" }
            );

            // Seed Classes
            modelBuilder.Entity<Class>().HasData(
                new Class { ClassID = 1, CourseID = 1, FacultyID = 1, Semester = "Fall", Year = 2024, ClassRoom = "Room 101", Schedule = "Mon/Wed/Fri 10:00-11:00" },
                new Class { ClassID = 2, CourseID = 2, FacultyID = 2, Semester = "Spring", Year = 2024, ClassRoom = "Room 102", Schedule = "Tue/Thu 14:00-15:30" },
                new Class { ClassID = 3, CourseID = 3, FacultyID = 3, Semester = "Fall", Year = 2024, ClassRoom = "Room 103", Schedule = "Mon/Wed/Fri 11:00-12:00" },
                new Class { ClassID = 4, CourseID = 4, FacultyID = 4, Semester = "Spring", Year = 2024, ClassRoom = "Room 104", Schedule = "Tue/Thu 09:00-10:30" },
                new Class { ClassID = 5, CourseID = 5, FacultyID = 1, Semester = "Fall", Year = 2024, ClassRoom = "Room 105", Schedule = "Mon/Wed 13:00-14:30" },
                new Class { ClassID = 6, CourseID = 6, FacultyID = 2, Semester = "Spring", Year = 2024, ClassRoom = "Room 106", Schedule = "Tue/Thu 15:00-16:30" }
            );

            // Seed Exams
            modelBuilder.Entity<Exam>().HasData(
                new Exam { ExamID = 1, ClassID = 1, ExamDate = new DateTime(2024, 12, 15, 9, 0, 0), ExamType = "Midterm", TotalMarks = 100 },
                new Exam { ExamID = 2, ClassID = 2, ExamDate = new DateTime(2024, 5, 20, 9, 0, 0), ExamType = "Final", TotalMarks = 100 },
                new Exam { ExamID = 3, ClassID = 3, ExamDate = new DateTime(2024, 11, 10, 9, 0, 0), ExamType = "Midterm", TotalMarks = 100 },
                new Exam { ExamID = 4, ClassID = 4, ExamDate = new DateTime(2024, 6, 15, 9, 0, 0), ExamType = "Final", TotalMarks = 100 },
                new Exam { ExamID = 5, ClassID = 5, ExamDate = new DateTime(2024, 10, 5, 9, 0, 0), ExamType = "Midterm", TotalMarks = 100 },
                new Exam { ExamID = 6, ClassID = 6, ExamDate = new DateTime(2024, 5, 25, 9, 0, 0), ExamType = "Final", TotalMarks = 100 }
            );

            // Seed Exam Results
            modelBuilder.Entity<ExamResult>().HasData(
                new ExamResult { ResultID = 1, ExamID = 1, StudentID = 1, MarksObtained = 90, Grade = "A" },
                new ExamResult { ResultID = 2, ExamID = 2, StudentID = 2, MarksObtained = 85, Grade = "B" },
                new ExamResult { ResultID = 3, ExamID = 3, StudentID = 3, MarksObtained = 92, Grade = "A" },
                new ExamResult { ResultID = 4, ExamID = 4, StudentID = 4, MarksObtained = 75, Grade = "C" },
                new ExamResult { ResultID = 5, ExamID = 5, StudentID = 1, MarksObtained = 88, Grade = "B" },
                new ExamResult { ResultID = 6, ExamID = 6, StudentID = 2, MarksObtained = 90, Grade = "A" },
                new ExamResult { ResultID = 7, ExamID = 1, StudentID = 3, MarksObtained = 85, Grade = "B" },
                new ExamResult { ResultID = 8, ExamID = 2, StudentID = 4, MarksObtained = 70, Grade = "C" }
            );
        }
    }
}
