using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;

namespace MoodPlus.Controllers
{
    public class NoteController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public SignInManager<Account> signInManager { get; set; }
        public UserManager<Account> userManager { get; set; }
        public NoteController(ApplicationDbContext db, SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            this.db = db;
            this.signInManager = signInManager;
            this.userManager = userManager;
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
            db.Notes.Remove(db.Notes.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            string apiURL = "https://zenquotes.io/api/random/";
            string quote = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(apiURL);
                if(response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var json = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TempNote>>(data);
                    quote = json[0].q + " - " + json[0].a;
                    
                }
            }

            // question: how do we get the userId of the logged in user
            string userId = userManager.GetUserId(HttpContext.User);
            Account account = db.Accounts.Find(userId);
            int senderId = account.Patient.Id;

            Random r = new Random();
            int rand = r.Next(0, db.Patients.Count());
            int recieverId = db.Patients.Skip(rand).FirstOrDefault().Id;
            
            Note posiNote = new Note() { Id = 0, Quote = quote, SenderId = senderId, ReceiverId = recieverId };
            db.Notes.Add(posiNote);
            db.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public IActionResult Inbox()
        {
            return View();
        }


        //public IActionResult Details()
        //{
        //    return View();
        //}
    }
}
