using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using Microsoft.Data.SqlClient;
using System.Data;
using SQLCraft.Models.DTO;

namespace SQLCraft.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQLQueryController : ControllerBase
    {            
        private readonly IUnitOfWorkApplication _unitOfWorkApplication;
        private readonly IConfiguration _configuration;

        private readonly string _warehouseConnectionString;
        private readonly string _bankConnectionString;
        private readonly string _universityConnectionString;

        private readonly string _warehouseTestCasesConnectionString;
        private readonly string _bankTestCasesConnectionString;
        private readonly string _universityTestCasesConnectionString;

        public SQLQueryController( IUnitOfWorkApplication unitOfWorkApplication, IConfiguration configuration)
        {
            _unitOfWorkApplication = unitOfWorkApplication;
            _configuration = configuration;

            _warehouseConnectionString = _configuration["ConnectionStrings:RiddleWarehouseConnection"] ?? "";
            _bankConnectionString = _configuration["ConnectionStrings:RiddleBankConnection"] ?? "";
            _universityConnectionString = _configuration["ConnectionStrings:RiddleUniversityConnection"] ?? "";

            _warehouseTestCasesConnectionString = _configuration["ConnectionStrings:RiddleWarehouseTestCasesConnection"] ?? "";
            _bankTestCasesConnectionString = _configuration["ConnectionStrings:RiddleBankTestCasesConnection"] ?? "";
            _universityTestCasesConnectionString = _configuration["ConnectionStrings:RiddleUniversityTestCasesConnection"]?? "";
        }

        [HttpPost("ExecuteQuery")]
        public async Task<ActionResult<string>> ExecuteQuery([FromBody] ExecuteQuery executeQuery)
        {
            DataTable resultTable = new DataTable();
            var connectionString = "";

            switch (executeQuery.DBSchema.Name ?? "")
            {
                case "Warehouse":
                    connectionString = executeQuery.AdditionalTests ? _warehouseTestCasesConnectionString :  _warehouseConnectionString;
                    break;
                case "Bank":
                    connectionString = executeQuery.AdditionalTests ? _bankTestCasesConnectionString : _bankConnectionString;
                    break;
                case "University":
                    connectionString = executeQuery.AdditionalTests ? _universityTestCasesConnectionString : _universityConnectionString;
                    break;
            }

            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                using (var cmd = new SqlCommand(executeQuery.Query, conn))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        resultTable.Load(reader);
                    }
                }
            }

            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(resultTable);
            return Ok(jsonResult);
        }
    }
}
