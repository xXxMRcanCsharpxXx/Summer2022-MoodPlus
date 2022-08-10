namespace MoodPlus.Models
{
    public class MoodRating
    {
        public int Id { get; set; }
        public int EntryId { get; set; }
        public virtual Entry Entry { get; set; }
        public Feeling Feeling { get; set; }
        public int Rating { get; set; }
         
    }
    public enum Feeling
    {
        Anxiety,
        Happiness,
        Stressed,
        Sadness,
        Overwhelmed,
        Anger,
        Calm,
        Loved
    }
}
