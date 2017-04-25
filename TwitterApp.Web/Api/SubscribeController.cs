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
    public class SubscribeController : ApiController
    {
        private TwitterContext db = new TwitterContext();

        readonly int _fakeUserId = Settings.Default.FakeUser;

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
            return db.Users
                .Where(c => db.Subscriptions
                        .Select(b => b.UserId)
                        .Contains(_fakeUserId)
                );
        }

        // GET: api/Subscribe/5
        [ResponseType(typeof(User))]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> GetUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Subscribe/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Subscribe
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new {id = user.UserId}, user);
        }

        // DELETE: api/Subscribe/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(int id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }
    }
}