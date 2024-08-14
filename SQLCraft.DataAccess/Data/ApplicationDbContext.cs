using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SQLCraft.Models;
using SQLCraft.Models.Schema;

namespace SQLCraft.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<QueryRiddle> QueryRiddles { get; set; }

        public DbSet<DBSchema> DBSchemas { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DBSchema>().HasData(
                    new DBSchema
                    {
                        Id = 1,
                        Name = "Warehouse",
                        Tables = new List<Table>
                        {
                            new Table 
                            { 
                                Id = 1, 
                                DBSchemaId = 1, 
                                Name = "Product", 
                                Columns = new List<Column> 
                                { 
                                    new Column
                                    { 
                                        Id=1,
                                        Name = "Id",
                                        DataType = "Int",
                                        DefaultValue = "",
                                        IsNullable = false,
                                        IsPrimaryKey = false,
                                        TableId = 1
                                    },
                                    new Column
                                    {
                                        Id=2,
                                        Name = "",
                                        DataType = "",
                                        DefaultValue = "",
                                        IsNullable = false,
                                        IsPrimaryKey = false,
                                        TableId = 1
                                    },
                                    new Column
                                    {
                                        Id=3,
                                        Name = "",
                                        DataType = "",
                                        DefaultValue = "",
                                        IsNullable = false,
                                        IsPrimaryKey = false,
                                        TableId = 1
                                    }
                                }
                            },
                            new Table
                            {
                                Id = 2,
                                DBSchemaId = 1,
                                Name = "",
                                Columns = new List<Column>
                                {
                                    new Column
                                    {
                                        Id=4,
                                        Name = "",
                                        DataType = "",
                                        DefaultValue = "",
                                        IsNullable = false,
                                        IsPrimaryKey = false,
                                        TableId = 1
                                    },
                                    new Column
                                    {
                                        Id=5,
                                        Name = "",
                                        DataType = "",
                                        DefaultValue = "",
                                        IsNullable = false,
                                        IsPrimaryKey = false,
                                        TableId = 1
                                    },
                                    new Column
                                    {
                                        Id=6,
                                        Name = "",
                                        DataType = "",
                                        DefaultValue = "",
                                        IsNullable = false,
                                        IsPrimaryKey = false,
                                        TableId = 1
                                    }
                                }
                            },
                        }
                    }
                );

            modelBuilder
           .Entity<QueryRiddle>()
           .Property(e => e.QuestionLevel)
           .HasConversion<int>();

            modelBuilder.Entity<Table>()
                .HasOne(t => t.DBSchema)
                .WithMany(ds => ds.Tables)
                .HasForeignKey(t => t.DBSchemaId)
                .IsRequired();

            modelBuilder.Entity<Column>()
                .HasOne(c => c.Table)
                .WithMany(t => t.Columns)
                .HasForeignKey(c => c.TableId)
                .IsRequired();
        }
    }
}
