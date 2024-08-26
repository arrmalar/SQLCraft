using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;
using SQLCraft.Models.VM;
using SQLCraft.Services;
using SQLCraft.Services.Interfaces;
using SQLCraft.Utility;

namespace SQLCraft.Areas.Customer.Controllers
{
    [Area("User")]
    [Authorize(Roles = $"{SD.Role_User},{SD.Role_Admin}")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkApplication _unitOfWorkApplication;
        private readonly ChatGPTService _chatGptService;
        private readonly ISQLQueryValidatorService _sqlQueryValidatorService;
        private readonly IConfiguration _configuration;

        private readonly string _warehouseConnectionString;
        private readonly string _bankConnectionString;
        private readonly string _universityConnectionString;

        public HomeController(
            IUnitOfWorkApplication unitOfWorkApplication, 
            ChatGPTService chatGptService,
            ISQLQueryValidatorService sqlQueryValidatorService,
            IConfiguration configuration)
        {
            _unitOfWorkApplication = unitOfWorkApplication;
            _chatGptService = chatGptService;
            _sqlQueryValidatorService = sqlQueryValidatorService;
            _configuration = configuration;
            _warehouseConnectionString = _configuration["ConnectionStrings:RiddleWarehouseConnection"];
            _bankConnectionString = _configuration["ConnectionStrings:RiddleWarehouseConnection"];
            _universityConnectionString = _configuration["ConnectionStrings:RiddleWarehouseConnection"];
        }

        public IActionResult Index()
        {
            var riddles = _unitOfWorkApplication.QueryRiddleRepository.GetAll(includeProperties: "DBSchema").ToList();
            var r = new Random();
            var rInt = r.Next(0, riddles.Count());
            var queryAnswer = new QueryAnswer();

            if (riddles.IsNullOrEmpty())
            {
                var riddle = new QueryRiddle();
                riddle.Question = "";
                queryAnswer.QueryRiddle = riddle;
                return View(queryAnswer);
            }

            queryAnswer.UserAnswer = "";
            queryAnswer.QueryRiddle = riddles[rInt];
            
            return View(queryAnswer);
        }

        [HttpPost]
        public async Task<IActionResult> Index(QueryAnswer queryAnswer)
        {
            var queryCorrectAnswer = _unitOfWorkApplication.QuestionCorrectAnswerRepository.Get(qca => qca.ID == queryAnswer.QueryRiddle.QuestionCorrectAnswerID);

            var userResult = _sqlQueryValidatorService.ExecuteQuery(queryAnswer.UserAnswer, _configuration["ConnectionStrings:RiddleWarehouseConnection"]);
            var correctResult = _sqlQueryValidatorService.ExecuteQuery(queryCorrectAnswer.CorrectAnswer, _configuration["ConnectionStrings:RiddleWarehouseConnection"]);

            queryAnswer.CorrectResult = correctResult;
            queryAnswer.UserResult = userResult;

            var output = _sqlQueryValidatorService.ValidateQuery(userResult, correctResult);

            return View(queryAnswer);
        }
    }
}
