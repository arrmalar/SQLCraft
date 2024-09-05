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

        // GET api/admin/query/{id}
        [HttpGet("{id}")]
        public ActionResult<DBSchema> Get(int id)
        {
            var dbSchema = _unitOfWork.DBSchemaRepository.Get(db => db.ID == id);

            if (dbSchema == null)
            {
                return NotFound();
            }

            return Ok(dbSchema);
        }

        // GET api/admin/query
        [HttpGet]
        public ActionResult<IEnumerable<DBSchema>> GetAll()
        {
            var dbSchemas = _unitOfWork.DBSchemaRepository.GetAll();

            if (dbSchemas == null || !dbSchemas.Any())
            {
                return NotFound();
            }

            return Ok(dbSchemas);
        }

        // POST api/admin/query
        [HttpPost]
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

        // DELETE api/admin/query/{id}
        [HttpDelete("{id}")]
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

        // PUT api/admin/query
        [HttpPut]
        public ActionResult Update([FromBody] DBSchema dbSchema)
        {
            try
            {
                var existingDBSchema = _unitOfWork.DBSchemaRepository.Get(db => db.ID == dbSchema.ID);
                if (existingDBSchema == null)
                {
                    return NotFound();
                }

                _unitOfWork.DBSchemaRepository.Update(existingDBSchema);
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
