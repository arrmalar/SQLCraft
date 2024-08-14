using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SQLCraft.Models.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLCraft.Models
{
    public class QueryRiddle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DBSchemaId { get; set; }

        [ForeignKey("DBSchemaId")]
        [ValidateNever]
        public DBSchema DBSchema { get; set; }

        [Required]
        public QuestionLevel QuestionLevel { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }
    }
}
