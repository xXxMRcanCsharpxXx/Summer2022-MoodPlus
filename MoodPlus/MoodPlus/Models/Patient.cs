namespace MoodPlus.Models
{
    public class Patient
    {
        public List<string> Moods { get; set; }
        public int Id { get; set; }
        public int Anxiety { get; set; }
        public int Cheerful { get; set; }
        public int Happiness { get; set; }
        public int Loneliness { get; set; }
        public int Restless { get; set; }
        public int Grumpy { get; set; }
        public int Sadness { get; set; }
        public int Overwhelmed { get; set; }
        public int Aggravated { get; set; }
        public int Anger { get; set; }
        public int Calm { get; set; } 
        public int Loved { get; set; }
        public int Shameful { get; set; }
        public List<Journal> Journals { get; set; }

       /* public enum Moods
        {
         Anxiety,
         Cheerful,
         Happiness,
         Loneliness,
         Restless,
         Grumpy,
         Sadness,
         Overwhelmed,
         Aggravated,
         Anger, 
         Calm, 
         Loved, 
         Shameful
        }*/

    }
}
