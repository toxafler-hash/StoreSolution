using System.Collections.Generic;
using System.Web.Http;

namespace PresentationNew.Controllers
{
    [RoutePrefix("api/sales")]
    public class SalesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(new List<object>());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] dynamic request)
        {
            return Ok(new { Id = System.Guid.NewGuid(), Message = "Акция создана" });
        }
    }
}