namespace MoodPlus.Data
{
    public class TempEntry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public string Body { get; set; }
        public bool Anxiety { get; set; }
        public int AnxietyRating { get; set; }
        public bool Cheerful { get; set; }
        public int CheerfulRating { get; set; }
        public bool Happiness { get; set; }
        public int HappinessRating { get; set; }
        public bool Loneliness { get; set; }
        public int LonelinessRating { get; set; }
        public bool Restless { get; set; }
        public int RestlessRating { get; set; }
        public bool Grumpy { get; set; }
        public int GrumpyRating { get; set; }
        public bool Sadness { get; set; }
        public int SadnessRating { get; set; }
        public bool Overwhelmed { get; set; }
        public int OverwhelmedRating { get; set; }
        public bool Aggravated { get; set; }
        public int AggravatedRating { get; set; }
        public bool Anger { get; set; }
        public int AngerRating { get; set; }
        public bool Calm { get; set; }
        public int CalmRating { get; set; }
        public bool Loved { get; set; }
        public int LovedRating { get; set; }
        public bool Shameful { get; set; }
        public int ShamefulRating { get; set; }

    }
}
