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
        public SignInManager<Account> signInManager { get; set; }
        public PatientController(ApplicationDbContext db, SignInManager<Account> signInManager)
        {
            this.db = db;
            this.signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            Patient patient = db.Accounts.Where(u => u.NormalizedEmail == id).FirstOrDefault().Patient;
            return View(patient);
        }

        
    }
    
}
