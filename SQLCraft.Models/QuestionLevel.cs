using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SQLCraft.Models
{
    public enum QuestionLevel
    {
        [Description("Easy")]
        Easy = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("Hard")]
        Hard = 3,
        [Description("Challenge")]
        Challenge = 4
    }
}
