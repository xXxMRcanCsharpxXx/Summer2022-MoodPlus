namespace MoodPlus.Models
{
    public class PosiNote
    {
        public int id { get; set; }
        //recieve or share a random positive encouragment message to a random user
        public string Quote { get; set; }
        public List<string> Quotes { get; set; }
        public int HighScore { get; set; }
    }
}
