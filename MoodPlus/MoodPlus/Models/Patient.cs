using System.ComponentModel.DataAnnotations.Schema;

namespace MoodPlus.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Entry> Entries { get; set; }
        [InverseProperty("Receiver")]
        public virtual ICollection<PosiNote> Inbox { get; set; }
        [InverseProperty("Sender")]
        public virtual ICollection<PosiNote> Outbox { get; set; }
        public int Streak { get; set; }
        public int LongestStreak { get; set; }
    }
   
}
