using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Riddle.University.DataAccess.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
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
            .HasOne(c => c.Course)
            .WithMany()
            .HasForeignKey(c => c.CourseID)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Faculty)
                .WithMany()
                .HasForeignKey(c => c.FacultyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany()
                .HasForeignKey(c => c.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Faculty>()
                .HasOne(f => f.Department)
                .WithMany()
                .HasForeignKey(f => f.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Class)
                .WithMany()
                .HasForeignKey(e => e.ClassID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamResult>()
                .HasOne(er => er.Exam)
                .WithMany()
                .HasForeignKey(er => er.ExamID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExamResult>()
                .HasOne(er => er.Student)
                .WithMany()
                .HasForeignKey(er => er.StudentID)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "Computer Science"},
                new Department { DepartmentID = 2, DepartmentName = "Mathematics"}
            );

            // Seed Faculties
            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { FacultyID = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "123-456-7890", HireDate = new DateTime(2015, 6, 1), DepartmentID = 1 },
                new Faculty { FacultyID = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", Phone = "987-654-3210", HireDate = new DateTime(2018, 8, 15), DepartmentID = 2 }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1, CourseName = "Introduction to Programming", CourseCode = "CS101", Credits = 4, DepartmentID = 1 },
                new Course { CourseID = 2, CourseName = "Calculus I", CourseCode = "MATH101", Credits = 3, DepartmentID = 2 }
            );

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentID = 1, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(2000, 4, 15), Email = "alice.johnson@example.com", Phone = "555-1234", Address = "123 Elm St", City = "Somewhere", PostalCode = "12345", Country = "USA", EnrollmentDate = new DateTime(2018, 9, 1) },
                new Student { StudentID = 2, FirstName = "Bob", LastName = "Williams", DateOfBirth = new DateTime(1999, 11, 22), Email = "bob.williams@example.com", Phone = "555-5678", Address = "456 Oak St", City = "Anywhere", PostalCode = "67890", Country = "USA", EnrollmentDate = new DateTime(2019, 9, 1) }
            );

            // Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 1, EnrollmentDate = new DateTime(2018, 9, 1), Grade = "A" },
                new Enrollment { EnrollmentID = 2, StudentID = 2, CourseID = 2, EnrollmentDate = new DateTime(2019, 9, 1), Grade = "B" }
            );

            // Seed Classes
            modelBuilder.Entity<Class>().HasData(
                new Class { ClassID = 1, CourseID = 1, FacultyID = 1, Semester = "Fall", Year = 2024, ClassRoom = "Room 101", Schedule = "Mon/Wed/Fri 10:00-11:00" },
                new Class { ClassID = 2, CourseID = 2, FacultyID = 2, Semester = "Spring", Year = 2024, ClassRoom = "Room 102", Schedule = "Tue/Thu 14:00-15:30" }
            );

            // Seed Exams
            modelBuilder.Entity<Exam>().HasData(
                new Exam { ExamID = 1, ClassID = 1, ExamDate = new DateTime(2024, 12, 15, 9, 0, 0), ExamType = "Midterm", TotalMarks = 100 },
                new Exam { ExamID = 2, ClassID = 2, ExamDate = new DateTime(2024, 5, 20, 9, 0, 0), ExamType = "Final", TotalMarks = 100 }
            );

            // Seed Exam Results
            modelBuilder.Entity<ExamResult>().HasData(
                new ExamResult { ResultID = 1, ExamID = 1, StudentID = 1, MarksObtained = 90, Grade = "A" },
                new ExamResult { ResultID = 2, ExamID = 2, StudentID = 2, MarksObtained = 85, Grade = "B" }
            );
        }
    }
}
