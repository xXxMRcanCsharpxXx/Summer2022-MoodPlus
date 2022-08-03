namespace MoodPlus.Models
{
    public class Mood
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date    { get; set; }
        public virtual List<Feeling> Feelings   { get; set; }

    }

}
