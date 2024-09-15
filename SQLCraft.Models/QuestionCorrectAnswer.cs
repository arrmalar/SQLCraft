using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLCraft.Models
{
    public class QuestionCorrectAnswer
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The Answer field is required.")]
        public string? CorrectAnswer { get; set; }
    }
}
