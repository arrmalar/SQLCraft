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
            var query = _unitOfWork.QueryRiddleRepository.Get(qr => qr.ID == id, includeProperties: "DBSchema,QuestionLevel,QuestionCorrectAnswer");

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<QuestionCorrectAnswer>> GetAll()
        {
            var queries = _unitOfWork.QueryRiddleRepository.GetAll(includeProperties: "DBSchema,QuestionLevel,QuestionCorrectAnswer");

            if (queries == null || !queries.Any())
            {
                return NotFound();
            }

            return Ok(queries);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] QuestionCorrectAnswer questionCorrectAnswer)
        {
            try
            {
                _unitOfWork.QueryRiddleRepository.Add(queryRiddle);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = queryRiddle.ID }, queryRiddle);
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
                var query = _unitOfWork.QueryRiddleRepository.Get(qr => qr.ID == id);
                if (query == null)
                {
                    return NotFound();
                }

                _unitOfWork.QueryRiddleRepository.Remove(query);
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
                var existingQuery = _unitOfWork.QueryRiddleRepository.Get(qr => qr.ID == queryRiddle.ID);
                if (existingQuery == null)
                {
                    return NotFound();
                }

                _unitOfWork.QueryRiddleRepository.Update(queryRiddle);
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
