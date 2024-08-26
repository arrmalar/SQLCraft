using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;
using SQLCraft.Models.VM;
using SQLCraft.Services;
using SQLCraft.Utility;

namespace SQLCraft.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin},{SD.Role_User}")]
    public class QueryController : Controller
    {
        private readonly IUnitOfWorkApplication _unitOfWork;
        private readonly ChatGPTService _chatGptService;
        private readonly string _queryQuestionPart1;
        private readonly string _queryQuestionPart2;

        public QueryController(IUnitOfWorkApplication unitOfWork, IConfiguration configuration, ChatGPTService chatGptService)
        {
            _unitOfWork = unitOfWork;
            _queryQuestionPart1 = configuration["OpenAIRequests:QueryQuestionPart1"];
            _queryQuestionPart2 = configuration["OpenAIRequests:QueryQuestionPart2"];
            _chatGptService = chatGptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var schemas = _unitOfWork.DBSchemaRepository.GetAll().Select(db => new SelectListItem
            {
                Text = db.Name,
                Value = db.ID.ToString()
            });

            var questionLevels = _unitOfWork.QuestionLevelRepository.GetAll().Select(ql => new SelectListItem
            {
                Text = ql.Name,
                Value = ql.ID.ToString()
            });

            var manageQueryRiddle = new ManageQueryRiddle();
            manageQueryRiddle.DBSchemas = schemas;
            manageQueryRiddle.QuestionLevels = questionLevels;
            manageQueryRiddle.QueryRiddle = new QueryRiddle();
            manageQueryRiddle.QueryRiddle.QuestionCorrectAnswer = new QuestionCorrectAnswer();
            return View(manageQueryRiddle);
        }

        [HttpPost]
        public IActionResult Create(ManageQueryRiddle manageQueryRiddle)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.QueryRiddleRepository.Add(manageQueryRiddle.QueryRiddle);
                _unitOfWork.Save();

                TempData["success"] = "Query created successfully";
                return RedirectToAction("Index");
            }

            var schemas = _unitOfWork.DBSchemaRepository.GetAll().Select(db => new SelectListItem
            {
                Text = db.Name,
                Value = db.ID.ToString()
            });

            var questionLevels = _unitOfWork.QuestionLevelRepository.GetAll().Select(ql => new SelectListItem
            {
                Text = ql.Name,
                Value = ql.ID.ToString()
            });

            manageQueryRiddle.DBSchemas = schemas;
            manageQueryRiddle.QuestionLevels = questionLevels;

            return View(manageQueryRiddle);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateByAI(ManageQueryRiddle manageQueryRiddle)
        {
            if (manageQueryRiddle.QueryRiddle != null && manageQueryRiddle.QueryRiddle.DBSchemaID != 0 && manageQueryRiddle.QueryRiddle.QuestionLevelID != 0)
            {
                var dbSchema = _unitOfWork.DBSchemaRepository.Get(dbs => dbs.ID == manageQueryRiddle.QueryRiddle.DBSchemaID);
                var questionLevel = _unitOfWork.QuestionLevelRepository.Get(ql => ql.ID == manageQueryRiddle.QueryRiddle.QuestionLevelID);

                try
                {
                    var question = System.IO.File.ReadAllText($"wwwroot/dotFiles/{dbSchema.Name}.gv") + " \n " + _queryQuestionPart1 + questionLevel.Name + _queryQuestionPart2;

                    if (string.IsNullOrEmpty(question))
                    {
                        ModelState.AddModelError(string.Empty, "Question cannot be empty.");
                        return Json(new { success = false, message = "Question cannot be empty." });
                    }

                    var answer = await _chatGptService.GetAnswerAsync(question);

                    manageQueryRiddle.QueryRiddle.Question = answer;
                    manageQueryRiddle.QueryRiddle.QuestionCorrectAnswer.CorrectAnswer = answer;
                } catch (Exception ex) {
                    return Json(new { success = false, message = ex.Message });
                }

                return Json(new { success = true, question = manageQueryRiddle.QueryRiddle.Question, correctAnswer = manageQueryRiddle.QueryRiddle.QuestionCorrectAnswer.CorrectAnswer });
            }

            return Json(new { success = false, message = "Model state is invalid." });
        }

        public IActionResult Edit(int? id)
        {
            var schemas = _unitOfWork.DBSchemaRepository.GetAll().Select(db => new SelectListItem
            {
                Text = db.Name,
                Value = db.ID.ToString()
            });

            var questionLevels = _unitOfWork.QuestionLevelRepository.GetAll().Select(ql => new SelectListItem
            {
                Text = ql.Name,
                Value = ql.ID.ToString()
            });


            var manageQueryRiddle = new ManageQueryRiddle();
            manageQueryRiddle.QueryRiddle = _unitOfWork.QueryRiddleRepository.Get(p => p.ID == id, includeProperties: "DBSchema,QuestionLevel,QuestionCorrectAnswer");
            manageQueryRiddle.DBSchemas = schemas;
            manageQueryRiddle.QuestionLevels = questionLevels;

            if (manageQueryRiddle.QueryRiddle != null)
            {
                return View(manageQueryRiddle);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ManageQueryRiddle manageQueryRiddle)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.QueryRiddleRepository.Update(manageQueryRiddle.QueryRiddle);
                _unitOfWork.Save();

                TempData["success"] = "Query edited successfully";
                return RedirectToAction("Index");
            }

            var schemas = _unitOfWork.DBSchemaRepository.GetAll().Select(db => new SelectListItem
            {
                Text = db.Name,
                Value = db.ID.ToString()
            });

            var questionLevels = _unitOfWork.QuestionLevelRepository.GetAll().Select(ql => new SelectListItem
            {
                Text = ql.Name,
                Value = ql.ID.ToString()
            });

            manageQueryRiddle.DBSchemas = schemas;
            manageQueryRiddle.QuestionLevels = questionLevels;

            return View(manageQueryRiddle);
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var queryList = _unitOfWork.QueryRiddleRepository.GetAll(includeProperties: "DBSchema,QuestionLevel,QuestionCorrectAnswer").ToList();
            return Json(new { data = queryList });
        }

        public IActionResult Delete(int? id)
        {
            var queryToBeDeleted = _unitOfWork.QueryRiddleRepository.Get(u => u.ID == id);
            var queryCorrectAnswerToBeDeleted = _unitOfWork.QuestionCorrectAnswerRepository.Get(u => u.ID == queryToBeDeleted.QuestionCorrectAnswerID);

            if (queryCorrectAnswerToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (queryToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.QueryRiddleRepository.Remove(queryToBeDeleted);
            _unitOfWork.QuestionCorrectAnswerRepository.Remove(queryCorrectAnswerToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
