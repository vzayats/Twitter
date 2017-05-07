using System.Linq;
using System.Threading.Tasks;
using TwitterApp.DAL.Context;
using TwitterApp.DAL.Entities;
using TwitterApp.DAL.Properties;
using TwitterApp.DAL.Repository.Interfaces;

namespace TwitterApp.DAL.Repository
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private TwitterContext db = new TwitterContext();

        private readonly int _fakeUserId = Settings.Default.FakeUser;

        public async Task PostSubscription(Subscription subscription)
        {
            //Check if the user has already subscribed
            if (!db.Subscriptions.Any(o => o.SubscribeUserId == subscription.SubscribeUserId))
            {
                Subscription s = new Subscription
                {
                    UserId = _fakeUserId,
                    SubscribeUserId = subscription.SubscribeUserId
                };
                db.Subscriptions.Add(s);

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteSubscription(int id)
        {
            var delete = (from d in db.Subscriptions
                where d.UserId == _fakeUserId && d.SubscribeUserId == id
                select d).Single();

            db.Subscriptions.Remove(delete);
            await db.SaveChangesAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            Dispose(disposing);
        }
    }
}
