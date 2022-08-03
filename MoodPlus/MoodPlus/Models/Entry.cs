namespace MoodPlus.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public virtual List<MoodRating> Moods { get; set; }
        public string? Body { get; set; }

    }

}
