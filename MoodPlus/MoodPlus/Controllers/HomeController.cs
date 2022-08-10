using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MoodPlus.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public UserManager<Account> userManager { get; set; }
        private readonly ILogger<HomeController> _logger;
        public HomeController(ApplicationDbContext db, Microsoft.AspNetCore.Identity.UserManager<Account> userManager, ILogger<HomeController> logger)
        {
            this.db = db;
            this.userManager = userManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Graph()
        {
            //ViewBag.Theme = "light2";
            List<Entry> Entries = db.Entries.Skip(Math.Max(0, db.Entries.Count() - 90)).ToList();
            List<DataPoint> Happiness = new List<DataPoint>();
            List<DataPoint> Anxiety = new List<DataPoint>();
            List<DataPoint> Anger = new List<DataPoint>();
            List<DataPoint> Calm = new List<DataPoint>();
            List<DataPoint> Loved = new List<DataPoint>();
            List<DataPoint> Stressed = new List<DataPoint>();
            List<DataPoint> Sadness = new List<DataPoint>();
            List<DataPoint> Overwhelmed = new List<DataPoint>();


            for (int i = 0; i < Entries.Count; i++)
            {
                foreach(MoodRating mood in Entries[i].Moods)
                {
                    DataPoint toAdd = new DataPoint(mood.Feeling, mood.Rating, Entries[i].Date);
                    switch (mood.Feeling)
                    {
                        case Feeling.Happiness:
                            Happiness.Add(toAdd);
                            break;
                        case Feeling.Anger:
                            Anger.Add(toAdd);
                            break;
                        case Feeling.Anxiety:
                            Anxiety.Add(toAdd);
                            break;
                        case Feeling.Calm:
                            Calm.Add(toAdd);
                            break;
                        case Feeling.Loved:
                            Loved.Add(toAdd);
                            break;
                        case Feeling.Stressed:
                            Stressed.Add(toAdd);
                            break;
                        case Feeling.Sadness:
                            Sadness.Add(toAdd);
                            break;
                        case Feeling.Overwhelmed:
                            Overwhelmed.Add(toAdd);
                            break;
                        
                    }
                }
            }

            ViewBag.Happiness = JsonConvert.SerializeObject(Happiness);
            ViewBag.Anxiety = JsonConvert.SerializeObject(Anxiety);
            ViewBag.Anger = JsonConvert.SerializeObject(Anger);
            ViewBag.Calm = JsonConvert.SerializeObject(Calm);
            ViewBag.Loved = JsonConvert.SerializeObject(Loved);
            ViewBag.Stressed = JsonConvert.SerializeObject(Stressed);
            ViewBag.Sadness = JsonConvert.SerializeObject(Sadness);
            ViewBag.Overwhelmed = JsonConvert.SerializeObject(Overwhelmed);

            return View();
        }
    }
}