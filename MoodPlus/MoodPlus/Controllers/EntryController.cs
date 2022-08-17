
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;

namespace MoodPlus.Controllers
{
    public class EntryController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public UserManager<Account> userManager { get; set; }
        public EntryController(ApplicationDbContext db, Microsoft.AspNetCore.Identity.UserManager<Account> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [Authorize]
        [Route("Entry/Index/{page?}")]
        public IActionResult Index(int? page)
        {
            string userId = userManager.GetUserId(HttpContext.User);
            Account account = db.Accounts.Find(userId);
            int patientId = account.Patient.Id;
            int resultsPerPage = 5;
            int count = db.Patients.Find(patientId).Entries.Count();
            if (page < 1 || page == null || (page - 1) * resultsPerPage > count)
            {
                ViewBag.Page = 1;
                page = 1;
            } 
            else
            {
                ViewBag.Page = page;
            }

            if((page) * resultsPerPage > count)
            {
                ViewBag.HasNextPage = false;
            } 
            else
            {
                ViewBag.HasNextPage = true;
                ViewBag.NextPage = page + 1;
            }

            if (page == 1)
            {
                ViewBag.HasLastPage = false;
            }
            else
            {
                ViewBag.HasLastPage = true;
                ViewBag.LastPage = page - 1;
            }
            List<Entry> entries = db.Entries.Where(e => e.PatientId == patientId).ToList();
            entries.Reverse();
            IEnumerable<Entry> pageEntries = entries.Skip(resultsPerPage * ((int)page - 1)).Take(resultsPerPage); // skips 20 and grabs 10 (21-30) entries from our database 
            return View(pageEntries);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            return View(db.Entries.Find(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(Entry model)
        {
            db.Entries.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            return View(db.Entries.Find(id));
        }

        [Authorize]
        public IActionResult Update(int id)
        {
            Entry entry = db.Entries.Find(id);
            return View(entry);
            
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(Entry model)
        {
            db.Entries.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [Authorize]
        public IActionResult Create()
        {
            string userId = userManager.GetUserId(HttpContext.User);
            Account account = db.Accounts.Find(userId);
            int patientId = account.Patient.Id;
            ViewBag.PatientId = patientId;
            return View(new TempEntry());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(TempEntry model)
        {
            // grab user
            var userId = userManager.GetUserId(HttpContext.User);
            Models.Patient patient = db.Patients.Where(p => p.AccountId == userId).FirstOrDefault();
            if (DateTime.Now > patient.NextLogin)
            {
                if (DateTime.Now.Subtract(patient.NextLogin).TotalHours > 24)
                {
                    patient.Streak = 1;
                }
                else
                {
                    patient.Streak++;
                    if (patient.Streak > patient.LongestStreak)
                    {
                        patient.LongestStreak = patient.Streak;
                    }
                }
                patient.NextLogin = DateTime.Now.AddHours(24);
                db.Patients.Update(patient);
                db.SaveChanges();
            }

            Entry entry = new Entry() { Id = 0, PatientId = model.PatientId, Body = model.Body, Date=DateTime.Now };
            db.Entries.Add(entry);
            db.SaveChanges();

            // this is a way to loop through all of the enum options
            foreach (string f in Enum.GetNames(typeof(Feeling)))
            {
                // this is a way to access a property via string name
                if ( (bool)typeof(TempEntry).GetProperty(f).GetValue(model) )
                {
                    MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = (Feeling)Enum.Parse(typeof(Feeling), f), Rating = (int)typeof(TempEntry).GetProperty(f+"Rating").GetValue(model)};
                    db.MoodRatings.Add(mr);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
