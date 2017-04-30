using System;
using System.Collections.Generic;
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
    [System.Web.Http.RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        private TwitterContext db = new TwitterContext();

        private readonly int _fakeUserId = Settings.Default.FakeUser;

        // GET: api/Messages
        [System.Web.Http.HttpGet]
        public IQueryable<Message> GetMessages()
        {
            return db.Messages.Where(c => c.UserId == _fakeUserId);
        }

        // GET: api/Messages
        [System.Web.Http.HttpGet]
        public IEnumerable<Message> GetFollowMessages()
        {
            return db.Messages.Distinct().Join(
                db.Subscriptions,
                p => p.UserId,
                c => c.SubscribeUserId,
                (p, c) => p).Where(c => c.UserId != _fakeUserId).Distinct();
        }

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Message mes = new Message
            {
                UserId = _fakeUserId,
                Tweet = message.Tweet,
                DateCreated = DateTime.Now
            };
            db.Messages.Add(mes);

            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = message.Id}, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteMessage(int id)
        {
            Message message = await db.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            db.Messages.Remove(message);
            await db.SaveChangesAsync();

            return Ok(message);
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