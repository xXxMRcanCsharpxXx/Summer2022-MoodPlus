using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoodPlus.Data;
using MoodPlus.Models;

namespace MoodPlus.Controllers
{
    public class MoodRatingController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public MoodRatingController(ApplicationDbContext db)
        {
            this.db = db;   
        }
        public IActionResult Index()
        {
            return View(db.MoodRatings.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.MoodRatings = new SelectList(db.MoodRatings.ToList(), "Id", "Feeling");
            return View(new MoodRating());
        }
        [HttpPost]
        public IActionResult Create(MoodRating model)
        {
            db.MoodRatings.Add(model);
            db.SaveChanges();
            return RedirectToAction("Detail", model);
        }
        public IActionResult Details(int id)
        {
            return View(db.MoodRatings.Find(id));
        }
        public IActionResult Update(int id)
        {
      
            MoodRating moodRating = db.MoodRatings.Find(id); 
         
            return View(moodRating);
        }

        [HttpPost]
        public IActionResult Update(MoodRating model)
        {
            db.MoodRatings.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            MoodRating moodRating = db.MoodRatings.Find(id);
            return View(moodRating);
        }
        [HttpPost]
        public IActionResult Delete(MoodRating model)
        {
            db.MoodRatings.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
