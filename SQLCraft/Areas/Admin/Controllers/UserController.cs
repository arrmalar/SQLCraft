using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;
using SQLCraft.Utility;

namespace SQLCraft.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin}")]
    public class UserController : Controller
    {
        private readonly IUnitOfWorkApplication _unitOfWork;

        public UserController(IUnitOfWorkApplication unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objApplicationUserList = _unitOfWork.ApplicationUserRepository.GetAll();
            return View(objApplicationUserList);
        }
        public IActionResult Edit(string? id)
        {
            var user = _unitOfWork.ApplicationUserRepository.Get(p => p.Id == id);

            if (user != null)
            {
                return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.NormalizedEmail = user.Email.ToUpper();
            user.NormalizedUserName = user.UserName.ToUpper();

            if (user != null)
            {
                _unitOfWork.ApplicationUserRepository.Update(user);
                _unitOfWork.Save();
            }

            TempData["success"] = "User edited successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objApplicationUserList = _unitOfWork.ApplicationUserRepository.GetAll().ToList();
            return Json(new { data = objApplicationUserList });
        }

        public IActionResult Delete(string? id)
        {
            var applicationUserToBeDeleted = _unitOfWork.ApplicationUserRepository.Get(u => u.Id == id);

            if (applicationUserToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.ApplicationUserRepository.Remove(applicationUserToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
