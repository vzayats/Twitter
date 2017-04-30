using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using TwitterApp.DAL.Context;
using TwitterApp.DAL.Entities;
using TwitterApp.Web.Properties;

namespace TwitterApp.Web.Api
{
    [RequireHttps]
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/subscriptions")]
    public class SubscriptionsController : ApiController
    {
        private TwitterContext db = new TwitterContext();

        private readonly int _fakeUserId = Settings.Default.FakeUser;

        // POST: api/Subscriptions
        [ResponseType(typeof(Subscription))]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> PostSubscription(Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

            return CreatedAtRoute("DefaultApi", new {id = subscription.SubscriptionId}, subscription);
        }

        // DELETE: api/Subscriptions/5
        [ResponseType(typeof(Subscription))]
        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteSubscription(int id)
        {
            var delete = (from d in db.Subscriptions
                where d.UserId == _fakeUserId && d.SubscribeUserId == id
                select d).Single();

            db.Subscriptions.Remove(delete);
            await db.SaveChangesAsync();

            return Ok();
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