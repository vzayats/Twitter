namespace TwitterApp.DAL.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public int SubscribeUserId { get; set; }
    }
}
