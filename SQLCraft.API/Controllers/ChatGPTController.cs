using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models.VM;
using SQLCraft.Services;
using System.Threading.Tasks;

namespace SQLCraft.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        private readonly IUnitOfWorkApplication _unitOfWork;
        private readonly ChatGPTService _chatGptService;
        private readonly string _queryQuestionPart1;
        private readonly string _queryQuestionPart2;

        public ChatGPTController(IUnitOfWorkApplication unitOfWork, IConfiguration configuration, ChatGPTService chatGptService)
        {
            _unitOfWork = unitOfWork;
            _queryQuestionPart1 = configuration["OpenAIRequests:QueryQuestionPart1"];
            _queryQuestionPart2 = configuration["OpenAIRequests:QueryQuestionPart2"];
            _chatGptService = chatGptService;
        }

        // POST api/chatgpt
        [HttpPost]
        public async Task<IActionResult> GenerateByAI([FromBody] ManageQueryRiddle manageQueryRiddle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (manageQueryRiddle.QueryRiddle == null ||
                manageQueryRiddle.QueryRiddle.DBSchemaID == 0 ||
                manageQueryRiddle.QueryRiddle.QuestionLevelID == 0)
            {
                return BadRequest(new { success = false, message = "Invalid input data." });
            }

            var dbSchema = _unitOfWork.DBSchemaRepository.Get(dbs => dbs.ID == manageQueryRiddle.QueryRiddle.DBSchemaID);
            var questionLevel = _unitOfWork.QuestionLevelRepository.Get(ql => ql.ID == manageQueryRiddle.QueryRiddle.QuestionLevelID);

            if (dbSchema == null || questionLevel == null)
            {
                return NotFound(new { success = false, message = "Database schema or question level not found." });
            }

            try
            {
                var question = System.IO.File.ReadAllText($"wwwroot/dotFiles/{dbSchema.Name}.gv") + " \n " + _queryQuestionPart1 + questionLevel.Name + _queryQuestionPart2;

                if (string.IsNullOrEmpty(question))
                {
                    return BadRequest(new { success = false, message = "Question cannot be empty." });
                }

                var answer = await _chatGptService.GetAnswerAsync(question);

                manageQueryRiddle.QueryRiddle.QuestionText = answer;
                manageQueryRiddle.QueryRiddle.QuestionCorrectAnswer.CorrectAnswer = answer;

                return Ok(new
                {
                    success = true,
                    question = manageQueryRiddle.QueryRiddle.QuestionText,
                    correctAnswer = manageQueryRiddle.QueryRiddle.QuestionCorrectAnswer.CorrectAnswer
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
    }
}
