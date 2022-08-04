using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;

namespace MoodPlus.Controllers
{
    public class PosiNoteController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public PosiNoteController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Remove(id);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //public IActionResult Details()
        //{
        //    return View();
        //}
    }
}
