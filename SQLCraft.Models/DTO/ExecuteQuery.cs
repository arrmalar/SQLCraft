
namespace SQLCraft.Models.DTO
{
    public class ExecuteQuery
    {
        public string Query {  get; set; }

        public DBSchema DBSchema { get; set; }

        public bool AdditionalTests { get; set; }
    }
}
