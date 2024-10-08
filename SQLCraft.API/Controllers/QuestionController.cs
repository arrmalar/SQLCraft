using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IUnitOfWorkApplication _unitOfWork;

        public QuestionController(IUnitOfWorkApplication unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get/{id}")]
        public ActionResult<Question> Get(int id)
        {
            var query = _unitOfWork.QuestionRepository.Get(qr => qr.ID == id, includeProperties: "DBSchema,QuestionLevel,QuestionCorrectAnswer");

            if (query == null)
            {
                return NotFound();
            }

            return Ok(query);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Question>> GetAll()
        {
            var queries = _unitOfWork.QuestionRepository.GetAll(includeProperties: "DBSchema,QuestionLevel,QuestionCorrectAnswer");

            if (queries == null || !queries.Any())
            {
                return NotFound();
            }

            return Ok(queries);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] Question queryRiddle)
        {
            try
            {
                _unitOfWork.QuestionRepository.Add(queryRiddle);
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
                var query = _unitOfWork.QuestionRepository.Get(qr => qr.ID == id);
                if (query == null)
                {
                    return NotFound();
                }

                _unitOfWork.QuestionRepository.Remove(query);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] Question queryRiddle)
        {
            try
            {
                var existingQuery = _unitOfWork.QuestionRepository.Get(qr => qr.ID == queryRiddle.ID);
                if (existingQuery == null)
                {
                    return NotFound();
                }

                _unitOfWork.QuestionRepository.Update(queryRiddle);
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
