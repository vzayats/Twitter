using System;

namespace TwitterApp.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Tweet { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}