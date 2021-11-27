using Application.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult> Create([FromBody] CreateBookCommand command)
        {
            var res = await _mediator.Send(command);

            return Ok(res);
        }
    }
}
