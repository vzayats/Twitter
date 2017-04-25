using TwitterApp.DAL.Entities;
using System.Data.Entity;

namespace TwitterApp.DAL.Context
{
    public class TwitterContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}