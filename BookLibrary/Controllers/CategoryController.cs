using BookLibrary.DataAccess.Data;
using BookLibrary.DataAccess.Repository.IRepository;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }

        // get Category create form load
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // here if we give Custome error then it will display only on top but if we wanted to display
                // on that particular field we should give property name of that model.
                ModelState.AddModelError("Name", "The DispalyOrder cannot exactly same as Name.");
            }
            // in core, we can use ModelState.Isvalid as server side validation.
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // Get Category create Edit form
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var categroyFromDb = _db.Find(id);
            var categroyFromDb = _unitOfWork.Category.GetFirstOrDefault(cat => cat.Id == id);
            //categroyFromDb = _db.Categories.SingleOrDefault(cat => cat.Id == id);

            if (categroyFromDb == null)
            {
                return NotFound();
            }
            return View(categroyFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                // here if we give Custome error then it will display only on top but if we wanted to display
                // on that particular field we should give property name of that model.
                ModelState.AddModelError("Name", "The DispalyOrder cannot exactly same as Name.");
            }

            // in core, we can use ModelState.Isvalid as server side validation.
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Get Category create Edit form
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categroyFromDb = _db.Categories.Find(id);
            var categroyFromDb = _unitOfWork.Category.GetFirstOrDefault(cat => cat.Id == id);
            //categroyFromDb = _db.Categories.SingleOrDefault(cat => cat.Id == id);

            if (categroyFromDb == null)
            {
                return NotFound();
            }
            return View(categroyFromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
