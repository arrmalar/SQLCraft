using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;
using SQLCraft.Models.VM;
using SQLCraft.Services;
using SQLCraft.Utility;

namespace SQLCraft.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{SD.Role_Admin}")]
    public class QueryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ChatGPTService _chatGptService;

        public QueryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var user = _unitOfWork.QueryRiddleRepository.Get(p => p.Id == id);

            if (user != null)
            {
                return View(user);
            }

            return NotFound();
        }

        public IActionResult Create()
        {
            var schemas = _unitOfWork.

            var manageQueryRiddle = new ManageQueryRiddle();
            manageQueryRiddle.QueryRiddle = new QueryRiddle();


            return View(manageQueryRiddle);
        }

        [HttpPost]
        public IActionResult Create(QueryRiddle query)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.QueryRiddleRepository.Add(query);
                _unitOfWork.Save();

                TempData["success"] = "Query created successfully";
                return RedirectToAction("Index");
            }

            return View(query);
        }

        public IActionResult CreateAI()
        {
            var query = new QueryRiddle();
            return View(query);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAI(QueryRiddle query)
        {
            if (string.IsNullOrEmpty(query.Question))
            {
                ModelState.AddModelError(string.Empty, "Question cannot be empty.");
                return View();
            }

            string answer = await _chatGptService.GetAnswerAsync(query.Question);

            if (ModelState.IsValid)
            {
                _unitOfWork.QueryRiddleRepository.Add(query);
                _unitOfWork.Save();

                TempData["success"] = "Query created successfully";
                return RedirectToAction("Index");
            }

            return View(query);
        }

        [HttpPost]
        public IActionResult Edit(QueryRiddle query)
        {
            if (!ModelState.IsValid)
            {
                return View(query);
            }

            if (query != null)
            {
                _unitOfWork.QueryRiddleRepository.Update(query);
                _unitOfWork.Save();
            }

            TempData["success"] = "Query edited successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var queryList = _unitOfWork.QueryRiddleRepository.GetAll().ToList();
            return Json(new { data = queryList });
        }

        public IActionResult Delete(int? id)
        {
            var queryToBeDeleted = _unitOfWork.QueryRiddleRepository.Get(u => u.Id == id);

            if (queryToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.QueryRiddleRepository.Remove(queryToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
