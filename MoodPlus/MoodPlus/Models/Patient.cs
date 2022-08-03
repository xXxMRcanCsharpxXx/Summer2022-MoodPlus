namespace MoodPlus.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Entry> Entries { get; set; }
        public virtual List<PosiNote> PositiveNote { get; set; }
        public int HighScore { get; set; }
    }
   
}
