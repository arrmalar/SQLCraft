using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCraft.Models.DTO
{
    public class ExecuteQueryDTO
    {
        public string Query {  get; set; }

        public DBSchema DBSchema { get; set; }
    }
}
