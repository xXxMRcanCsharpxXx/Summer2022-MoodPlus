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

        public async Task<IActionResult> Create()
        {
            string apiURL = "https://zenquotes.io/api/random/"; //https://zenquotes.io/api/keywords/ //this link will generate a JSON array of available keywords via API call
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
                    quote = json[0].q;
                }
            }

            // question: how do we get the userId of the logged in user
            string userId = userManager.GetUserId(HttpContext.User);
            Account account = db.Accounts.Find(userId);
            int senderId = account.Patient.Id;

            List<Patient> patients = db.Patients.ToList();
            Random r = new Random();
            int rand = r.Next(0, patients.Count);
            int recieverId = patients[rand].Id;
            
            Note posiNote = new Note() { Id = 0, Quote = quote, SenderId = senderId, ReceiverId = recieverId };
            db.Notes.Add(posiNote);
            db.SaveChanges();
            return View();
        }


        //public IActionResult Details()
        //{
        //    return View();
        //}
    }
}
