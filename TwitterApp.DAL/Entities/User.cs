using System;
using System.Collections.Generic;

namespace TwitterApp.DAL.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public string City { get; set; }
        public string WebSite { get; set; }

        public ICollection<Message> Messages { get; set; }
        public User()
        {
            Messages = new List<Message>();
        }
    }
}