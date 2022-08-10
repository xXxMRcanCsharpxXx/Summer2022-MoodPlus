using System.ComponentModel.DataAnnotations.Schema;

namespace MoodPlus.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<Entry> Entries { get; set; }
        [InverseProperty("Receiver")]
        public virtual ICollection<Note> Inbox { get; set; }
        [InverseProperty("Sender")]
        public virtual ICollection<Note> Outbox { get; set; }
        public int Streak { get; set; }
        public int LongestStreak { get; set; }
        public DateTime NextLogin { get; set; }
    }
   
}
