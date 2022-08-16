using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;

namespace MoodPlus.Controllers
{
    public class StreakViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public ApplicationDbContext db { get; set; }
        public StreakViewComponent(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke(string userId)
        {
            Patient patient = db.Accounts.Where(u => u.Email == userId).FirstOrDefault().Patient;
            return View(patient);
        }

    }
}
