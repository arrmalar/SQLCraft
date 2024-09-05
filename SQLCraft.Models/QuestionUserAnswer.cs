using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLCraft.Models
{
    public class QuestionUserAnswer
    {
        [Key]
        [Column(Order = 0)]
        public string QuestionID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
