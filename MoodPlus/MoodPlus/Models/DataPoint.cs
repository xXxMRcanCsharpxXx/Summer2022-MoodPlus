using System.Runtime.Serialization;

namespace MoodPlus.Models
{
    [DataContract]
    public class DataPoint
    {
        
        public int Feeling { get; set; }

        [DataMember(Name = "y")]
        public int Rating { get; set; }

        [DataMember(Name = "x")]
        public DateTime Date { get; set; }

        public DataPoint (Feeling feeling, int rating, DateTime date)
        {
            Feeling = (int) feeling;    
            Rating = rating;  
            Date = date;
        }
    }

}
