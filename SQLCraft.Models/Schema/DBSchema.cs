using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SQLCraft.Models.Schema
{
    public class DBSchema
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ValidateNever]
        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}
