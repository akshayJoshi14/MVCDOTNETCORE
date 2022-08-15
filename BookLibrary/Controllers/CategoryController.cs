using BookLibrary.DataAccess.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
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
                _db.Categories.Add(obj);
                _db.SaveChanges();
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
            var categroyFromDb = _db.Categories.Find(id);
            //categroyFromDb = _db.Categories.FirstOrDefault(cat => cat.Id == id);
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
                _db.Categories.Update(obj);
                _db.SaveChanges();
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
            var categroyFromDb = _db.Categories.Find(id);
            //categroyFromDb = _db.Categories.FirstOrDefault(cat => cat.Id == id);
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
            var obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
