using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SQLCraft.Models.VM
{
    public class QueryAnswer
    {
        public QueryRiddle QueryRiddle { get; set; }

        public string UserAnswer { get; set; }

        public DataTable UserResult { get; set; }

        public DataTable CorrectResult { get; set; }
    }
}
