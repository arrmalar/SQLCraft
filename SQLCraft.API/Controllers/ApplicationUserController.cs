using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models.DTO.Identity;

namespace SQLCraft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IUnitOfWorkApplication _unitOfWork;

        public ApplicationUserController(IUnitOfWorkApplication unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("checkIfEmailExists/{email}")]
        public ActionResult<bool> CheckIfEmailExists(string email)
        {
            var asdfasdf = _unitOfWork.ApplicationUserRepository.GetAll();
            var applicationUser = _unitOfWork.ApplicationUserRepository.Get(user => user.Email == email);

            if (applicationUser == null)
            {
                return Ok(false);
            }

            return Ok(true);
        }


        [HttpGet("get/{id}")]
        public ActionResult<ApplicationUser> Get(string id)
        {
            var applicationUser = _unitOfWork.ApplicationUserRepository.Get(user => user.Id == id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        [HttpGet("getByEmail/{email}")]
        public ActionResult<ApplicationUser> GetByEmail(string email)
        {
            var applicationUser = _unitOfWork.ApplicationUserRepository.Get(user => user.Email == email);

            if (applicationUser == null)
            {
                return NotFound();
            }

            return Ok(applicationUser);
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<ApplicationUser>> GetAll()
        {
            var applicationUsers = _unitOfWork.ApplicationUserRepository.GetAll();

            if (applicationUsers == null || !applicationUsers.Any())
            {
                return NotFound();
            }

            return Ok(applicationUsers);
        }

        [HttpPost("save")]
        public ActionResult Save([FromBody] ApplicationUser applicationUser)
        {
            try
            {
                _unitOfWork.ApplicationUserRepository.Add(applicationUser);
                _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = applicationUser.Id }, applicationUser);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                var applicationUser = _unitOfWork.ApplicationUserRepository.Get(user => user.Id == id);
                if (applicationUser == null)
                {
                    return NotFound();
                }

                _unitOfWork.ApplicationUserRepository.Remove(applicationUser);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("update")]
        public ActionResult Update([FromBody] ApplicationUser applicationUser)
        {
            try
            {
                var existingApplicationUser = _unitOfWork.ApplicationUserRepository.Get(user => user.Id == applicationUser.Id);
                if (existingApplicationUser == null)
                {
                    return NotFound();
                }

                _unitOfWork.ApplicationUserRepository.Update(applicationUser);
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
