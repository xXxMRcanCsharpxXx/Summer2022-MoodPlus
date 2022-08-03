namespace MoodPlus.Models
{
    public class PosiNote
    {
        public int Id { get; set; }
        //recieve or share a random positive encouragment message to a random user
        public string Quote { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public User Reciever { get; set; }
        public int RecieverId { get; set; }
       // Allows us to track sending/recieving quotes between users.
    }
}
