using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLCraft.Models
{
    public class QueryRiddle
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int DBSchemaID { get; set; }

        [ForeignKey("DBSchemaID")]
        [ValidateNever]
        public DBSchema DBSchema { get; set; }

        [Required]
        public int QuestionCorrectAnswerID { get; set; }

        [ForeignKey("QuestionCorrectAnswerID")]
        [ValidateNever]
        public QuestionCorrectAnswer QuestionCorrectAnswer { get; set; }

        [Required]
        public int QuestionLevelID { get; set; }

        [ForeignKey("QuestionLevelID")]
        [ValidateNever]
        public QuestionLevel QuestionLevel { get; set; }

        [Required]
        public string Question { get; set; }
    }
}
