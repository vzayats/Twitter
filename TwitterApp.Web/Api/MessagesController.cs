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
    [System.Web.Http.RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        private readonly IMessageRepository _repository;

        public MessagesController(IMessageRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Messages
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetMessages()
        {
            var result = _repository.GetMessages();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Messages
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetFollowMessages()
        {
            var result = _repository.GetFollowMessages();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
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

            await _repository.PostMessage(message);

            return CreatedAtRoute("DefaultApi", new {id = message.Id}, message);
        }

        // DELETE: api/Messages/5
        [System.Web.Http.HttpDelete]
        public async Task<IHttpActionResult> DeleteMessage(int id)
        {
            await _repository.DeleteMessage(id);

            return Ok();
        }
    }
}