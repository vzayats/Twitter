using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using TwitterApp.DAL.Context;
using TwitterApp.DAL.Entities;
using TwitterApp.Web.Properties;

namespace TwitterApp.Web.Api
{
    [RequireHttps]
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/subscribe")]
    public class SubscribeController : ApiController
    {
        private TwitterContext db = new TwitterContext();

        private readonly int _fakeUserId = Settings.Default.FakeUser;

        // GET: api/Subscribe
        [System.Web.Http.HttpGet]
        public IQueryable<User> GetUsers()
        {
            return db.Users.Where(c => c.UserId != _fakeUserId);
        }

        // GET: api/Subscribe
        [System.Web.Http.HttpGet]
        public IQueryable<User> GetSubscribeUsers()
        {
            return db.Users.Where(c => c.UserId == _fakeUserId);
        }

        // GET: api/Subscribe
        [System.Web.Http.HttpGet]
        public IQueryable<User> GetSubscribtionsUsers()
        {
            return db.Users.Join(
                db.Subscriptions,
                p => p.UserId,
                c => c.SubscribeUserId,
                (p, c) => p).Where(c => c.UserId != _fakeUserId).Distinct();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}