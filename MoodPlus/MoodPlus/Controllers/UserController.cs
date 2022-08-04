using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;

namespace MoodPlus.Controllers
{
    public class UserController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public SignInManager<Account> signInManager { get; set; }

        public UserController(ApplicationDbContext db, SignInManager<Account> signInManager)
        {
            this.db = db;
            this.signInManager = signInManager;
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Details(int id)
        {
            return View(db.Users.Find(id));
        }

        [Authorize]

        public IActionResult Delete(int id)
        {
            Account user = db.Accounts.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); // We could have this redirect somewhere else instead.
        }

        [Authorize]
        public IActionResult Create()
        {
            return View(new Account());   
        }

        [Authorize]
        [HttpPost]

        public IActionResult Create(Account model)
        {
            Account user = new Account() { UserName = model.UserName, UserGoal = model.UserGoal, Password = model.Password, Email = model.Email };
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            Account user = db.Accounts.Find(id);
            if(user == null)
            {
                return View("Error");
            }
            return View(user);
        }

        [HttpPost]

        public IActionResult Edit(Account model)
        {
            db.Users.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
