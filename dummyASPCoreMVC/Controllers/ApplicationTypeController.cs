using dummyASPCoreMVC.Data;
using dummyASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace dummyASPCoreMVC.Controllers
{
    public class ApplicationTypeController : Controller
    {
        public readonly AppDbContext _db;

        public ApplicationTypeController(AppDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> ApplicationType = _db.ApplicationType;
            return View(ApplicationType);
        }

        //GET: CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Add(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(applicationType);

        }

        //Get: EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
                return NotFound();
            return View(obj);
        }

        //POST: EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(applicationType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        //GET: DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
                return NotFound();

            return View(obj);
        }

        //POST: DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id) 
        {
            var obj = _db.ApplicationType.Find(id);

            if (obj == null)
                return NotFound();

            _db.ApplicationType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
