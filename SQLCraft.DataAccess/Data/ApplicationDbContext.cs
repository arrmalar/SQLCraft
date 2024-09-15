using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<DBSchema> DBSchemas { get; set; }

        public DbSet<QuestionLevel> QuestionLevels { get; set; }

        public DbSet<QuestionCorrectAnswer> QuestionCorrectAnswers { get; set; }

        public DbSet<QuestionUserAnswer> QuestionUserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionUserAnswer>()
                .HasKey(q => new { q.QuestionID, q.UserID });

            modelBuilder.Entity<DBSchema>().HasData(
                new DBSchema { ID = 1, Name = "Warehouse" },
                new DBSchema { ID = 2, Name = "Bank" },
                new DBSchema { ID = 3, Name = "University" }
            );

            modelBuilder.Entity<QuestionLevel>().HasData(
               new QuestionLevel { ID = 1, Name = "Easy" },
               new QuestionLevel { ID = 2, Name = "Medium" },
               new QuestionLevel { ID = 3, Name = "Hard" },
               new QuestionLevel { ID = 4, Name = "Challenge" }
           );
        }
    }
}
