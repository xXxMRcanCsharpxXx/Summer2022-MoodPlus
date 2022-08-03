﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MoodPlus.Models
{
    public class PosiNote
    {
        public int Id { get; set; }
        //recieve or share a random positive encouragment message to a random user
        public string Quote { get; set; }
        public int SenderId { get; set; }
        public virtual Patient Sender { get; set; }
        public int ReceiverId {get; set; }
        public virtual Patient Receiver { get; set; }
       // Allows us to track sending/recieving quotes between users.
    }
}
