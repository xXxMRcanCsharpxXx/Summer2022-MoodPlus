namespace MoodPlus.Models
{
    public class MoodRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public virtual List<Feeling> Feelings  { get; set; }    
    }
}
