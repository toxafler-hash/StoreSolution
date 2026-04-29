using System.Collections.Generic;
using System.Web.Http;
using MediatR;
using System.Threading.Tasks;
using System;

namespace PresentationNew.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductsController()
        {
            // Временный конструктор без MediatR для проверки
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            // Временный заглушка для проверки
            return Ok(new List<object>());
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] dynamic request)
        {
            // Временная заглушка
            return Ok(new { Id = Guid.NewGuid(), Message = "Товар создан" });
        }
    }
}