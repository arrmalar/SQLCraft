using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.API.Controllers.User
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionLevelController : ControllerBase
    {
        private readonly IUnitOfWorkApplication _unitOfWork;

        public QuestionLevelController(IUnitOfWorkApplication unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get/{id}")]
        public ActionResult<QuestionLevel> Get(int id)
        {
            var questionLevel = _unitOfWork.QuestionLevelRepository.Get(qr => qr.ID == id);

            if (questionLevel == null)
            {
                return NotFound();
            }

            return Ok(questionLevel);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<QuestionLevel>> GetAll()
        {
            var questionLevels = _unitOfWork.QuestionLevelRepository.GetAll();

            if (questionLevels == null || !questionLevels.Any())
            {
                return NotFound();
            }

            return Ok(questionLevels);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] QuestionLevel questionLevel)
        {
            try
            {
                _unitOfWork.QuestionLevelRepository.Add(questionLevel);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = questionLevel.ID }, questionLevel);
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
                var question = _unitOfWork.QuestionLevelRepository.Get(qr => qr.ID == id);
                if (question == null)
                {
                    return NotFound();
                }

                _unitOfWork.QuestionLevelRepository.Remove(question);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] QuestionLevel questionLevel)
        {
            try
            {
                var existingQuestionLevel = _unitOfWork.QuestionLevelRepository.Get(qr => qr.ID == questionLevel.ID);
                if (existingQuestionLevel == null)
                {
                    return NotFound();
                }

                _unitOfWork.QuestionLevelRepository.Update(questionLevel);
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
