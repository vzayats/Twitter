using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using TwitterApp.DAL.Entities;
using TwitterApp.DAL.Repository.Interfaces;

namespace TwitterApp.Web.Api
{
    [RequireHttps]
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/subscriptions")]
    public class SubscriptionsController : ApiController
    {
        private readonly ISubscriptionsRepository _repository;

        public SubscriptionsController(ISubscriptionsRepository repository)
        {
            _repository = repository;
        }

        // POST: api/Subscriptions
        [ResponseType(typeof(Subscription))]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> PostSubscription(Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.PostSubscription(subscription);

            return CreatedAtRoute("DefaultApi", new {id = subscription.SubscriptionId}, subscription);
        }

        // DELETE: api/Subscriptions/5
        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteSubscription(int id)
        {
            await _repository.DeleteSubscription(id);

            return Ok();
        }
    }
}