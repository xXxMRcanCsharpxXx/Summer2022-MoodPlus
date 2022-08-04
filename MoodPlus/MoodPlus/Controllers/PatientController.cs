using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MoodPlus.Controllers
{
    public class PatientController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public SignInManager<User> signInManager { get; set; }
        public PatientController(ApplicationDbContext db, SignInManager<User> signInManager)
        {
            this.db = db;
            this.signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index(int id)
        {
            return View(db.Patients.Find(id));
        }

        [Authorize]
        public IActionResult Create()
        {
            return View( new Patient());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Patient model)
        {
            db.Patients.Add(model);
            db.SaveChanges();
            return View(model);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            Patient patient = db.Patients.Find(id);
            return View(patient);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(Patient model)
        {
            db.Patients.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
