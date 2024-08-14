using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLCraft.Models.Schema
{
    public class Column
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string DataType { get; set; }

        [Required]
        public bool IsNullable { get; set; }

        [Required]
        public bool IsPrimaryKey { get; set; }

        [Required]
        public string DefaultValue { get; set; }

        [Required]
        public int TableId { get; set; }

        [ForeignKey("TableId")]
        [ValidateNever]
        public Table Table { get; set; }
    }
}
