using Microsoft.AspNetCore.Identity;
using SQLCraft.Models.Schema;
using System.ComponentModel.DataAnnotations;

namespace SQLCraft.Models.VM
{
    public class QueryAnswer
    {
        public QueryRiddle QueryRiddle { get; set; }

        public string UserAnswer { get; set; }

        public List<DBSchema> DBSchemas { get; set; } = new List<DBSchema>();
    }
}
