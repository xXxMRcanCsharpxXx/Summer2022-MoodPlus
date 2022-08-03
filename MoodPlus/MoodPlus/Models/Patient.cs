namespace MoodPlus.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        // public virtual User User { get; set; }
        // public virtual List <Mood> Moods { get; set; }
        public List<Journal> Journals { get; set; }
        

   

    }
    public enum Feeling
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
    }
}
