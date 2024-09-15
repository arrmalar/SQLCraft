using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBSchemaController : ControllerBase
    {

        private readonly IUnitOfWorkApplication _unitOfWork;
        
        public DBSchemaController(IUnitOfWorkApplication unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("get/{id}")]
        public ActionResult<DBSchema> Get(int id)
        {
            var dbSchema = _unitOfWork.DBSchemaRepository.Get(db => db.ID == id);

            if (dbSchema == null)
            {
                return NotFound();
            }

            return Ok(dbSchema);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<DBSchema>> GetAll()
        {
            var dbSchemas = _unitOfWork.DBSchemaRepository.GetAll();

            if (dbSchemas == null || !dbSchemas.Any())
            {
                return NotFound();
            }

            return Ok(dbSchemas);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] DBSchema dbSchema)
        {
            try
            {
                _unitOfWork.DBSchemaRepository.Add(dbSchema);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = dbSchema.ID }, dbSchema);
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
                var dbSchema = _unitOfWork.DBSchemaRepository.Get(db => db.ID == id);
                if (dbSchema == null)
                {
                    return NotFound();
                }

                _unitOfWork.DBSchemaRepository.Remove(dbSchema);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] DBSchema dbSchema)
        {
            try
            {
                var existingDBSchema = _unitOfWork.DBSchemaRepository.Get(db => db.ID == dbSchema.ID);
                if (existingDBSchema == null)
                {
                    return NotFound();
                }

                _unitOfWork.DBSchemaRepository.Update(dbSchema);
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
