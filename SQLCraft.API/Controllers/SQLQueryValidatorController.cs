using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Services.Interfaces;
using SQLCraft.Models.VM;

namespace SQLCraft.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class SQLQueryValidator : ControllerBase
    {            
        private readonly IUnitOfWorkApplication _unitOfWorkApplication;
        private readonly ISQLQueryValidatorService _sqlQueryValidatorService;
        private readonly IConfiguration _configuration;

        private readonly string _warehouseConnectionString;
        private readonly string _bankConnectionString;
        private readonly string _universityConnectionString;

        private readonly string _warehouseTestCasesConnectionString;
        private readonly string _bankTestCasesConnectionString;
        private readonly string _universityTestCasesConnectionString;

        public SQLQueryValidator( IUnitOfWorkApplication unitOfWorkApplication, ISQLQueryValidatorService sqlQueryValidatorService, IConfiguration configuration)
        {
            _unitOfWorkApplication = unitOfWorkApplication;
            _sqlQueryValidatorService = sqlQueryValidatorService;
            _configuration = configuration;

            _warehouseConnectionString = _configuration["ConnectionStrings:RiddleWarehouseConnection"];
            _bankConnectionString = _configuration["ConnectionStrings:RiddleBankConnection"];
            _universityConnectionString = _configuration["ConnectionStrings:RiddleUniversityConnection"];

            _warehouseTestCasesConnectionString = _configuration["ConnectionStrings:RiddleWarehouseTestCasesConnection"];
            _bankTestCasesConnectionString = _configuration["ConnectionStrings:RiddleBankTestCasesConnection"];
            _universityTestCasesConnectionString = _configuration["ConnectionStrings:RiddleUniversityTestCasesConnection"];
        }

        // POST api/queryRiddle
        [HttpPost]
        public ActionResult ExecuteQuery([FromBody] QueryAnswer queryAnswer)
        {
            var connectionString = "";

            switch (queryAnswer.QueryRiddle.DBSchema.Name) {
                case "Warehouse":
                    connectionString = _warehouseConnectionString;
                    break;
                case "Bank":
                    connectionString = _bankConnectionString;
                    break;
                case "University":
                    connectionString = _universityConnectionString;
                    break;
            }

            var queryCorrectAnswer = _unitOfWorkApplication.QuestionCorrectAnswerRepository.Get(qca => qca.ID == queryAnswer.QueryRiddle.QuestionCorrectAnswerID);

            var userResult = _sqlQueryValidatorService.ExecuteQuery(queryAnswer.UserAnswer, connectionString);
            var correctResult = _sqlQueryValidatorService.ExecuteQuery(queryCorrectAnswer.CorrectAnswer, connectionString);

            queryAnswer.CorrectResult = correctResult;
            queryAnswer.UserResult = userResult;

            var output = _sqlQueryValidatorService.ValidateQuery(userResult, correctResult);

            return Ok(output);
        }
    }
}
