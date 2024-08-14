using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SQLCraft.Models
{
    public class SQLAnswer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}
