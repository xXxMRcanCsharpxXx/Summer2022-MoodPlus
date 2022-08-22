using System.Runtime.Serialization;

namespace MoodPlus.Data
{
    [DataContract]
    public class DataDoughnut
    {
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "y")]
        public double Y { get; set; }

        public DataDoughnut(string label, double y)
        {
            Label = label;
            Y = y;
        }
    }
}
