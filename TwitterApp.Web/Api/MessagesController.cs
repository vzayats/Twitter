using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
    public class MessagesController : ApiController
    {
        private TwitterContext db = new TwitterContext();

        readonly int _fakeUserId = Settings.Default.FakeUser;

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

        // GET: api/Messages/5
        [ResponseType(typeof(Message))]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetMessage(int id)
        {
            Message message = await db.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }


        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            db.Entry(message).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Messages
        [ResponseType(typeof(Message))]
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

        private bool MessageExists(int id)
        {
            return db.Messages.Count(e => e.Id == id) > 0;
        }
    }
}