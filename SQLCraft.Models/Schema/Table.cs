using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SQLCraft.Models.Schema
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DBSchemaId { get; set; }

        [ForeignKey("DBSchemaId")]
        [ValidateNever]
        public DBSchema DBSchema { get; set; }

        [ValidateNever]
        public ICollection<Column> Columns { get; set; } = new List<Column>();
    }
}
