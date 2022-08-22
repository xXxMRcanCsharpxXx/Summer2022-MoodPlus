using MoodPlus.Models;
using System.Runtime.Serialization;

namespace MoodPlus.Data
{
    [DataContract]
    public class DataPoint
    {

        public int Feeling { get; set; }

        [DataMember(Name = "y")]
        public int Rating { get; set; }

        [DataMember(Name = "x")]
        public double Date { get; set; }

        public DataPoint(Feeling feeling, int rating, DateTime date)
        {
            Feeling = (int)feeling;
            Rating = rating;
            Date = date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalMilliseconds;
        }
    }

}
