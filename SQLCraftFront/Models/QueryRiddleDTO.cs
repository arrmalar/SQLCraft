using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SQLCraft.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SQLCraftFront.Models
{
    public class QueryRiddleDTO
    {
        public int ID { get; set; }
        public int DBSchemaID { get; set; }
        public DBSchema DBSchema { get; set; }
        public int QuestionCorrectAnswerID { get; set; }
        public QuestionCorrectAnswer QuestionCorrectAnswer { get; set; }
        public int QuestionLevelID { get; set; }
        public QuestionLevel QuestionLevel { get; set; }
        public string Question { get; set; }
    }
}
