using System.Web.Http;
using System.Web.Mvc;
using TwitterApp.DAL.Repository.Interfaces;

namespace TwitterApp.Web.Api
{
    [RequireHttps]
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/subscribe")]
    public class SubscribeController : ApiController
    {
        private readonly ISubscribeRepository _repository;

        public SubscribeController(ISubscribeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Subscribe
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetUsers()
        {
            var result = _repository.GetUsers();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Subscribe
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSubscribeUsers()
        {
            var result = _repository.GetSubscribeUsers();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // GET: api/Subscribe
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSubscribtionsUsers()
        {
            var result = _repository.GetSubscribtionsUsers();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}