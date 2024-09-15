using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCorrectAnswerController : ControllerBase
    {
        private readonly IUnitOfWorkApplication _unitOfWork;

        public QuestionCorrectAnswerController(IUnitOfWorkApplication unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get/{id}")]
        public ActionResult<QuestionCorrectAnswer> Get(int id)
        {
            var answer = _unitOfWork.QuestionCorrectAnswerRepository.Get(qr => qr.ID == id);

            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<QuestionCorrectAnswer>> GetAll()
        {
            var answers = _unitOfWork.QuestionCorrectAnswerRepository.GetAll();

            if (answers == null || !answers.Any())
            {
                return NotFound();
            }

            return Ok(answers);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] QuestionCorrectAnswer questionCorrectAnswer)
        {
            try
            {
                _unitOfWork.QuestionCorrectAnswerRepository.Add(questionCorrectAnswer);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = questionCorrectAnswer.ID }, questionCorrectAnswer);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var answer = _unitOfWork.QuestionCorrectAnswerRepository.Get(qr => qr.ID == id);
                if (answer == null)
                {
                    return NotFound();
                }

                _unitOfWork.QuestionCorrectAnswerRepository.Remove(answer);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] QuestionCorrectAnswer questionCorrectAnswer)
        {
            try
            {
                var existingAnswer = _unitOfWork.QuestionCorrectAnswerRepository.Get(qr => qr.ID == questionCorrectAnswer.ID);
                if (existingAnswer == null)
                {
                    return NotFound();
                }

                _unitOfWork.QuestionCorrectAnswerRepository.Update(existingAnswer);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
