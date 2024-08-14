using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;
using SQLCraft.Models.VM;
using SQLCraft.Services;
using SQLCraft.Utility;

namespace SQLCraft.Areas.Customer.Controllers
{
    [Area("User")]
    [Authorize(Roles = $"{SD.Role_User},{SD.Role_Admin}")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ChatGPTService _chatGptService;

        public HomeController(IUnitOfWork unitOfWork, ChatGPTService chatGptService)
        {
            _unitOfWork = unitOfWork;
            _chatGptService = chatGptService;
        }

        public IActionResult Index()
        {
            var riddles = _unitOfWork.QueryRiddleRepository.GetAll().ToList();

            Random r = new Random();
            int rInt = r.Next(0, riddles.Count());

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
            //queryAnswer.DBSchemas = 

            return View(queryAnswer);
        }


        [HttpPost]
        public async Task<IActionResult> Index(QueryAnswer queryAnswer)
        {

            // przepuœciæ odpowiedŸ przez bazê danych i sprawdziæ wynik z wynikiem oczekiwanym


            /*if (string.IsNullOrEmpty(queryAnswer.UserAnswer))
            {
                ModelState.AddModelError(string.Empty, "Question cannot be empty.");
                return View();
            }

            string answer = await _chatGptService.GetAnswerAsync(queryAnswer.UserAnswer);
            ViewBag.Answer = answer;*/

            return View(queryAnswer);
        }

    }
}
