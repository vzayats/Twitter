using System.Linq;
using TwitterApp.DAL.Context;
using TwitterApp.DAL.Entities;
using TwitterApp.DAL.Properties;
using TwitterApp.DAL.Repository.Interfaces;

namespace TwitterApp.DAL.Repository
{
    public class SubscribeRepository : ISubscribeRepository
    {
        private TwitterContext db = new TwitterContext();

        private readonly int _fakeUserId = Settings.Default.FakeUser;

        public IQueryable<User> GetUsers()
        {
            return db.Users.Where(c => c.UserId != _fakeUserId);
        }

        public IQueryable<User> GetSubscribeUsers()
        {
            return db.Users.Where(c => c.UserId == _fakeUserId);
        }

        public IQueryable<User> GetSubscribtionsUsers()
        {
            return db.Users.Join(
                db.Subscriptions,
                p => p.UserId,
                c => c.SubscribeUserId,
                (p, c) => p).Where(c => c.UserId != _fakeUserId).Distinct();
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
