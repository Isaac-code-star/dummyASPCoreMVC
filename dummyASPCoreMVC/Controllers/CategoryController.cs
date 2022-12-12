using dummyASPCoreMVC.Data;
using dummyASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace dummyASPCoreMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CategoryModel> objList = _db.CategoryModel;
            return View(objList);
        }

        //GET: CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                _db.CategoryModel.Add(categoryModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryModel);
            
        }

        //GET: EDIT
        public IActionResult Edit(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = _db.CategoryModel.Find(ID);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //POST: EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                _db.CategoryModel.Update(categoryModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryModel);

        }

        //GET: Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.CategoryModel.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteCategory(int? ID)
        {
            var obj = _db.CategoryModel.Find(ID);

            if (obj == null)
                return NotFound();

            _db.CategoryModel.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
