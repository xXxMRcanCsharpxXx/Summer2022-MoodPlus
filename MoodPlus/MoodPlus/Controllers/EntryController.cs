
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodPlus.Data;
using MoodPlus.Models;

namespace MoodPlus.Controllers
{
    public class EntryController : Controller
    {
        public ApplicationDbContext db { get; set; }
        public EntryController(ApplicationDbContext db)
        {
            this.db = db;
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
            db.Remove(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return View(db.Entries.Find(id));
        }

        //public IActionResult Update()
        //{

        //    return
        //}

        public IActionResult Create()
        {
            return View(new TempEntry());
        }
        [HttpPost]
        public IActionResult Create(TempEntry model)
        {
            Entry entry = new Entry() { Id = 0, PatientId = 1, Body = model.Body, Date=DateTime.Now };
            db.Entries.Add(entry);
            db.SaveChanges();

            foreach (string f in Enum.GetNames(typeof(Feeling)))
            {
                if ( (bool)typeof(TempEntry).GetProperty(f).GetValue(model) )
                {
                    MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = (Feeling)Enum.Parse(typeof(Feeling), f), Rating = (int)typeof(TempEntry).GetProperty(f+"Rating").GetValue(model)};
                    db.MoodRatings.Add(mr);
                    db.SaveChanges();
                }
            }


        //    if (model.Anxiety)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Anxiety, Rating = model.AnxietyRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Cheerful)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Cheerful, Rating = model.CheerfulRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Happiness)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Happiness, Rating = model.HappinessRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Loneliness)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Loneliness, Rating = model.LonelinessRating};
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Restless)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Restless, Rating = model.RestlessRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Grumpy)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Grumpy, Rating = model.GrumpyRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Sadness)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Sadness, Rating = model.SadnessRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Overwhelmed)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Overwhelmed, Rating = model.OverwhelmedRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Aggravated)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Aggravated, Rating = model.AggravatedRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Anger)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Anger, Rating = model.AngerRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Calm)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Calm, Rating = model.CalmRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Loved)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Loved, Rating = model.LovedRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
        //    if (model.Shameful)
        //    {
        //        MoodRating mr = new MoodRating() { EntryId = entry.Id, Feeling = Feeling.Shameful, Rating = model.ShamefulRating };
        //        db.MoodRatings.Add(mr);
        //        db.SaveChanges();
        //    }
            return View();
        }
    }
}
