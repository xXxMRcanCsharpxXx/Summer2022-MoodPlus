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

        public IActionResult AboutUs()
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
            SetupLineChart();
            SetupDoughnutCharts();
            return View();
        }

        public void SetupDoughnutCharts()
        {
            string userId = userManager.GetUserId(HttpContext.User);
            Patient patient = db.Accounts.Find(userId).Patient;
            List<Entry> Entries = patient.Entries.Skip(Math.Max(0, db.Entries.Count() - 90)).ToList();

            List<DataDoughnut> Happiness = new List<DataDoughnut>();
            List<DataDoughnut> Anxiety = new List<DataDoughnut>();
            List<DataDoughnut> Anger = new List<DataDoughnut>();
            List<DataDoughnut> Calm = new List<DataDoughnut>();
            List<DataDoughnut> Loved = new List<DataDoughnut>();
            List<DataDoughnut> Stressed = new List<DataDoughnut>();
            List<DataDoughnut> Sadness = new List<DataDoughnut>();
            List<DataDoughnut> Overwhelmed = new List<DataDoughnut>();

            List<MoodRating> Happy = new List<MoodRating>();
            List<MoodRating> Anxious = new List<MoodRating>();
            List<MoodRating> Angry = new List<MoodRating>();
            List<MoodRating> Calmed = new List<MoodRating>();
            List<MoodRating> Love = new List<MoodRating>();
            List<MoodRating> Stress = new List<MoodRating>();
            List<MoodRating> Sad = new List<MoodRating>();
            List<MoodRating> Overwhelm = new List<MoodRating>();

            // filter our entries to each emotion
            for (int i = 0; i < Entries.Count; i++)
            {
                foreach (MoodRating mood in Entries[i].Moods)
                {
                    switch (mood.Feeling)
                    {
                        case Feeling.Happiness:
                            Happy.Add(mood);
                            break;
                        case Feeling.Anxiety:
                            Anxious.Add(mood);
                            break;
                        case Feeling.Anger:
                            Angry.Add(mood);
                            break;
                        case Feeling.Calm:
                            Calmed.Add(mood);
                            break;
                        case Feeling.Loved:
                            Love.Add(mood);
                            break;
                        case Feeling.Stressed:
                            Stress.Add(mood);
                            break;
                        case Feeling.Sadness:
                            Sad.Add(mood);
                            break;
                        case Feeling.Overwhelmed:
                            Overwhelm.Add(mood);
                            break;

                    }
                }
            }

            List<DataDoughnut> toAddHappy = new List<DataDoughnut>();
            List<DataDoughnut> toAddAnxious = new List<DataDoughnut>();
            List<DataDoughnut> toAddAngry = new List<DataDoughnut>();
            List<DataDoughnut> toAddCalmed = new List<DataDoughnut>();
            List<DataDoughnut> toAddLove = new List<DataDoughnut>();
            List<DataDoughnut> toAddStress = new List<DataDoughnut>();
            List<DataDoughnut> toAddSad = new List<DataDoughnut>();
            List<DataDoughnut> toAddOverwhelm = new List<DataDoughnut>();

            // calculate percentages of scores for each emotion
            for (int i = 0; i < 6; i++)
            {
                IEnumerable<MoodRating> HappyI = Happy.Where(m => m.Rating == i);
                DataDoughnut toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)HappyI.Count() / (double)Happy.Count()));
                toAddHappy.Add(toAdd);

                IEnumerable<MoodRating> AnxiousI = Anxious.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)AnxiousI.Count() / (double)Anxious.Count()));
                toAddAnxious.Add(toAdd);

                IEnumerable<MoodRating> AngeryI = Angry.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)AngeryI.Count() / (double)Angry.Count()));
                toAddAngry.Add(toAdd);

                IEnumerable<MoodRating> CalmedI = Calmed.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)CalmedI.Count() / (double)Calmed.Count()));
                toAddCalmed.Add(toAdd);

                IEnumerable<MoodRating> LoveI = Love.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)LoveI.Count() / (double)Love.Count()));
                toAddLove.Add(toAdd);

                IEnumerable<MoodRating> StressI = Stress.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)StressI.Count() / (double)Stress.Count()));
                toAddStress.Add(toAdd);

                IEnumerable<MoodRating> SadI = Sad.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)SadI.Count() / (double)Sad.Count()));
                toAddSad.Add(toAdd);

                IEnumerable<MoodRating> OverwhelmI = Overwhelm.Where(m => m.Rating == i);
                toAdd = new DataDoughnut("Rating: " + i, Math.Round(100 * (double)OverwhelmI.Count() / (double)Overwhelm.Count()));
                toAddOverwhelm.Add(toAdd);
            }
            // push that percentage data point into the appropriate list
            ViewBag.HappyDonut = JsonConvert.SerializeObject(toAddHappy);
            ViewBag.AnxiousDonut = JsonConvert.SerializeObject(toAddAnxious);
            ViewBag.AngryDonut = JsonConvert.SerializeObject(toAddAngry);
            ViewBag.CalmedDonut = JsonConvert.SerializeObject(toAddCalmed);
            ViewBag.LoveDonut = JsonConvert.SerializeObject(toAddLove);
            ViewBag.StressDonut = JsonConvert.SerializeObject(toAddStress);
            ViewBag.SadDonut = JsonConvert.SerializeObject(toAddSad);
            ViewBag.OverwhelmDonut = JsonConvert.SerializeObject(toAddOverwhelm);
        }
        
        public void SetupLineChart()
        {
            string userId = userManager.GetUserId(HttpContext.User);
            Patient patient = db.Accounts.Find(userId).Patient;
            List<Entry> Entries = patient.Entries.Skip(Math.Max(0, db.Entries.Count() - 90)).ToList();
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
                foreach (MoodRating mood in Entries[i].Moods)
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
        }
    }
}